using AutoMapper;
using Equifinance.Mock.API.DTO;
using Equifinance.Mock.API.Interfaces;
using Equifinance.Mock.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Equifinance.Mock.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthenticationService(IAuthenticationRepository registrationRepository, IMapper mapper, IConfiguration configuration)
        {
            _authenticationRepository = registrationRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserDto> RegisterUserAsync(UserDto userDto)
        {
            if (userDto.Email == null)
            {
                NullReferenceException exception = new NullReferenceException("Email cannot be null");
                throw exception;
            }
            if (await _authenticationRepository.EmailExistsAsync(userDto.Email))
            {
                NullReferenceException nullReferenceException = new NullReferenceException("Email already exists");
                throw nullReferenceException;
            }
            var user = _mapper.Map<User>(userDto);
            if (userDto.Password == null)
            {
                Exception exception = new Exception("Password cannot be null");
                throw exception;
            }
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            await _authenticationRepository.AddUserAsync(user);

            return _mapper.Map<UserDto>(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            if (loginDto.Email == null)
            {
                NullReferenceException exception = new NullReferenceException("Email cannot be null");
                throw exception;
            }
            var user = await _authenticationRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null)
            {
                Exception exception = new Exception("Invalid credentials.");
                throw exception;
            }
            if (loginDto.Password == null)
            {
                Exception exception = new Exception("Password cannot be null");
                throw exception;
            }
            if (!VerifyPasswordHash(loginDto.Password, user.PasswordHash ?? throw new Exception("Password hash is missing or empty."), user.PasswordSalt ?? throw new Exception("Password salt email is missing or empty.")))
            {
                Exception exception = new Exception("Invalid password.");
                throw exception;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token")?.Value ?? throw new NullReferenceException("Token is missing or empty in the configuration."));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID.ToString()),
                    new Claim(ClaimTypes.Email, user.Email ?? throw new Exception("User email is missing or empty."))
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new LoginResponseDto
            {
                Id = user.UserID,
                Email = user.Email,
                Token = tokenString
            };
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                NullReferenceException exception = new NullReferenceException("Password cannot be null or whitespace.");
                throw exception;
            }
            if (passwordHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(passwordHash));
            }
            if (passwordSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(passwordSalt));
            }
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
