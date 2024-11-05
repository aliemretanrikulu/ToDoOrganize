using ToDoOrganize.Models.Dtos.Tokens;
using ToDoOrganize.Models.Entities;

namespace TodoListify.Service.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateJwtTokenAsync(User user);
}