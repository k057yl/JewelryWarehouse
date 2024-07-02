using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JewelryWarehouse.Data;
using Microsoft.Extensions.Localization;

namespace JewelryWarehouse.Controllers
{
    public class ShopController : BaseController<ShopController>
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context, IStringLocalizer<ShopController> localizer)
            : base(localizer)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var shops = await _context.Shops.Include(s => s.Address).ToListAsync();

            SetViewData();
            return View(shops);
        }
    }
}