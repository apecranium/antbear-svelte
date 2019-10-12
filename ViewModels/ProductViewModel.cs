namespace Svelte.ViewModels
{
  public class ProductViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductDepartment Department { get; set; }
  }
  public class ProductDepartment
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
