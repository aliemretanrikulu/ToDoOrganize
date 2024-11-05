using FluentValidation;
using ToDoOrganize.Models.Dtos.ToDos.Requests;

namespace ToDoOrganize.Service.ValidationToDo
{
    public class CreateTodoRequestDtoValidator : AbstractValidator<CreateToDoRequest>
    {
        public CreateTodoRequestDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev başlığı boş olamaz!")
            .Length(5, 20).WithMessage("Görev başlığı en az 5, en fazla 20 karakterli olmalıdır!");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Görev açıklaması boş olamaz!");
        }
    }
}