using System.Diagnostics;
using Cars_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars_WebAPI.Data; 

namespace Cars_WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> CarsOwners()
        {
            var carsWithOwners = await _context.Cars
                .Include(c => c.Owner)
                .Select(c => new CarOwnerViewModel
                {
                    CarBrand = c.Brand,
                    CarModel = c.Model,
                    CarPrice = c.Price,
                    OwnerFullName = c.Owner.FullName,
                    OwnerEmail = c.Owner.Email
                }).ToListAsync();

            return View(carsWithOwners);
        }
    }
}
