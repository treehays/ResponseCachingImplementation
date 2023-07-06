using Microsoft.AspNetCore.Mvc;

namespace ResponseCachingImplementation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any)]
    [HttpGet("Get")]
    public IActionResult Get()
    {
        return Ok($"Response was generated at {DateTime.Now}");
    }

    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = true)]
    [HttpGet("GetNoStore")]
    public IActionResult GetNoStore()
    {
        return Ok($"Response was generated at {DateTime.Now}");
    }


    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "id" })]
    [HttpGet("GetVaryByQueryKeys")]
    public IActionResult GetVaryByQueryKeys(string id)
    {
        return Ok($"Response was generated at {DateTime.Now}");
    }


    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, VaryByHeader = "User-Agent")]
    [HttpGet("GetVaryByHeader")]
    public IActionResult GetVaryByHeader()
    {
        return Ok($"Response was generated at {DateTime.Now}");
    }

    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Client)]
    [HttpGet("GetDate")]
    public IActionResult GetDate()
    {
        return Ok($"Response was generated at {DateTime.Now}");
    }


    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.None)]
    [HttpGet("GetNoneDate")]
    public IActionResult GetNoneDate()
    {
        return Ok($"Response was generated at {DateTime.Now}");
    }
}
