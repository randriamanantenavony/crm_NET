using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class CustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Customer>>("http://localhost:8080/api/all-customers");
        return response ?? new List<Customer>();
    }
}
