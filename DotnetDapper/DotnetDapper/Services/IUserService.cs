using DotnetDapper.Models;

namespace DotnetDapper.Services;

public interface IUserService
{
    Task<Response<List<UserResponseDTO>>> GetAll();
}
