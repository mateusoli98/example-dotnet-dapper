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

        var resultUsers = _mapper.Map<List<UserResponseDTO>>(users);
        return Task.FromResult(new ResultResponse<List<UserResponseDTO>> { Result = resultUsers });
    }
}
