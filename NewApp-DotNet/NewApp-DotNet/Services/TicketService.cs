using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

public class TicketService
{
    private readonly HttpClient _httpClient;

    // Injecte HttpClient dans le service
    public TicketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Fonction pour récupérer les tickets depuis l'API
    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        try
        {
            // Appel API pour récupérer les tickets
            var response = await _httpClient.GetStringAsync("http://localhost:8080/api/all-tickets");

            // Désérialise la réponse JSON en une liste d'objets Ticket
            var tickets = JsonConvert.DeserializeObject<List<Ticket>>(response);

            return tickets;
        }
        catch (Exception ex)
        {
            // Gestion d'erreur (par exemple, loguer ou retourner une réponse vide en cas d'erreur)
            Console.WriteLine($"Erreur lors de la récupération des tickets : {ex.Message}");
            return new List<Ticket>();
        }
    }
}
