using AutoMapper;
using Core.Responses;
using ToDoOrganize.DataAccess.Abstracts;
using ToDoOrganize.Service.Abstracts;
using ToDoOrganize.Service.Rules;
using ToDoOrganize.Models.Dtos.ToDos.Requests;
using ToDoOrganize.Models.Dtos.ToDos.Responses;
using ToDoOrganize.Models.Entities;

namespace ToDoOrganize.Service.Concretes;

public class TodoService : IToDoService
{
    private readonly IToDoRepository todoRepository;
    private readonly IMapper mapper;
    private readonly ToDoBusinessRules businessRules;

    public TodoService(IToDoRepository todoRepository, IMapper mapper, ToDoBusinessRules businessRules)
    {
        todoRepository = todoRepository;
        mapper = mapper;
        businessRules = businessRules;
    }
    public ReturnModel<ToDoResponseDto> Add(CreateToDoRequest dto, string userId)
    {
        ToDo createdTodo = mapper.Map<ToDo>(dto);
        createdTodo.CreatedDate = DateTime.Now;
        createdTodo.Id = Guid.NewGuid();
        createdTodo.UserId = userId;

        todoRepository.Add(createdTodo);

        ToDoResponseDto response = mapper.Map<ToDoResponseDto>(createdTodo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = response,
            Message = "Görev eklendi",
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAll()
    {
        List<ToDo> todos = todoRepository.GetAll();
        List<ToDoResponseDto> responses = mapper.Map<List<ToDoResponseDto>>(todos);

        return new ReturnModel<List<ToDoResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<ToDoResponseDto?> GetById(Guid id)
    {
        var todo = todoRepository.GetById(id);
        var response = mapper.Map<ToDoResponseDto?>(todo);
        businessRules.ToDoIsNullCheck(todo);

        return new ReturnModel<ToDoResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<ToDoResponseDto> Remove(Guid id)
    {
        var todo = todoRepository.GetById(id);

        if (todo is null)
        {
            return new ReturnModel<ToDoResponseDto>
            {
                Data = null,
                Message = "Görev bulunamadı",
                StatusCode = 404,
                Success = false,
            };
        }
        var deletedToDo = todoRepository.Remove(todo);
        var response = mapper.Map<ToDoResponseDto>(deletedToDo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = response,
            Message = "Görev silindi",
            StatusCode = 200,
            Success = true,
        };
    }

        public ReturnModel<ToDoResponseDto> Update(UpdateToDoRequest updateToDo)
    {
        ToDo todo = todoRepository.GetById(updateToDo.Id);

        if (todo is null)
        {
            return new ReturnModel<ToDoResponseDto>
            {
                Data = null,
                Message = "Görev bulunamadı",
                StatusCode = 404,
                Success = false,
            };
        }

        mapper.Map(updateToDo, todo);
        todo.UpdatedDate = DateTime.Now;

        ToDo updatedTodo = todoRepository.Update(todo);

        ToDoResponseDto dto = mapper.Map<ToDoResponseDto>(updatedTodo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = dto,
            Message = "Görev güncellendi",
            StatusCode = 200,
            Success = true,
        };
    }
}