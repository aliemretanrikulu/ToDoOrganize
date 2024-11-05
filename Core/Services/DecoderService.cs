using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Services;

public class DecoderService(IHttpContextAccessor httpContextAccessor)
{
    public string GetUserId()
    {
        return httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.NameIdentifier).Value;
    }
}