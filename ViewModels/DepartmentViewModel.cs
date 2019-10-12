using System.Collections.Generic;

namespace Svelte.ViewModels
{
  public class DepartmentViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<DepartmentProduct> Products { get; set; }
  }

  public class DepartmentProduct
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
}
