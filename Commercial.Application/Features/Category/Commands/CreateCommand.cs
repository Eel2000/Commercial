using Commercial.Application.DTOs.Category;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using FluentValidation;
using MediatR;

namespace Commercial.Application.Features.Category.Commands;

public class CreateCommand : IRequest<Response<CategoryDTO>>
{
    public CreateCommand(CreateCategoryDTO categoryDto)
    {
        CategoryDto = categoryDto;
    }

    public CreateCategoryDTO CategoryDto { get; set; }
}

public class CreateCommandHandler : IRequestHandler<CreateCommand, Response<CategoryDTO>>
{
    public CreateCommandHandler(ICategoryService categoryService, IValidator<CreateCategoryDTO> validator)
    {
        _categoryService = categoryService;
        _validator = validator;
    }

    private readonly ICategoryService _categoryService;
    private readonly IValidator<CreateCategoryDTO> _validator;

    public async Task<Response<CategoryDTO>> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request.CategoryDto);
        if (validation.IsValid)
        {
            var creation = await _categoryService.AddAsync(request.CategoryDto);
            return creation;
        }

        var errors = validation.Errors.Select(x => x.ErrorMessage).ToArray();
        return new Response<CategoryDTO>("Failed to create the new category due to some internal validation errors",
            errors);
    }
}