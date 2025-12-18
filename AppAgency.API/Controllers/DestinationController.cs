using AppAgency.API.Dto;
using AppAgency.API.Handlers;
using AppAgency.BLL.Services.Interfaces;
using AppAgency.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace AppAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_destinationService.GetAll());

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Destination destination = _destinationService.Get(id);
            if (destination == null)
                return NotFound();
            return Ok(destination);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DestinationCreateDto dto)
        {
            var created = _destinationService.Create(dto.ToEntity());
            return CreatedAtAction(nameof(Create), new { id = created.Id }, created);   
        }
    }
}
