using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Bai2()
        {
            var sanpham = new SanPhamViewModel
            {
                TenSanPham = "Tên sản phẩm",
                GiaBan = 1000000M,  // Ví dụ giá bán là 1.000.000 VND
                AnhMoTa = "~/about-img.png"  // URL của ảnh mô tả
            };

            return View(sanpham);
        }
    }
}
