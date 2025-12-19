using AppAgency.ASP.Models;
using AppAgency.ASP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAgency.ASP.Controllers
{
    public class ActivityController : Controller
    {
        private IActivityService _service;

        public ActivityController(IActivityService service)
        {
            _service = service;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateActivityForm form)
        {
            if (!ModelState.IsValid)
                return View();
            var created = await _service.Insert(form);
            Console.WriteLine(created);
            return RedirectToAction("Details", "Destination", new { id = form.DestinationId });
        }
    }
}
