using Commercial.Application.DTOs.Category;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using FluentValidation;
using MediatR;

namespace Commercial.Application.Features.Category.Commands;

public class EditCommand : IRequest<Response<CategoryDTO>>
{
    public EditCommand(CategoryDTO category)
    {
        Category = category;
    }

    public CategoryDTO Category { get; set; }
}

public class EditCommandHandler : IRequestHandler<EditCommand, Response<CategoryDTO>>
{
    public EditCommandHandler(IValidator<CategoryDTO> validator, ICategoryService categoryService)
    {
        _validator = validator;
        _categoryService = categoryService;
    }

    private readonly IValidator<CategoryDTO> _validator;
    private readonly ICategoryService _categoryService;

    public async Task<Response<CategoryDTO>> Handle(EditCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request.Category);
        if (validation.IsValid)
        {
            var result = await _categoryService.EditAsync(request.Category);

            return result;
        }

        var errors = validation.Errors.Select(x => x.ErrorMessage).ToArray();

        return new Response<CategoryDTO>("Failed to process the request. some validation errors occured", errors);
    }
}