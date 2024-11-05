using Microsoft.AspNetCore.Mvc;
using ToDoOrganize.Models.Dtos.Categories.Requests;
using ToDoOrganize.Service.Abstracts;


namespace ToDoOrganize.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCategoryRequest dto)
    {
        var result = _categoryService.Add(dto);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] int id)
    {
        var result = _categoryService.Remove(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateCategoryRequest dto)
    {
        var result = _categoryService.Update(dto);
        return Ok(result);
    }
}