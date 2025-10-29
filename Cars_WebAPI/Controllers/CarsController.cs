using Cars_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cars_WebAPI.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarsController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: CarsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var car = await _context.Cars.Include(c => c.Owner).FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();
            return View(car);
        }

        // GET: CarsController/Create
        public async Task<IActionResult> Create()
        {
            ViewData["OwnerId"] = new SelectList(await _context.Owners.ToListAsync(), "Id", "FullName");
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Edit/5
        // [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();
            ViewData["OwnerId"] = new SelectList(await _context.Owners.ToListAsync(), "Id", "FullName", car.OwnerId);
            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();
            var car = await _context.Cars.Include(c => c.Owner).FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();
            return View(car);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
