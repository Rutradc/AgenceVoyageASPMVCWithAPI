using AppAgency.ASP.Entities;
using AppAgency.ASP.Mapper;
using AppAgency.ASP.Models;
using AppAgency.ASP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAgency.ASP.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _service;

        public DestinationController(IDestinationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Destination> destinations = await _service.GetAll();
            return View(destinations.Select(d => d.ToDisplay()));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Destination destination = await _service.GetById(id);
            if (destination is null)
                return NotFound();
            return View(destination.ToDisplay());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDestinationForm form)
        {
            if (!ModelState.IsValid)
                return View();
            var created = await _service.Insert(form);
            Console.WriteLine(created);
            return RedirectToAction(nameof(Index));
        }
    }
}
