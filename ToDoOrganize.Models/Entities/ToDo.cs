using Core.Entities;
using ToDoOrganize.Models.Enums;

namespace ToDoOrganize.Models.Entities;

public sealed class ToDo : BaseEntityDate<Guid>
{
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime EndDate { get; set; }
    public Priority Priority { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public User User { get; set; }
    public bool Completed { get; set; }
}
