using Microsoft.AspNetCore.Mvc;


namespace product_management_system.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
