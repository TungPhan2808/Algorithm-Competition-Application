using AutoMapper;
using Equifinance.Mock.API.DTO;
using Equifinance.Mock.Core.Models;

namespace Equifinance.Mock.Infrastructure.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Problem, ProblemDto>().ReverseMap();
            CreateMap<ProblemRequestDto, Problem>().ReverseMap();
        }
    }
}
