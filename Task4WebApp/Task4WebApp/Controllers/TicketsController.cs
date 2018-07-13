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
    [Route("api/Tickets")]
    public class TicketsController : Controller
    {
		private readonly AirportService.AirportService airport;

		public TicketsController(AirportService.AirportService service)
		{
			this.airport = service;

		}

		// GET: api/Tickets
		[HttpGet]
        public IActionResult Get()
        {
			try
			{
				var result = airport.GetTickets();
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

        // GET: api/Tickets/5
        [HttpGet("flight-id/{id}")]
        public IActionResult Get(int id)
        {
			try
			{
				var ticket = this.airport.GetTicketsByFlightId(id);
				if (ticket == null)
				{
					return NotFound();
				}
				return Ok(ticket);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // POST: api/Tickets
        [HttpPost]
        public IActionResult Post([FromBody]TicketDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					airport.CreateTicket(value.FlightId, value);

					return Ok();
				}
				return BadRequest();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TicketDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					value.Id = id;
					airport.UpdateTicket(value);

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
				airport.DeleteTicket(id);
				return Ok();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
    }
}
