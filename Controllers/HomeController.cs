using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Svelte.Models;

namespace Svelte.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HomeController : ControllerBase
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public ActionResult<string> GetGreeting()
    {
      return "Hello world!";
    }
  }
}
