using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

public class DashboardController : Controller
{
    private readonly DashboardService _dashboardService;

    public DashboardController(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public async Task<IActionResult> Index()
    {
        var totalCount = await _dashboardService.GetTotalCountsAsync();
        var clientStats = await _dashboardService.GetClientStatsAsync(); // appel vers l'API Java
        var ticketStatusCounts = await _dashboardService.GetTicketStatusCountsAsync(); 
        var leadStatusCounts = await _dashboardService.GetLeadStatusCountsAsync(); 


        var viewModel = new DashboardViewModel
        {
            TotalCount = totalCount,
            ClientStats = clientStats,
            TicketStatusCounts = ticketStatusCounts,
            LeadStatusCounts = leadStatusCounts
        };

        return View(viewModel);
    }
}
