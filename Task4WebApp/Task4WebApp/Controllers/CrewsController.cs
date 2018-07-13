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
    [Route("api/flights/Crews")]
    public class CrewsController : Controller
    {
		private readonly AirportService.AirportService airport;
		public CrewsController(AirportService.AirportService airportService)
		{
			this.airport = airportService;
		}
		// GET: api/Crews
		[HttpGet]
        public IActionResult Get()
        {
			try
			{
				var crews = this.airport.GetCrews();
				if (crews == null)
				{
					return NotFound();
				}
				return Ok(crews);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

        // GET: api/Crews/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
			try
			{
				var crew = this.airport.GetCrewById(id);
				if (crew == null)
				{
					return NotFound();
				}
				return Ok(crew);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // POST: api/Crews
        [HttpPost("{id}")]
        public IActionResult Post(int departId, [FromBody]CrewDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					airport.CreateCrew(departId, value);

					return Ok();
				}
				return BadRequest();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // PUT: api/Crews/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CrewDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					value.Id = id;
					//airport.UpdateCrew(value);

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
        public void Delete(int id)
        {
        }
    }
}
