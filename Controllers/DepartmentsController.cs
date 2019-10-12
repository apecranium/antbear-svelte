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
  public class DepartmentsController : ControllerBase
  {
    private readonly AppDbContext _context;

    public DepartmentsController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentViewModel>>> GetAllDepartments()
    {
      var departments = await _context.Departments.Include(d => d.Products).AsNoTracking().ToListAsync();

      var depts = new List<DepartmentViewModel>();

      foreach (var department in departments)
      {
        var deptProducts = new List<DepartmentProduct>();
        foreach (var deptProduct in department.Products)
        {
          deptProducts.Add(new DepartmentProduct
          {
            Id = deptProduct.Id,
            Name = deptProduct.Name,
            Price = deptProduct.Price
          });
        }
        depts.Add(new DepartmentViewModel
        {
          Id = department.Id,
          Name = department.Name,
          Products = deptProducts
        });
      }

      return depts;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentViewModel>> GetDepartment(int id)
    {
      var department = await _context.Departments.Include(d => d.Products).AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);

      if (department == null)
      {
        return NotFound();
      }

      var products = new List<DepartmentProduct>();

      foreach (var product in department.Products)
      {
        products.Add(new DepartmentProduct
        {
          Id = product.Id,
          Name = product.Name,
          Price = product.Price
        });
      }

      var departmentViewModel = new DepartmentViewModel
      {
        Id = department.Id,
        Name = department.Name,
        Products = products
      };

      return departmentViewModel;
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentViewModel>> CreateDepartment([Bind("Name")] DepartmentViewModel departmentViewModel)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var department = new Department
      {
        Name = departmentViewModel.Name
      };

      await _context.Departments.AddAsync(department);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(GetDepartment), new { id = department.Id });
    }
  }
}
