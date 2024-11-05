namespace ToDoOrganize.Models.Dtos.ToDos.Requests;

public sealed record UpdateToDoRequest(Guid Id, string Title, string Description, DateTime StartDate, DateTime EndDate, int CategoryId);
