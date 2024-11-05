using Core.Repositories;
using ToDoOrganize.DataAccess.Abstracts;
using ToDoOrganize.DataAccess.Contexts;
using ToDoOrganize.Models.Entities;

namespace ToDoOrganize.DataAccess.Concretes;
public class EfToDoRepository : EfRepositoryBase<BaseDbContext, ToDo, Guid>, IToDoRepository
{
    public EfToDoRepository(BaseDbContext context) : base(context)
    {

    }
}
