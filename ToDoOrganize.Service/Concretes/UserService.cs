using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using ToDoOrganize.Service.Abstracts;
using ToDoOrganize.Service.Rules;
using ToDoOrganize.Models.Dtos.Users.Requests;
using ToDoOrganize.Models.Entities;

namespace ToDoOrganize.Service.Concretes;

public sealed class UserService(UserManager<User> userManager, UserBusinessRules userBusinessRules) : IUserService
{
    public async Task<User> ChangePasswordAsync(string id, ChangePasswordRequestDto requestDto)
    {
        var user = await userManager.FindByIdAsync(id);
        
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }
        if (requestDto.NewPassword.Equals(requestDto.NewPasswordAgain) is false)
        {
            throw new BusinessException("Parola uyuşmuyor");
        }

        var result = await userManager.ChangePasswordAsync(user, requestDto.CurrentPassword, requestDto.NewPassword);
        CheckForIdentityResult(result);

        return user;
    }

    public async Task<string> DeleteAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }

        var result = await userManager.DeleteAsync(user);
        CheckForIdentityResult(result);

        return "Kullanıcı silindi";
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }

        return user;
    }

    public async Task<User> LoginAsync(LoginRequestDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);

        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }

        bool checkPassword = await userManager.CheckPasswordAsync(user, dto.Password);

        if (checkPassword is false)
        {
            throw new BusinessException("Parolanız yanlış");
        }

        return user;
    }

    public async Task<User> RegisterAsync(RegisterRequestDto dto)
    {
        userBusinessRules.CheckIfEmailIsUniqueAsync(dto.Email);
        userBusinessRules.CheckIfPasswordIsStrong(dto.Password);

        User user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            City = dto.City,
            UserName = dto.Username,

        };
        var result = await userManager.CreateAsync(user, dto.Password);
        CheckForIdentityResult(result);

        var addRole = await userManager.AddToRoleAsync(user, "User");
        CheckForIdentityResult(addRole);

        return user;
    }

    public async Task<User> UpdateAsync(string id, UpdateUserRequestDto dto)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        user.UserName = dto.Username;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.City = dto.City;


        var result = await userManager.UpdateAsync(user);
        CheckForIdentityResult(result);

        return user;
    }

    private void CheckForIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }
    }
}