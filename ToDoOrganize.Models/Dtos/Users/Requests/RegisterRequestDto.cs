namespace ToDoOrganize.Models.Dtos.Users.Requests;

public sealed record RegisterRequestDto(string Username, string FirstName, string LastName, string Email, string Password, string City);