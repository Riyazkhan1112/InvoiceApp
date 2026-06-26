using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    [HttpGet]
    public IActionResult GetInvoice()
    {
        var invoice = new
        {
            invoiceId = 1,
            customerName = "John Doe",
            items = new[]
            {
                new
                {
                    itemId = 1,
                    name = "Widget A",
                    price = 19.99
                }
            }
        };

        return Ok(invoice);
    }
}