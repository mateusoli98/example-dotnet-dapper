using AutoMapper;
using DotnetDapper.Models;
using DotnetDapper.Repositories;

namespace DotnetDapper.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<ResultResponse<List<UserResponseDTO>>> GetAll()
    {
        var users = _userRepository.GetAll();

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
        var user = _userRepository.GetById(id);

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

    public Task<ResultResponse<bool>> CreateUser(CreateUserRequestDTO request)
    {
        var resService = _userRepository.CreateUser(request);

        if (!resService)
        {
            return Task.FromResult(new ResultResponse<bool>()
            {
                Message = "Error creating user",
                Success = false
            });
        }

        return Task.FromResult(new ResultResponse<bool> { Result = resService });
    }

    public Task<ResultResponse<bool>> UpdateUser(UpdateUserRequestDTO request)
    {
        var resService = _userRepository.UpdateUser(request);
        
        if (!resService)
        {
            return Task.FromResult(new ResultResponse<bool>()
            {
                Message = "Error updating user",
                Success = false
            });
        }

        return Task.FromResult(new ResultResponse<bool> { Result = resService, Message = "User updated successfully" });
    }
}
