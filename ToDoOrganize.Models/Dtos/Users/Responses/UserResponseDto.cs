namespace ToDoOrganize.Models.Dtos.Users.Responses;

public sealed record UserResponseDto
{
    public Guid Id { get; set; }
    public string UserName { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string City { get; init; }
    public DateTime CreatedDate { get; init; }

}

