using AutoMapper;
using DotnetDapper.Models;
using DotnetDapper.Repositories;

namespace DotnetDapper.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _repository = userRepository;
        _mapper = mapper;
    }

    public Task<ResultResponse<List<UserResponseDTO>>> GetAll()
    {
        var users = _repository.GetAll();

        if (users.Count == 0)
        {
            return Task.FromResult(new ResultResponse<List<UserResponseDTO>>()
            {
                Message = "No users found",
                Success = false
            });
        }

        return Task.FromResult(new ResultResponse<List<UserResponseDTO>> { Result = _mapper.Map<List<UserResponseDTO>>(users) });
    }

    public Task<ResultResponse<UserResponseDTO>> GetById(long id)
    {
        var user = _repository.GetById(id);

        if (user is null)
        {
            return Task.FromResult(new ResultResponse<UserResponseDTO>()
            {
                Message = "User not found",
                Success = false
            });
        }

        return Task.FromResult(new ResultResponse<UserResponseDTO> { Result = _mapper.Map<UserResponseDTO>(user!) });
    }
}
