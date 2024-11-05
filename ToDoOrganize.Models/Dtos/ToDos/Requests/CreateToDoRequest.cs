namespace ToDoOrganize.Models.Dtos.ToDos.Requests;

public sealed record CreateToDoRequest(string Title, string Description, DateTime StartDate, DateTime EndDate, int CategoryId);
