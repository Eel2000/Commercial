using Commercial.Application.DTOs.Category;
using FluentValidation;

namespace Commercial.Application.Validators.Category;

public class EditCategoryValidator : AbstractValidator<CategoryDTO>
{
    public EditCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Connot leave the Name empty or null. it's a required filed");
        
        RuleFor(c => c.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Cannot leave the description input empty or null when updating data");
    }
}