using Core.Repositories;
using ToDoOrganize.Models.Entities;

namespace ToDoOrganize.DataAccess.Abstracts;

public interface IToDoRepository : IRepository<ToDo, Guid>
{

}