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
    [Route("api/Stewardesses")]
    public class StewardessesController : Controller
    {
		private readonly AirportService.AirportService airport;

		public StewardessesController(AirportService.AirportService service)
		{
			this.airport = service;

		}

		// GET: api/Stewardesses
		[HttpGet]
        public IActionResult Get()
        {
			try
			{
				var result = airport.GetStewardesses();
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

        // GET: api/Stewardesses/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			try
			{
				var stewardess = this.airport.GetStewardessById(id);
				if (stewardess == null)
				{
					return NotFound();
				}
				return Ok(stewardess);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // POST: api/Stewardesses
        [HttpPost]
        public IActionResult Post([FromBody]StewardessDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					airport.CreateStewardess(value);

					return Ok();
				}
				return BadRequest();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // PUT: api/Stewardesses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StewardessDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					value.Id = id;
					airport.UpdateStewardess(value);

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
				airport.DeleteStewardess(id);
				return Ok();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
    }
}
