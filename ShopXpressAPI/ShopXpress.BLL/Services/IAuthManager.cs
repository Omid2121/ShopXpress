using ShopXpress.Bll.DTOs;
using ShopXpress.DAL.Models;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.BLL.Services;

public interface IAuthManager
{
    Task<bool> ValidateUser(LoginDTO userDTO);
    Task<string> CreateAccessToken();
    Task<string> CreateRefreshToken();
    Task<User> GetUser(string userId);
    Task<AuthResponse> VerifyRefreshToken(AuthRequest request);
    Task<string> GetUserRoleById(string userId);
    Task<IEnumerable<string>> GetUserRolesById(string userId);
    //Task<UserDTO> GetCurrentUser(ClaimsPrincipal claimsPrincipal);
}
