using Microsoft.AspNetCore.Identity;

namespace ToDoOrganize.Models.Entities;

public sealed class User : IdentityUser 
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public List<ToDo> ToDos { get; set; }
}
