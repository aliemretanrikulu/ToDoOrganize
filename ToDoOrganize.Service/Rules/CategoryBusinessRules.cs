using Core.Exceptions;
using ToDoOrganize.DataAccess.Abstracts;

namespace ToDoOrganize.Service.Rules;

public class CategoryBusinessRules(ICategoryRepository categoryRepository)
{
    public void CheckIfCategoryNameIsValid(string categoryName)
    {
        if (categoryName.Length < 3 || categoryName.Length > 20)
        {
            throw new BusinessException("Kategori adı en az 3 en fazla 20 olmalıdır");
        }
    }
}
