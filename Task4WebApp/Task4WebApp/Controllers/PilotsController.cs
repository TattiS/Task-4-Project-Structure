using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOLibrary.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task4WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Pilots")]
    public class PilotsController : Controller
    {
		private readonly AirportService.AirportService airport;

		public PilotsController(AirportService.AirportService service)
		{
			this.airport = service;

		}

		// GET: api/Pilots
		[HttpGet]
        public IActionResult Get()
        {
			try
			{
				var result = airport.GetPilots();
				if (result == null)
				{
					return NotFound();
				}
				return Ok(result);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

        // GET: api/Pilots/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			try
			{
				var pilot = this.airport.GetPilotById(id);
				if (pilot == null)
				{
					return NotFound();
				}
				return Ok(pilot);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // POST: api/Pilots
        [HttpPost]
        public IActionResult Post([FromBody]PilotDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					airport.CreatePilot(value);

					return Ok();
				}
				return BadRequest();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // PUT: api/Pilots/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PilotDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					value.Id = id;
					airport.UpdatePilot(value);

					return Ok();
				}
				return BadRequest();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			try
			{
				airport.DeletePilot(id);
				return Ok();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
    }
}
