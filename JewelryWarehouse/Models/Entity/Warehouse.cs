namespace JewelryWarehouse.Models.Entity;

public class Warehouse
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public Shop Shop { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<Inventory> Inventories { get; set; }
}