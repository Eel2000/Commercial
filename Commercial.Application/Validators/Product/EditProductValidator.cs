using Commercial.Application.DTOs.Product;
using FluentValidation;

namespace Commercial.Application.Validators.Product;

public class EditProductValidator : AbstractValidator<GetProduct>
{
    public EditProductValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty();
        RuleFor(p => p.Description).NotEmpty().NotNull();
        RuleFor(p => p.CoverPic).NotEmpty().NotNull();
        RuleFor(p => p.Pics).Custom((x, context) =>
        {
            if (!x.Any())
            {
                context.AddFailure("Cannot set the pics to an empty array list of pic");
            }
        });
        RuleFor(p => p.CategoryId).NotEqual(Guid.Empty).WithMessage("Please enter a valid key for the category");
        RuleFor(p => p.UnitPrice).GreaterThan(0m).WithMessage("The unit price must be greater than 0");
    }
}