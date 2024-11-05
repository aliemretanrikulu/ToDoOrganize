namespace Core.Tokens.Configurations;

public class TokenOption {
    public string Issuer { get; set; }
    public List<string> Audience { get; set; }
    public string SecurityKey { get; set; }
    public int AccessTokenExpiration { get; set; }
}