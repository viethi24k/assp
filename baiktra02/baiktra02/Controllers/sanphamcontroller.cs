using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baiktra02.Data;
using baiktra02.Models;

namespace baiktra02.Controllers
{
    [Area("Admin")]
    public class sanphamcontroller : Controller
    {
        private readonly ApplicationDbContext _db;
        public sanphamcontroller(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.sanPham.Include("theloai").ToList();
            return View();
        }
    }
}
