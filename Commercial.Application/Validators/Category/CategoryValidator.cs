using Commercial.Application.DTOs.Category;
using FluentValidation;

namespace Commercial.Application.Validators.Category;

public class CategoryValidator : AbstractValidator<CreateCategoryDTO>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty().MaximumLength(15);
        RuleFor(c => c.Description).MaximumLength(255);
    }
}