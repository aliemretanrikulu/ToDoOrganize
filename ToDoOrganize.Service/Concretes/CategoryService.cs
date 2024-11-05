using AutoMapper;
using Core.Responses;
using ToDoOrganize.DataAccess.Abstracts;
using ToDoOrganize.Models.Dtos.Categories.Requests;
using ToDoOrganize.Models.Dtos.Categories.Responses;
using ToDoOrganize.Models.Entities;
using ToDoOrganize.Service.Abstracts;
using ToDoOrganize.Service.Rules;

namespace ToDoOrganize.Service.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;
    private readonly IMapper mapper;
    private readonly CategoryBusinessRules categoryBusinessRules;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        categoryBusinessRules = categoryBusinessRules;
        mapper = mapper;
        categoryRepository = categoryRepository;
    }

    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest dto)
    {
        categoryBusinessRules.CheckIfCategoryNameIsValid(dto.Name);

        Category createdCategory = mapper.Map<Category>(dto);
        categoryRepository.Add(createdCategory);

        CategoryResponseDto response = mapper.Map<CategoryResponseDto>(createdCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category eklendi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        List<Category> categories = categoryRepository.GetAll();
        List<CategoryResponseDto> responses = mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto?> GetById(int id)
    {
        var category = categoryRepository.GetById(id);
        var response = mapper.Map<CategoryResponseDto?>(category);

        return new ReturnModel<CategoryResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<CategoryResponseDto> Remove(int id)
    {
        var category = categoryRepository.GetById(id);
        var deletedCategory = categoryRepository.Remove(category);

        var response = mapper.Map<CategoryResponseDto>(deletedCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Kategori kaldırıldı",
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory)
    {
        Category category = categoryRepository.GetById(updateCategory.Id);

        if (category is null)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Data = null,
                Message = "Kategori bulunamadı",
                StatusCode = 404,
                Success = false
            };
        }

        mapper.Map(updateCategory, category);

        Category updatedCategory = categoryRepository.Update(category);
        CategoryResponseDto dto = mapper.Map<CategoryResponseDto>(updatedCategory);


        return new ReturnModel<CategoryResponseDto>
        {
            Data = dto,
            Message = "Kategori güncellendi",
            StatusCode = 200,
            Success = true,
        };
    }
}
