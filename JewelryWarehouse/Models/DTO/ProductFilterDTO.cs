namespace JewelryWarehouse.Models.DTO;

public class ProductFilterDTO
{
    public string Name { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}