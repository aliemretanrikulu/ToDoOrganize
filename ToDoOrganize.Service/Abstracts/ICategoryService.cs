using Core.Responses;
using ToDoOrganize.Models.Dtos.Categories.Requests;
using ToDoOrganize.Models.Dtos.Categories.Responses;

namespace ToDoOrganize.Service.Abstracts;

public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto?> GetById(int id);
    ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create);
    ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory);
    ReturnModel<CategoryResponseDto> Remove(int id);
}
