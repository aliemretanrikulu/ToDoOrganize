using Core.Responses;
using ToDoOrganize.Models.Dtos.Tokens;
using ToDoOrganize.Models.Dtos.Users.Requests;
using ToDoOrganize.Service.Abstracts;

namespace ToDoOrganize.Service.Concretes;
public class AuthenticationService(IUserService _userService, IJwtService _jwtService) : IAuthenticationService
{
    public async Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userService.LoginAsync(dto);
        var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = tokenResponse,
            Message = "Başarıyla giriş yapıldı",
            StatusCode = 200,
            Success = true
        };
    }
    public async Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto)
    {
        var user = await _userService.RegisterAsync(dto);
        var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = tokenResponse,
            Message = "Başarıyla kayıt olundu",
            StatusCode = 200,
            Success = true
        };
    }
}