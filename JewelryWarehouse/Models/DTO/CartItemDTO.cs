using JewelryWarehouse.Models.Entity;

namespace JewelryWarehouse.Models.DTO;

public class CartItemDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice => ProductPrice * Quantity;
    public Product Product { get; set; }
}