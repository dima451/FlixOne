using System.Linq;

namespace FlixOne.Models
{
  public interface IStoreRepository
  {
    IQueryable<Product> Products { get; }
  }
}