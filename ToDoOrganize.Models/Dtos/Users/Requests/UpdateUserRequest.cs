namespace ToDoOrganize.Models.Dtos.Users.Requests;

public sealed record UpdateUserRequest(string Username, string FirstName, string LastName, string City);