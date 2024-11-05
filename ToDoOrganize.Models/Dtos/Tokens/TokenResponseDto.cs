namespace ToDoOrganize.Models.Dtos.Tokens;

public sealed class TokenResponseDto
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}
