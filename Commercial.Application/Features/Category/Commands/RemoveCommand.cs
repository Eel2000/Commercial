using Commercial.Application.DTOs.Category;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using MediatR;

namespace Commercial.Application.Features.Category.Commands;

public class RemoveCommand : IRequest<Response<CategoryDTO>>
{
    public RemoveCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class RemoveCommandHandler : IRequestHandler<RemoveCommand, Response<CategoryDTO>>
{
    private readonly ICategoryService _categoryService;

    public RemoveCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Response<CategoryDTO>> Handle(RemoveCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.RemoveAsync(request.Id);
    }
}