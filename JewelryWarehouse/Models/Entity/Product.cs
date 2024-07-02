namespace JewelryWarehouse.Models.Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Inventory> Inventories { get; set; }
}