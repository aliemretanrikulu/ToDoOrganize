namespace ToDoOrganize.Models.Dtos.ToDos.Requests;

public sealed record UpdateToDoRequest(string Title, string Description, DateTime StartDate, DateTime EndDate, int CategoryId);
