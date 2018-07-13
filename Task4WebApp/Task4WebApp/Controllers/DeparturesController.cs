
using DTOLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Task4WebApp.Controllers
{
	[Produces("application/json")]
	[Route("api/departures")]
	public class DeparturesController : Controller
	{
		private readonly AirportService.AirportService airport;
		public DeparturesController(AirportService.AirportService airportService)
		{
			this.airport = airportService;
		}
		// GET: api/Departures
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var departures = this.airport.GetDepartures();
				if (departures == null)
				{
					return NotFound();
				}
				return Ok(departures);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}

		}

		// GET: api/Departures/5 {, Name = "Get"}
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				var departure = this.airport.GetDepartureById(id);
				if (departure == null)
				{
					return NotFound();
				}
				return Ok(departure);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// POST: api/Departures
		[HttpPost]
		public IActionResult Post([FromBody]DepartureDTO value)
		{
			try
			{
				if (ModelState.IsValid)
				{
					airport.CreateDeparture(value);

					return Ok();
				}
				return BadRequest();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// PUT: api/Departures/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]DepartureDTO value)
		{
			try
			{
				if (ModelState.IsValid)
				{
					value.Id = id;
					airport.UpdateDeparture(value);

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
				airport.DeleteDeparture(id);
				return Ok();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
