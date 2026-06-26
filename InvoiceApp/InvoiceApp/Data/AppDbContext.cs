using Microsoft.EntityFrameworkCore;
using InvoiceApp.Models;

namespace InvoiceApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Invoice> Invoices => Set<Invoice>();

    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>()
            .HasKey(i => i.InvoiceId);

        modelBuilder.Entity<InvoiceItem>()
            .HasKey(i => i.ItemId);

        modelBuilder.Entity<Invoice>()
            .HasMany(i => i.Items)
            .WithOne(i => i.Invoice)
            .HasForeignKey(i => i.InvoiceId);
    }
}