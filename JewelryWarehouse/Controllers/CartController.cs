using JewelryWarehouse.Data;
using JewelryWarehouse.Models.DTO;
using JewelryWarehouse.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace JewelryWarehouse.Controllers;

public class CartController : BaseController<HomeController>
{
    private readonly AppDbContext _context;
    private readonly Cart _cart;

    public CartController(AppDbContext context, Cart cart, IStringLocalizer<HomeController> localizer) : base(localizer)
    {
        _context = context;
        _cart = cart;
    }

    public IActionResult Index()
    {
        var cartItems = _cart.Items.Select(item => new CartItemDTO
        {
            ProductId = item.ProductId,
            ProductName = item.Product.Name,
            ProductPrice = item.Product.Price,
            Quantity = item.Quantity
        }).ToList();

        SetViewData();
        return View(cartItems);
    }

    public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
    {
        var product = await _context.Products.FindAsync(productId);

        if (product != null)
        {
            _cart.AddItem(product, quantity);
        }

        return RedirectToAction("Index", "Product");
    }

    public IActionResult RemoveFromCart(int productId)
    {
        _cart.RemoveItem(productId);
        return RedirectToAction("Index");
    }

    public IActionResult ClearCart()
    {
        _cart.Clear();
        return RedirectToAction("Index");
    }
}