using DotnetDapper.Models;

namespace DotnetDapper.Repositories;

public interface IUserRepository
{
    List<User> GetAll();
}
