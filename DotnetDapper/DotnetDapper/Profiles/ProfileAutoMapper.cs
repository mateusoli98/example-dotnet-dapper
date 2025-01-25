using AutoMapper;
using DotnetDapper.Models;

namespace DotnetDapper.Profiles;

public class ProfileAutoMapper : Profile
{
    public ProfileAutoMapper()
    {
        CreateMap<User, UserResponseDTO>().ReverseMap();
    }
}
