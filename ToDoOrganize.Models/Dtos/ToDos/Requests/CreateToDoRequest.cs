namespace ToDoOrganize.Models.Dtos.ToDos.Requests;

public sealed record UpdateToDosRequest(string Title, string Description, DateTime StartDate, DateTime EndDate, int CategoryId);
