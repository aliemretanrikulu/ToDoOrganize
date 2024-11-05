namespace ToDoOrganize.Models.Dtos.Users.Requests;

public sealed record UpdateUserRequestDto(string Username, string FirstName, string LastName, string City);