using Microsoft.AspNetCore.Mvc;

public class TicketController : Controller
{
    private readonly TicketService _ticketService;

    private readonly HttpClient _httpClient;

    // Injecte TicketService dans le contrôleur
    public TicketController(TicketService ticketService,HttpClient httpClient)
    {
        _ticketService = ticketService;
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        return View(tickets);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteTicket(int ticketId)
    {
        var url = $"http://localhost:8080/api/delete_ticket/{ticketId}";
         Console.WriteLine("ici");
        try
        {
            var response = await _httpClient.DeleteAsync(url);
            Console.WriteLine("reponse ticket : " + response);
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Ticket supprimé avec succès !";
                return Redirect("http://localhost:5077/Dashboard");
            }
            else
            {
                TempData["Error"] = "Erreur lors de la suppression du ticket.";
                return RedirectToAction("Error");
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Exception : {ex.Message}";
            return RedirectToAction("Error");
        }
    }

    // Affichage du formulaire
    [HttpGet]
    public IActionResult Edit(int id)
    {
        return View(model: id); // on passe juste l'id à la vue
    }

// Traitement du formulaire
    [HttpPost]
    public async Task<IActionResult> Edit(int ticketId, decimal montant)
    {
        var url = $"http://localhost:8080/api/update_ticket_montant?id={ticketId}&montant={montant}";

        try
        {
            var response = await _httpClient.PutAsync(url, null);
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Montant du ticket mis à jour avec succès.";
                return Redirect("http://localhost:5077/Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Erreur lors de la mise à jour du ticket.");
                return View(ticketId);
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erreur : {ex.Message}");
            return View(ticketId);
        }
    }


}
