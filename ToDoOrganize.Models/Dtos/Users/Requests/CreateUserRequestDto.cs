namespace ToDoOrganize.Models.Dtos.Users.Requests;

public sealed record CreateUserRequestDto(string UserName, string FirstName, string LastName, string City, string Role);
