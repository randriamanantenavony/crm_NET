using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class LeadService
{
    private readonly HttpClient _httpClient;

    public LeadService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Lead>> GetAllLeadsAsync()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:8080/api/all-leads");
        var leads = JsonConvert.DeserializeObject<List<Lead>>(response);
        return leads;
    }
}
