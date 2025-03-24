using Microsoft.AspNetCore.Mvc;

public class TicketController : Controller
{
    private readonly TicketService _ticketService;

    // Injecte TicketService dans le contrôleur
    public TicketController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public async Task<IActionResult> Index()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        return View(tickets);
    }
}
