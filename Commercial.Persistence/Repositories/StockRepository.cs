using Commercial.Domain.Entities;
using Commercial.Domain.Repositories.Interfaces;
using Commercial.Persistence.Contexts;

namespace Commercial.Persistence.Repositories;

public class StockRepository : GenericRepositoryAsync<Stock>, IStockRepository
{
    public StockRepository(ApplicationDbContext context) : base(context)
    {
    }
}