using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class DashboardService
{
    private readonly HttpClient _httpClient;

    public DashboardService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TotalCount> GetTotalCountsAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:8080/api/total-count/getAll");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var counts = JsonSerializer.Deserialize<TotalCount>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return counts;
    }

    public async Task<List<ClientStat>> GetClientStatsAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:8080/api/client-stats");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ClientStat>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        return new List<ClientStat>();
    }

      public async Task<List<TicketStatusCountViewModel>> GetTicketStatusCountsAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:8080/api/ticket-status/all");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine("contenu" + content);

        var ticketStatusCounts = JsonSerializer.Deserialize<List<TicketStatusCountViewModel>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return ticketStatusCounts;
    }

      public async Task<List<LeadStatusCountViewModel>> GetLeadStatusCountsAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:8080/api/lead-status/all");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine("contenu" + content);

        var ticketStatusCounts = JsonSerializer.Deserialize<List<LeadStatusCountViewModel>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return ticketStatusCounts;
    }

}
