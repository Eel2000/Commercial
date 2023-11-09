using Commercial.Application.DTOs.Category;
using Commercial.Domain.Entities;
using Riok.Mapperly.Abstractions;
using System.Collections.Immutable;

namespace Commercial.Application.Mappings;

[Mapper]
public partial class CategoryMapper
{
    public partial CategoryDTO CatergoryToCategoryDTO(Category category);
    public partial ImmutableList<CategoryDTO> CatergoryToListCategoryDTO(IReadOnlyList<Category> categories);
    public partial Category CategoryDtoTOCategory(CreateCategoryDTO category);
    public partial Category CategoryDtoTOCategory(CategoryDTO category);
}