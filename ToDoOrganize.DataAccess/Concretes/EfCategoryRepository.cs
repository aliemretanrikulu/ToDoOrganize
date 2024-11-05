using Core.Repositories;
using ToDoOrganize.DataAccess.Abstracts;
using ToDoOrganize.DataAccess.Contexts;
using ToDoOrganize.Models.Entities;

namespace ToDoOrganize.DataAccess.Concretes;

public class EfCategoryRepository : EfRepositoryBase <BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
        
    }
}
