using Core.Repositories;
using ToDoOrganize.Models.Entities;

namespace ToDoOrganize.DataAccess.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{

}
