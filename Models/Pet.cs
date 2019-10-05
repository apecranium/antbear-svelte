using System;
using System.ComponentModel.DataAnnotations;

namespace Svelte.Models
{
  public class Pet
  {
    public Guid Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 1)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
  }
}
