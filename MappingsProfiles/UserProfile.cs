using AspNetCoreIdentityWebApi.DTO;
using AspNetCoreIdentityWebApi.Models;
using AutoMapper;

namespace AspNetCoreIdentityWebApi.MappingsProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<CreateUserRequestDTO, User>()
                .ForMember(dest=>dest.UserName, option=>option
                .MapFrom(sourc=>sourc.Email));
               
        }
    }
}
