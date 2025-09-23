using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;

public class CompanyController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}