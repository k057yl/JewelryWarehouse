namespace JewelryWarehouse.Models.Entity;

public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public ICollection<Warehouse> Warehouses { get; set; }
}