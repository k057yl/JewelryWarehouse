using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace JewelryWarehouse.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(IStringLocalizer<HomeController> localizer) : base(localizer)
        {
        }

        public IActionResult Index()
        {
            SetViewData();
            return View();
        }

        public IActionResult Privacy()
        {
            SetViewData();
            return View();
        }
    }
}