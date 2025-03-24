using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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
}
