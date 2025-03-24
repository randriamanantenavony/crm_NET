using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class LeadController : Controller
{
    private readonly LeadService _leadService;

    public LeadController(LeadService leadService)
    {
        _leadService = leadService;
    }

    public async Task<IActionResult> Index()
    {
        var leads = await _leadService.GetAllLeadsAsync();
        return View(leads);
    }
}
