using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Afficher les valeurs dans la console
        _logger.LogInformation($"Username: {username}, Password: {password}");

        // Rediriger vers la page d'accueil (ou une autre page)
        return RedirectToAction("Index");
    }
}