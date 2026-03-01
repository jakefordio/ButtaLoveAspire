using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ButtaLoveViewModel vm = new();
        return View(vm);
    }
}