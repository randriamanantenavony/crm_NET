using Microsoft.AspNetCore.Mvc;

public class GlobalSettingsController : Controller
{
    private readonly HttpClient _httpClient;

    public GlobalSettingsController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }
    
    
    [HttpGet]
    public IActionResult Create() => View();

     [HttpPost]
    public async Task<IActionResult> Create(GlobalSettingsModel model)
    {
        Console.WriteLine("Model.AlertThreshold: " + model.AlertThreshold);
        // Appel vers le backend Spring Boot
        var url = $"http://localhost:8080/api/settings/update?threshold={model.AlertThreshold}";

        try
        {
            Console.WriteLine("URL: " + url);
            var response = await _httpClient.PutAsync(url, null); // PUT sans body
             Console.WriteLine("Response: " + response);
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Seuil mis à jour avec succès !";
                return RedirectToAction("Success");
            }
            else
            {
                ModelState.AddModelError("", "Erreur lors de la mise à jour du seuil.");
                return View(model);
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erreur : {ex.Message}");
            return View(model);
        }
    }

    public IActionResult Success()
    {
        ViewBag.Message = TempData["Success"];
        return View();
    }

}
