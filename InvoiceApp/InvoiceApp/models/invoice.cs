namespace InvoiceApp.Models;

public class Invoice
{
    public int InvoiceId { get; set; }

    public string CustomerName { get; set; }

    public List<InvoiceItem> Items { get; set; }
}