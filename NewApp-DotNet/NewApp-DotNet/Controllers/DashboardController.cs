using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class DashboardController : Controller
{
    private readonly DashboardService _dashboardService;

    public DashboardController(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public async Task<IActionResult> Index()
    {
        var counts = await _dashboardService.GetTotalCountsAsync();
        return View(counts);
    }
}


