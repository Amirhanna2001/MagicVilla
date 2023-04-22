using MagicVilla.Data;
using MagicVilla.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        public VillaAPIController() { }
        [HttpGet]
        public ActionResult GetVillas()
        {
            return Ok( VillaStore.villaList);
        }

        [HttpGet("id")]
        public ActionResult GetVilla(int id)
        {
            if(id == null || id ==  0)
                return BadRequest();

            VillaDto villa = VillaStore.villaList.FirstOrDefault(v => v.ID == id);
            if(villa == null) 
                return NotFound($"No Villa With ID = {id}");

            return Ok( villa );
        }
    }

}
