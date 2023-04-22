using MagicVilla.Data;
using MagicVilla.Dtos;
using MagicVilla.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
    }

}
