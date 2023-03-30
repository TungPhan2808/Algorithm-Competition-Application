using AutoMapper;
using Equifinance.Mock.API.DTO;
using Equifinance.Mock.API.Models;

namespace Equifinance.Mock.API.Helper
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
