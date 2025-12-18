using AppAgency.ASP.Entities;
using AppAgency.ASP.Mapper;
using AppAgency.ASP.Models;
using AppAgency.ASP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAgency.ASP.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Destination> destinations = await _destinationService.GetAll();
            return View(destinations.Select(d => d.ToDisplay()));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDestinationForm form)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var created = await _destinationService.Insert(form);
            Console.WriteLine(created);
            return RedirectToAction(nameof(Index));
        }
    }
}
