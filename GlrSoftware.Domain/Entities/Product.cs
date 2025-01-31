namespace GlrSoftware.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }  // Chave estrangeira
    public Category? Category { get; set; } // Propriedade de navegação
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
