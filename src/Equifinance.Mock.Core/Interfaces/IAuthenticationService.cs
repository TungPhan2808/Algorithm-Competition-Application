using Equifinance.Mock.API.DTO;
using Equifinance.Mock.API.Models;

namespace Equifinance.Mock.API.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserDto> RegisterUserAsync(UserDto userDto);
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    }
}
