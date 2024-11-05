using AutoMapper;
using Core.Responses;
using TodoListify.Service.Abstracts;
using TodoListify.Service.Rules;

namespace TodoListify.Service.Concretes;

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