using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Svelte.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CacheTestController : ControllerBase
  {
    private readonly IDistributedCache _cache;

    public CacheTestController(IDistributedCache cache)
    {
      _cache = cache;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> CacheTest(int id)
    {
      var cacheKey = $":test:{id}";
      var test = await _cache.GetStringAsync(cacheKey);

      if (test == null)
      {
        var time = System.DateTime.Now.ToString();
        var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(30));
        await _cache.SetStringAsync(cacheKey, time, options);
        return Ok("added to cache: " + time);
      }

      return Ok("retrieved from cache: " + test);
    }
  }
}
