using Commercial.Domain.Entities;
using Commercial.Domain.Repositories.Interfaces;
using Commercial.Persistence.Contexts;

namespace Commercial.Persistence.Repositories;

public class ProductRepository : GenericRepositoryAsync<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}