
using Core.Responses;
using ToDoOrganize.Models.Dtos.ToDos.Requests;
using ToDoOrganize.Models.Dtos.ToDos.Responses;

namespace ToDoOrganize.Service.Abstracts;

public interface IToDoService
{
    ReturnModel<List<ToDoResponseDto>> GetAll();
    ReturnModel<ToDoResponseDto?> GetById(Guid id);
    ReturnModel<ToDoResponseDto> Add(CreateToDoRequest dto, string userId);
    ReturnModel<ToDoResponseDto> Update(UpdateToDoRequest dto);
    ReturnModel<ToDoResponseDto> Remove(Guid id);
}