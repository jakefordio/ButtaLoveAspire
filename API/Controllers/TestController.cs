using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("errors")]
    public ActionResult GetErrorResponses(int code)
    {
        ModelState.AddModelError("Problem one", "Validation problem one");
        ModelState.AddModelError("Problem two", "Validation problem two");

        return code switch
        {
            400 => BadRequest("Opposite of good request"),
            401 => Unauthorized(),
            403 => Forbid(),
            404 => NotFound(),
            500 => throw new Exception("Internal Server Error"),
            _ => ValidationProblem(ModelState)
        };
    }
    
    [Authorize]
    [HttpGet("auth")]
    public ActionResult TestAuth()
    {
        string? user = User.FindFirstValue("name");
        
        return Ok($"{user} has been authorized");
    }
}