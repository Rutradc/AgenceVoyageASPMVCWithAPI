using AppAgency.API.Dto;
using AppAgency.API.Handlers;
using AppAgency.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_bookingService.GetAll());
        [HttpPost]
        public IActionResult Create([FromBody] BookingCreateDto dto)
        {
            var created = _bookingService.Create(dto.ToEntity(), dto.ActivitiesIds);
            return CreatedAtAction(nameof(Create), new { id = created.Id }, created);
        }
    }
}
