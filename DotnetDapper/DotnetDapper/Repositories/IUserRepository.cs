using DotnetDapper.Models;

namespace DotnetDapper.Repositories;

public interface IUserRepository
{
    List<User> GetAll();
    User? GetById(long id);
    bool CreateUser(CreateUserRequestDTO request);
    bool UpdateUser(UpdateUserRequestDTO request);
}
