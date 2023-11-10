using Commercial.Application.DTOs.Product;
using FluentValidation;

namespace Commercial.Application.Validators.Product;

public class CreateProductValidator : AbstractValidator<CreateProduct>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty();
        RuleFor(p => p.Description).NotEmpty().NotNull();
        RuleFor(p => p.CoverPic).NotEmpty().NotNull();
        RuleFor(p => p.CategoryId).NotEqual(Guid.Empty).WithMessage("Please enter a valid key for the category");
        RuleFor(p => p.UnitPrice).GreaterThan(0m).WithMessage("The unit price must be greater than 0");
    }
}