using Core.Responses;
using ToDoOrganize.Models.Dtos.Tokens;
using ToDoOrganize.Models.Dtos.Users.Requests;

namespace ToDoOrganize.Service.Abstracts;

public interface IAuthenticationService
{
    Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto);
    Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto);
}