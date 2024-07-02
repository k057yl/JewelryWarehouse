using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JewelryWarehouse.Data;
using Microsoft.Extensions.Localization;

namespace JewelryWarehouse.Controllers
{
    public class ProductController : BaseController<ProductController>
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context, IStringLocalizer<ProductController> localizer)
            : base(localizer)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            var products = from p in _context.Products.Include(p => p.Categories)
                select p;

            switch (sortOrder)
            {
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "price_asc":
                    products = products.OrderBy(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            SetViewData();
            return View(await products.AsNoTracking().ToListAsync());
        }
    }
}