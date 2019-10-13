using System.Collections.Generic;
using Svelte.Models;

namespace Svelte.ViewModels
{
  public class DepartmentViewModel
  {
    public DepartmentViewModel() {}

    public DepartmentViewModel(Department department, List<DepartmentProduct> products)
    {
      Id = department.Id;
      Name = department.Name;
      Products = products;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<DepartmentProduct> Products { get; set; }
  }

  public class DepartmentProduct
  {
    public DepartmentProduct(Product product)
    {
      Id = product.Id;
      Name = product.Name;
      Price = product.Price;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
}
