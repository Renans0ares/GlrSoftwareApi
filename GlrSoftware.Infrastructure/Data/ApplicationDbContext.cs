using GlrSoftware.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlrSoftware.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Product> products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products"); // Nome da tabela no BD

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Name)
                .HasColumnName("name");

            entity.Property(e => e.Description)
                .HasColumnName("description");

            entity.Property(e => e.Price)
                .HasColumnName("price");

            entity.Property(e => e.StockQuantity)
                .HasColumnName("stock_quantity");

            entity.Property(e => e.CategoryId)
                .HasColumnName("category_id");

            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories"); // Nome da tabela no BD

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Name)
                .HasColumnName("name");

            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}
