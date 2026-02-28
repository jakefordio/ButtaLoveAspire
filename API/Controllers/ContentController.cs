using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
public class ContentController : Controller // Inherit from Controller, not ControllerBase
{
    [HttpGet("{pageHash}")]
    public IActionResult GetPagePartial(string? pageHash)
    {
        return PartialView($"_{pageHash}");
    }
}