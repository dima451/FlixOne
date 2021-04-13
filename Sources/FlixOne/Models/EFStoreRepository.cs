using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlixOne.Models
{
  public class EFStoreRepository : IStoreRepository
  {
    private StoreDbContext _applicationDbContext;
    public EFStoreRepository(StoreDbContext ctx)
    {
      _applicationDbContext = ctx;
    }
    public IQueryable<Product> Products => _applicationDbContext.Products;
  }
}
