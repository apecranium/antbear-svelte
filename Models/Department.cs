using System.Collections.Generic;

namespace Svelte.Models
{
  public class Department
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
  }
}
