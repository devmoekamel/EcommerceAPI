using Ecommerce.DTOS;
using Ecommerce.Helper;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;

        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }

        public async Task<AuthDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            if (await _userManager.FindByNameAsync(registerDTO.UserName) is not null)
                return new AuthDTO { Message = "UserName already Exist" };
            if (await _userManager.FindByEmailAsync(registerDTO.Email) is not null)
                return new AuthDTO { Message = "Email already Exist" };

            var newUser = new User
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PasswordHash = registerDTO.Password,
                UserName = registerDTO.UserName,
            };
            var result = await _userManager.CreateAsync(newUser, registerDTO.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                    errors += $"{error.Description}  \n";
                return new AuthDTO { Message = errors };
            }
            await _userManager.AddToRoleAsync(newUser, "User");

            var jwtToken = await CreateJwtToken(newUser);

            return new AuthDTO
            {
                Email = newUser.Email,
                ExpiredOn = jwtToken.ValidTo,
                IsAuthenticated = true,
                Id = newUser.Id,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                UserName = newUser.UserName,
            };
        }
        public async Task<AuthDTO> LoginAsync(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return new AuthDTO { Message = "Email Or Password is Wrong" };



            var authmodel = new AuthDTO();

            var JwtSecurityToken = await CreateJwtToken(user);
            var Roles = await _userManager.GetRolesAsync(user);



            return new AuthDTO
            {
                ExpiredOn = JwtSecurityToken.ValidTo,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken),
                UserName = user.UserName,
                Roles = Roles.ToList(),
                IsAuthenticated = true,
                Id = user.Id

            };
        }
        public async Task<string> AddRoleAsync(AddRoleDTO model)
        {

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user is null || !await _roleManager.RoleExistsAsync(model.Role)) return "Invalid User or ROle ";
            if (await _userManager.IsInRoleAsync(user, model.Role)) return $"User already In this {model.Role}";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "somthing went Wrong";
        }
        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var SigningCredentials = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var roleclaims = new List<Claim>();
            foreach (var role in userRoles)
                roleclaims.Add(new Claim("roles", role));
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
           }.Union(userClaims)
           .Union(roleclaims);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.Duration),
                signingCredentials: SigningCredentials);

            return jwtSecurityToken;


        }




    }
}
