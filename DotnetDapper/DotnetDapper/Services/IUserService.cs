using DotnetDapper.Models;

namespace DotnetDapper.Services;

public interface IUserService
{
    Task<ResultResponse<List<UserResponseDTO>>> GetAll();
    Task<ResultResponse<UserResponseDTO>> GetById(long id);
    Task<ResultResponse<bool>> CreateUser(CreateUserRequestDTO request);
    Task<ResultResponse<bool>> UpdateUser(UpdateUserRequestDTO request);
}
