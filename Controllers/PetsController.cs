using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Svelte.Data;
using Svelte.Models;

namespace Svelte.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PetsController : ControllerBase
  {
    private readonly AppDbContext _context;

    public PetsController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Pet>> GetAllPets()
    {
      return await _context.Pets.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetPet(Guid id)
    {
      var pet = await _context.Pets.FindAsync(id);

      if (pet == null)
      {
        return NotFound();
      }

      return pet;
    }

    [HttpPost]
    public async Task<ActionResult<Pet>> CreatePet(Pet pet)
    {
      await _context.Pets.AddAsync(pet);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Pet>> DeletePet(Guid id)
    {
      var pet = await _context.Pets.FindAsync(id);

      if (pet == null)
      {
        return NotFound();
      }

      _context.Pets.Remove(pet);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
