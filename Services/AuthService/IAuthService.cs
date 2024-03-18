using Ecommerce.DTOS;

namespace Ecommerce.Services.AuthService
{
    public interface IAuthService
    {
        Task<AuthDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<AuthDTO> LoginAsync(LoginDTO LoginDTO);
        Task<string> AddRoleAsync(AddRoleDTO model);

    }
}
