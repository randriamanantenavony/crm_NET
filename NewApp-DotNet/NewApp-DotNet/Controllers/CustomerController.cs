public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Index()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return View(customers);
    }
}
