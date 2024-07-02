namespace JewelryWarehouse.Models.DTO;

public class InventoryDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int Quantity { get; set; }
}