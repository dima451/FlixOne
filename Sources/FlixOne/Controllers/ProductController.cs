using FlixOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Controllers
{
  public class ProductController : Controller
  {
    private IStoreRepository _productRepository;
   
    public ProductController(IStoreRepository repository)
    {
      _productRepository = repository;
    }

    public IActionResult List() => View(_productRepository.Products);
  }
}