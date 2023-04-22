using MagicVilla.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        public VillaAPIController() { }
        [HttpGet]
        public IEnumerable<VillaDto> GetVillas()
        {
            return new List<VillaDto>() { 
                new VillaDto{ID=1,Name = "Villa 1"},
                new VillaDto{ID=2,Name = "Villa 2"},
                
            };
        }
    }
}
