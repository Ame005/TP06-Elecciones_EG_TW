using Microsoft.AspNetCore.Mvc;

namespace TP06Elecciones_Gayoso_TorreWalsh.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
