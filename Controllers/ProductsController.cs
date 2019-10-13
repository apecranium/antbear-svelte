using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Svelte.Data;
using Svelte.Models;
using Svelte.ViewModels;

namespace Svelte.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllProducts()
    {
      var products = await _context.Products.Include(p => p.Department).AsNoTracking().ToListAsync();

      var prods = new List<ProductViewModel>();

      foreach (var product in products)
      {
        prods.Add(new ProductViewModel
        {
          Id = product.Id,
          Name = product.Name,
          Price = product.Price,
          Department = product.Department.Name
        });
      }

      return prods;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
    {
      var product = await _context.Products.Include(p => p.Department).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

      if (product == null)
      {
        return NotFound();
      }

      var productViewModel = new ProductViewModel
      {
        Id = product.Id,
        Name = product.Name,
        Price = product.Price,
        Department = product.Department.Name
      };

      return productViewModel;
    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> CreateProduct([Bind("Name, Price, Department")] ProductViewModel productViewModel)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var department = await _context.Departments.FirstOrDefaultAsync(d => d.Name.ToLower() == productViewModel.Department);

      if (department == null)
      {
        department = new Department
        {
          Name = productViewModel.Department
        };
        await _context.Departments.AddAsync(department);
      }

      var product = new Product
      {
        Name = productViewModel.Name,
        Price = productViewModel.Price,
        Department = department
      };

      await _context.Products.AddAsync(product);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(GetProduct), new { id = product.Id });
    }
  }
}
