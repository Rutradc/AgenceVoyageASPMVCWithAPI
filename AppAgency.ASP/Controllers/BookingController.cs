using AppAgency.ASP.Entities;
using AppAgency.ASP.Mapper;
using AppAgency.ASP.Models;
using AppAgency.ASP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAgency.ASP.Controllers
{
    public class BookingController : Controller
    {
        public IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Booking> bookings = await _service.GetAll();
            return View(bookings.Select(b => b.ToDisplay()));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingForm form)
        {
            if (!ModelState.IsValid)
                return View();
            var created = await _service.Insert(form);
            Console.WriteLine(created);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
