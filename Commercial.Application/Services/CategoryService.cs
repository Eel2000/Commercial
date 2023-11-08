using System.Collections.Immutable;
using Commercial.Application.DTOs.Category;
using Commercial.Application.Mappings;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using Commercial.Domain.Repositories.Interfaces;

namespace Commercial.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    public async ValueTask<Response<CategoryDTO>> AddAsync(CreateCategoryDTO category)
    {
        var mapper = new CategoryMapper();

        var newCategory = mapper.CategoryDtoTOCategory(category);
        var added = await _categoryRepository.AddAsync(newCategory);

        return new Response<CategoryDTO>("new Category created", mapper.CatergoryToCategoryDTO(added));
    }

    public async ValueTask<Response<ImmutableList<CategoryDTO>>> GetCategoriesAsync()
    {
        var mapper = new CategoryMapper();

        var categoriesRaw = await _categoryRepository.ToListAsync(x => x.IsActive);
        var data = mapper.CatergoryToListCategoryDTO(categoriesRaw);

        return new Response<ImmutableList<CategoryDTO>>(data: data);
    }
}