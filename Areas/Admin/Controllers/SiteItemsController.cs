using FiringLineWebApp.Data;
using FiringLineWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiringLineWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SiteItemsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SiteItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _db.SiteItems
                .OrderByDescending(x => x.CreatedUtc)
                .ToListAsync();

            return View(items);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SiteItem item)
        {
            if (!ModelState.IsValid) return View(item);

            _db.SiteItems.Add(item);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.SiteItems.FindAsync(id);
            if (item != null)
            {
                _db.SiteItems.Remove(item);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
