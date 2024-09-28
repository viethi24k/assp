

using baiktra02.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Area("Admin")]
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.theloai.ToList();
            ViewBag.TheLoai = theloai;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Theloai theloai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.theloai.Add(theloai);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.theloai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult Edit(Theloai theloai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.theloai.Update(theloai);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.theloai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.theloai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.theloai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}