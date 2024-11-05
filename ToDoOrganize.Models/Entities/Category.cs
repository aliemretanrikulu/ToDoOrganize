using Core.Entities;

namespace ToDoOrganize.Models.Entities;

public sealed class Category : Entity<Guid>
{
    public string Name { get; set; }
    public List<ToDo> ToDos { get; set; }
}
