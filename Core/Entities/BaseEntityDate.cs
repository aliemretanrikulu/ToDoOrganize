namespace Core.Entities;

public abstract class BaseEntityDate<TId> : Entity<TId>
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    protected BaseEntityDate()
    {
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }

    public void Update()
    {
        UpdatedDate = DateTime.Now;
    }
}
