using AutoMapper;
using ToDoOrganize.Models.Dtos.Categories.Requests;
using ToDoOrganize.Models.Dtos.Categories.Responses;
using ToDoOrganize.Models.Dtos.ToDos.Requests;
using ToDoOrganize.Models.Dtos.ToDos.Responses;
using ToDoOrganize.Models.Entities;
namespace ToDoOrganize.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateToDoRequest, ToDo>();
        CreateMap<UpdateToDoRequest, ToDo>();
        CreateMap<ToDo, ToDoResponseDto>()
         .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
         .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));

        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<Category, CategoryResponseDto>();
    }
}