using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopXpress.Bll.DTOs;
using ShopXpress.DAL.Models;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.BLL.Services;

public class AuthManager : IAuthManager
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private User _user;

    public AuthManager(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> CreateAccessToken()
    {
        var signingCredentials = GetSigningCredentials();
        var Claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, Claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var expiration = DateTimeOffset.Now.AddMinutes(
            Convert.ToDouble(jwtSettings.GetSection("JwtLifetime").Value));

        var token = new JwtSecurityToken(
            issuer: jwtSettings.GetSection("JwtValidIssuer").Value,
            audience: jwtSettings.GetSection("JwtValidAudience").Value,
            claims: claims,
            expires: expiration.UtcDateTime,
            signingCredentials: signingCredentials
            );
        return token;
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
            new Claim(ClaimTypes.Name, _user.UserName),
            new Claim(ClaimTypes.GivenName, _user.FirstName),
            new Claim(ClaimTypes.Surname, _user.LastName),
            new Claim(ClaimTypes.Email, _user.Email)
        };
        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }

    private SigningCredentials GetSigningCredentials()
    {
        // Depending on where you store your key (Environment or appsettings.json)
        //var key = Environment.GetEnvironmentVariable("JwtSecretKey");
        var key = _configuration.GetSection("JwtSettings").GetSection("JwtSecretKey").Value;

        var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public async Task<string> CreateRefreshToken()
    {
        await _userManager.RemoveAuthenticationTokenAsync(_user, "ShopXpressApi", "RefreshToken");
        var refreshToken = await _userManager.GenerateUserTokenAsync(_user, "ShopXpressApi", "RefreshToken");
        await _userManager.SetAuthenticationTokenAsync(_user, "ShopXpressApi", "RefreshToken", refreshToken);

        return refreshToken;
    }

    public async Task<string> GetUserRoleById(string userId)
    {
        _user = await _userManager.FindByIdAsync(userId);
        return (await _userManager.GetRolesAsync(_user)).FirstOrDefault();
    }

    public async Task<IEnumerable<string>> GetUserRolesById(string userId)
    {
        _user = await _userManager.FindByIdAsync(userId);
        return await _userManager.GetRolesAsync(_user);
    }

    public async Task<bool> ValidateUser(LoginDTO loginDTO)
    {
        _user = await _userManager.FindByEmailAsync(loginDTO.Email);
        return (_user != null && await _userManager.CheckPasswordAsync(_user, loginDTO.Password));
    }

    public async Task<User> GetUser(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<AuthResponse> VerifyRefreshToken(AuthRequest request)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
        var email = tokenContent.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
        //var userName = tokenContent.Claims.FirstOrDefault(claim => claim.Type == "sub")?.Value;
        _user = await _userManager.FindByEmailAsync(email);

        try
        {
            var isValid = await _userManager.VerifyUserTokenAsync(_user, "ShopXpressApi", "RefreshToken", request.RefreshToken);
            if (isValid)
            {
                return new AuthResponse
                {
                    Token = await CreateAccessToken(),
                    RefreshToken = await CreateRefreshToken()
                };
            }
            await _userManager.UpdateSecurityStampAsync(_user);
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return null;
    }
}
