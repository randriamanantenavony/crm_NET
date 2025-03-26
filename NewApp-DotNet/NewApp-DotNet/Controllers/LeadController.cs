using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;


public class LeadController : Controller
{
    private readonly LeadService _leadService;
    private readonly HttpClient _httpClient;
    public LeadController(LeadService leadService,IHttpClientFactory httpClientFactory)
    {
        _leadService = leadService;
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<IActionResult> Index()
    {
        var leads = await _leadService.GetAllLeadsAsync();
        return View(leads);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteLead(int leadId)
    {
        var url = $"http://localhost:8080/api/delete_lead/{leadId}";

        Console.WriteLine("coucou");
        try
        {
            var response = await _httpClient.GetAsync(url); // Appel GET vers Spring
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Lead supprimé avec succès !";
                return Redirect("http://localhost:5077/Dashboard");
            }
            else
            {
                TempData["Error"] = "Erreur lors de la suppression du lead.";
                return RedirectToAction("Error");
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Exception : {ex.Message}";
            return RedirectToAction("Error");
        }
    }

     [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.LeadId = id;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateLeadMontant(IFormCollection form)
    {
        var leadId = form["leadId"];
        var montant = form["montant"];

        var url = $"http://localhost:8080/api/update/lead/{leadId}?montant={montant}";

        var response = await _httpClient.PutAsync(url, null);


        if (response.IsSuccessStatusCode)
        {
            TempData["Success"] = "Montant mis à jour avec succès !";
            return RedirectToAction("Index","Dashboard");        }

        TempData["Error"] = "Erreur lors de la mise à jour du montant.";
        return RedirectToAction("Edit", new { id = leadId });
    }

}
