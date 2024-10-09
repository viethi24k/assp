using Microsoft.AspNetCore.Mvc;

namespace BaiKiemtra03_04.Models
{
    public class Order : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
