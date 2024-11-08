﻿using ToDoOrganize.Models.Dtos.Users.Requests;
using ToDoOrganize.Models.Entities;

namespace ToDoOrganize.Service.Abstracts;

public interface IUserService
{
    Task<User> LoginAsync(LoginRequestDto dto);
    Task<User> RegisterAsync(RegisterRequestDto dto);
    Task<User> GetByEmailAsync(string email);
    Task<string> DeleteAsync(string id);
    Task<User> UpdateAsync(string id, UpdateUserRequestDto dto);
    Task<User> ChangePasswordAsync(string id, ChangePasswordRequestDto requestDto);
}