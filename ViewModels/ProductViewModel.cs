using Svelte.Models;

namespace Svelte.ViewModels
{
  public class ProductViewModel
  {
    public ProductViewModel() {}

    public ProductViewModel(Product product)
    {
      Id = product.Id;
      Name = product.Name;
      Price = product.Price;
      Department = product.Department.Name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Department { get; set; }
  }
}
