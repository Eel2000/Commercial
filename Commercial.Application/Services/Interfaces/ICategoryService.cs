using System.Collections.Immutable;
using Commercial.Application.DTOs.Category;
using Commercial.Domain.Commons;

namespace Commercial.Application.Services.Interfaces;

public interface ICategoryService
{
    ValueTask<Response<CategoryDTO>> AddAsync(CreateCategoryDTO category);
    ValueTask<Response<ImmutableList<CategoryDTO>>> GetCategoriesAsync();
    ValueTask<Response<CategoryDTO>> EditAsync(CategoryDTO category);
    ValueTask<Response<CategoryDTO>> RemoveAsync(Guid id);
}