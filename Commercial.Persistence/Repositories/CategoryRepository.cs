using Commercial.Domain.Entities;
using Commercial.Domain.Repositories.Interfaces;
using Commercial.Persistence.Contexts;

namespace Commercial.Persistence.Repositories;

public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}