namespace InvoiceApp.Models;

public class InvoiceItem
{
    public int ItemId { get; set; }

    public int InvoiceId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public Invoice Invoice { get; set; }
}