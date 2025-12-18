using AppAgency.API.Dto;
using AppAgency.API.Handlers;
using AppAgency.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _service;

        public ActivityController(IActivityService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult Create([FromBody] ActivityCreateDto dto)
        {
            var created = _service.Insert(dto.ToEntity());
            return CreatedAtAction(nameof(Create), new { id = created.Id }, created);
        }
    }
}
