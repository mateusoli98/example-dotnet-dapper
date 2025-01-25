using DotnetDapper.Models;

namespace DotnetDapper.Services;

public interface IUserService
{
    Task<ResultResponse<List<UserResponseDTO>>> GetAll();
    Task<ResultResponse<UserResponseDTO>> GetById(long id);
}
