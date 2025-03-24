using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<HomeController> _logger;

    public AuthController(HttpClient httpClient, ILogger<HomeController> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

   [HttpPost("login")]
public async Task<IActionResult> Login([FromForm] LoginRequest loginRequest)
{
    // URL de votre API Spring Boot
    string apiUrl = "http://localhost:8080/api/authenticate";

    // Préparer les données à envoyer
    var formData = new MultipartFormDataContent
    {
        { new StringContent(loginRequest.Email), "email" },
        { new StringContent(loginRequest.Password), "password" }
    };

    // Envoyer la requête POST à l'API Spring Boot
    var response = await _httpClient.PostAsync(apiUrl, formData);

    // Vérifier si la requête a réussi
    if (response.IsSuccessStatusCode)
    {
        // Lire la réponse JSON
        var jsonResponse = await response.Content.ReadAsStringAsync();

        // Imprimer le JSON dans la console ou les logs
        Console.WriteLine("Réponse JSON de l'API : " + jsonResponse);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var user = JsonSerializer.Deserialize<User>(jsonResponse, options);

        Console.WriteLine("tu es dans le if");
        // Rediriger vers la page Dashboard en cas de succès
        return RedirectToAction("Index","Dashboard");
    }

    else
    {
        Console.WriteLine("else");
        // Rediriger vers la page d'index avec un message d'erreur en cas d'échec
        TempData["ErrorMessage"] = "Erreur lors de l'authentification. Veuillez vérifier vos identifiants.";
        return RedirectToAction("Index", "Home");
    }
}

}