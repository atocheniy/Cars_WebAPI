using Cars_WebAPI.Data;
using Cars_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_WebAPI.API
{
    //public class CarsController : Controller
    //{
    //    private readonly ApplicationDbContext _context;

    //    public CarsController(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Cars
    //    public async Task<IActionResult> Index()
    //    {
    //        var applicationDbContext = _context.Cars.Include(c => c.Owner);
    //        return View(await applicationDbContext.ToListAsync());
    //    }

    //    // GET: Cars/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var car = await _context.Cars
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (car == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(car);
    //    }

    //    // GET: Cars/Create
    //    [Authorize]
    //    public IActionResult Create()
    //    {
    //        ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FullName");
    //        return View();
    //    }

    //    // POST: Cars/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    [Authorize]
    //    public async Task<IActionResult> Create([Bind("Id,Brand,Model,Speed,Price,Data,Weight,OwnerId")] Car car)
    //    {
    //        ModelState.Remove("Owner");

    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(car);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }

    //        ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FullName");
    //        return View(car);
    //    }

    //    // GET: Cars/Edit/5
    //    [Authorize]
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var car = await _context.Cars.FindAsync(id);
    //        if (car == null)
    //        {
    //            return NotFound();
    //        }

    //        ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FullName", car.OwnerId);
    //        return View(car);
    //    }

    //    // POST: Cars/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    [Authorize]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Speed,Price,Data,Weight,OwnerId")] Car car)
    //    {
    //        ModelState.Remove("Owner");

    //        if (id != car.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(car);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!CarExists(car.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }

    //        ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FullName", car.OwnerId);
    //        return View(car);
    //    }

    //    // GET: Cars/Delete/5
    //    [Authorize]
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var car = await _context.Cars
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (car == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(car);
    //    }

    //    // POST: Cars/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    [Authorize]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var car = await _context.Cars.FindAsync(id);
    //        if (car != null)
    //        {
    //            _context.Cars.Remove(car);
    //        }

    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool CarExists(int id)
    //    {
    //        return _context.Cars.Any(e => e.Id == id);
    //    }
    //}
}
