using Core.Tokens.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ToDoOrganize.Models.Dtos.Tokens;
using ToDoOrganize.Models.Entities;
using ToDoOrganize.Service.Abstracts;

namespace ToDoOrganize.Service.Concretes;

public class JwtService : IJwtService
{
    {
    private readonly TokenOption tokenOption;
    private readonly UserManager<User> userManager;

    public JwtService(TokenOption tokenOption, UserManager<User> userManager)
    {
        tokenOption = tokenOption;
        userManager = userManager;
    }

    public async Task<TokenResponseDto> CreateJwtTokenAsync(User user)
    {
        var accesTokenExpiration = DateTime.Now.AddMinutes(tokenOption.AccessTokenExpiration);
        var secretkey = SecurityKeyHelper.GetSecurityKey(tokenOption.SecurityKey);

        SigningCredentials sc = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha512Signature);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: tokenOption.Issuer,
            claims: await GetClaims(user, tokenOption.Audience),
            expires: accesTokenExpiration,
            signingCredentials: sc
            );

        var handler = new JwtSecurityTokenHandler();
        string token = handler.WriteToken(jwtSecurityToken);

        return new TokenResponseDto
        {
            AccessToken = token,
            AccessTokenExpiration = accesTokenExpiration
        };

    }
    public async Task<List<Claim>> GetClaims(User user, List<string> audiences)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim("Email", user.Email),
            new Claim(ClaimTypes.Name,user.UserName)
        };

        var roles = await userManager.GetRolesAsync(user);

        if (roles.Count > 0)
        {
           claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
        }

        claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
        return claims;
    }

}