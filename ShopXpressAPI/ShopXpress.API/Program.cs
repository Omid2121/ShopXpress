using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ShopXpress.BLL;
using ShopXpress.BLL.Services;
using ShopXpress.DAL.Configurations;
using ShopXpress.DAL.IRepository;
using ShopXpress.DAL.Repository;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ShopXpressDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
        });

        builder.Services.AddMemoryCache();
        builder.Services.ConfigureRateLimiting();
        builder.Services.AddHttpContextAccessor();
        //builder.Services.ConfigureHttpCacheHeaders();
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
        builder.Services.ConfigureIdentity();
        builder.Services.ConfigureJWT(builder.Configuration);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

        builder.Services.ConfigureAutoMapper();

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IAuthManager, AuthManager>();
        builder.Services.AddScoped<OrderService>();
        builder.Services.AddScoped<CartService>();

        AddSwaggerDoc(builder.Services);

        builder.Services.AddControllers()
            .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        void AddSwaggerDoc(IServiceCollection services)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "@JWT Authorization header using the Bearer scheme." +
                    "Enter 'Bearer' [space] and then your token in the text input blow." +
                    "Example: 'Bearer 1234abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            },
                            Scheme = "0auth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopXpress.API", Version = "v1" });
            });
        }

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopXpress v1"));
        } 
        else if (app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopXpress v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.ConfigureExceptionHandler();

        app.UseCors("AllowAll");

        //app.UseResponseCaching();
        //app.UseHttpCacheHeaders();
        app.UseIpRateLimiting();

        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}