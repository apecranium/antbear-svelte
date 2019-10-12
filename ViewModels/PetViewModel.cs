using System;
using System.ComponentModel.DataAnnotations;

namespace Svelte.ViewModels
{
  public class PetViewModel
  {
    public int? Id { get; set; }

    [StringLength(60, MinimumLength = 1)]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
  }
}
