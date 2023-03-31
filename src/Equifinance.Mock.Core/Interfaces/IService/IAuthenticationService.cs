using Equifinance.Mock.API.DTO;

namespace Equifinance.Mock.Core.Interfaces.IService
{
    public interface IAuthenticationService
    {
        Task<UserDto> RegisterUserAsync(UserDto userDto);
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    }
}
