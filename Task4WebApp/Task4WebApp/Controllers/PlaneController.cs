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
    [Route("api/Planes")]
    public class PlaneController : Controller
    {
		private readonly AirportService.AirportService airport;

		public PlaneController(AirportService.AirportService service)
		{
			this.airport = service;

		}

		// GET: api/Plane
		[HttpGet]
        public IActionResult Get()
        {
			try
			{
				var result = airport.GetPlanes();
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

        // GET: api/Plane/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			try
			{
				var plane = this.airport.GetPlaneById(id);
				if (plane == null)
				{
					return NotFound();
				}
				return Ok(plane);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // POST: api/Plane
        [HttpPost("departure-id/{id}")]
        public IActionResult Post(int departId,[FromBody]PlaneDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					airport.CreatePlane(departId,value);

					return Ok();
				}
				return BadRequest(ModelState);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // PUT: api/Plane/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PlaneDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					value.Id = id;
					airport.UpdatePlane(value);

					return Ok();
				}
				return BadRequest(ModelState);
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
				airport.DeletePlane(id);
				return Ok();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
    }
}
