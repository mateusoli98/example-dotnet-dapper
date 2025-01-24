using DotnetDapper.Models;

namespace DotnetDapper.Services;

public class UserService : IUserService
{
    public Task<Response<List<UserResponseDTO>>> GetAll()
    {
        throw new NotImplementedException();
    }
}
