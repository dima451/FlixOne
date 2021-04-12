using System.Linq;

namespace FlixOne.Models
{
  public interface IProductRepository
  {
    IQueryable<Product> Products { get; }
  }
}