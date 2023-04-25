using MagicVilla.Data;
using MagicVilla.Dtos;
using MagicVilla.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;

        public VillaAPIController(ILogger<VillaAPIController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult GetVillas()
        {
            _logger.LogInformation("Get All Villas");
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

            _logger.LogInformation($"Get Villa With ID {id}");

            return Ok( villa );
        }

        [HttpPost]
        public ActionResult CreateVilla([FromBody] VillaDto villa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(villa == null)
                return BadRequest(villa);

            villa.ID = VillaStore.villaList.Count()+1;

            Villa villaToInsert = new()
            {
                ID = villa.ID,
                Name = villa.Name,
                CreatedOn = DateTime.Now,
            };

            //VillaStore.villaList.Add(villaToInsert);
            VillaStore.villaList.Add(villa);
            return Ok(villaToInsert);
        }
        
        [HttpDelete("id")]
        public ActionResult DeleteVilla(int id)
        {
            if (id == null || id == 0)
                return BadRequest($"Enter a Valid ID");

            VillaDto villa = VillaStore.villaList.FirstOrDefault(v => v.ID == id);

            if (villa == null)
                return NotFound($"No Villa With ID {id}");

            VillaStore.villaList.Remove(villa); 
            return Ok(villa);
        }

        [HttpPut("id")]
        public ActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if (id == null || id == 0)
                return BadRequest("Please Enter a Valid ID");

            VillaDto villa = VillaStore.villaList.FirstOrDefault(v=>v.ID == id);

            if (villa == null)
                return NotFound($"No Villa With ID {id}");

            villa.Name = villaDto.Name;

            return Ok(villa);
        }

        [HttpPatch("id")]
        public ActionResult UpdateVillaUsingPath(int id,JsonPatchDocument<VillaDto> villaDto)
        {
            if (id == null || id == 0)
                return BadRequest("Please Enter a Valid ID");

            VillaDto villa = VillaStore.villaList.FirstOrDefault(v => v.ID == id);

            if (villa == null)
                return NotFound($"No Villa With ID {id}");

            villaDto.ApplyTo(villa,ModelState);

            return Ok(villa);
        }
    }

}
