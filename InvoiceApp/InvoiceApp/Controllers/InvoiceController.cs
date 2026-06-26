using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {
            var invoice = new
            {
                invoiceNo = "INV-1001",
                customer = "John Doe",
                date = "26-Jun-2026",
                total = 39.98,
                items = new[]
                {
                    new
                    {
                        name = "Widget A",
                        price = 19.99
                    },
                    new
                    {
                        name = "Widget B",
                        price = 19.99
                    }
                }
            };

            return Ok(invoice);
        }
    }
}