namespace ToDoOrganize.Models.Dtos.ToDos.Responses;

public sealed record ToDoResponseDto
{
    public string UserName { get; init; }  // immutable yapı 
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime EndDate { get; init; }
    public int Category { get; init; }
    public bool Completed { get; init; }
}
