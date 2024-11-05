using FluentValidation;
using ToDoOrganize.Models.Dtos.ToDos.Requests;
namespace ToDoOrganize.Service.ValidationToDo;

public class UpdateTodoRequestDtoValidator : AbstractValidator<UpdateToDoRequest>
{
    public UpdateTodoRequestDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Görev Başlığı boş olamaz.")
        .Length(2, 50).WithMessage("Görev başlığı en az 5, en fazla 20 karakterli olmalıdır!");

        RuleFor(x => x.Description).NotEmpty().WithMessage("Görev açıklaması boş olamaz.");
    }
}