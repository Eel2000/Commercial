using Commercial.Application.DTOs.Stock;
using FluentValidation;

namespace Commercial.Application.Validators.Stock;

public class CreateStockValidator : AbstractValidator<CreateStock>
{
    public CreateStockValidator()
    {
        RuleFor(s => s.Name).NotEmpty().NotNull().WithMessage("The stock label or name is required");
        RuleFor(s => s.ProductId).Custom((x, context) =>
        {
            if (x == Guid.Empty)
            {
                context.AddFailure("Please enter a valid unique identifier");
            }
        });
        RuleFor(s => s.Quantity).GreaterThan(0).WithMessage("Cannot set stock quantity to 0");
    }
}