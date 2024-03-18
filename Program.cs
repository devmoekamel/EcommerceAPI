
using Ecommerce.Context;
using Ecommerce.Helper;
using Ecommerce.Models;
using Ecommerce.Services.AuthService;
using Ecommerce.Services.CartService;
using Ecommerce.Services.CategoryService;
using Ecommerce.Services.CouponService;
using Ecommerce.Services.FavouriteService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ecommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(p => p.AddPolicy("cros", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           builder.Services.AddCors();
         //====================================================================
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtoptions =>
            {
                jwtoptions.RequireHttpsMetadata = false;
                jwtoptions.SaveToken = false;
                jwtoptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });
  //================================================================================
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });
 //====================================================================
            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
 //------------------------------Roles&User---------------------------------
            builder.Services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<ApplicationDBContext>();
//------------------------------Addscope---------------------------------
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICouponService, CouponService>();
            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddScoped<IFavouriteService,FavouriteService>();
            builder.Services.AddScoped<ICartService, CartService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("corsapp");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
