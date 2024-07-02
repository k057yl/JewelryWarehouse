using JewelryWarehouse.Models.DTO;

namespace JewelryWarehouse.Models.Entity;

public class Cart
{
    private readonly List<CartItemDTO> _items = new List<CartItemDTO>();

    public IEnumerable<CartItemDTO> Items => _items;

    public void AddItem(Product product, int quantity)
    {
        var cartItem = _items.FirstOrDefault(i => i.ProductId == product.Id);

        if (cartItem == null)
        {
            _items.Add(new CartItemDTO { Product = product, Quantity = quantity });
        }
        else
        {
            cartItem.Quantity += quantity;
        }
    }

    public void RemoveItem(int productId)
    {
        var cartItem = _items.FirstOrDefault(i => i.ProductId == productId);

        if (cartItem != null)
        {
            _items.Remove(cartItem);
        }
    }

    public void Clear()
    {
        _items.Clear();
    }
}