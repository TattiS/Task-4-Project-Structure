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
    [Route("api/PlaneTypes")]
    public class PlaneTypesController : Controller
    {
		private readonly AirportService.AirportService airport;

		public PlaneTypesController(AirportService.AirportService service)
		{
			this.airport = service;

		}

		// GET: api/PlaneTypes
		[HttpGet]
        public IActionResult Get()
        {
			try
			{
				var result = airport.GetPlaneTypes();
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

        // GET: api/PlaneTypes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			try
			{
				var type = this.airport.GetPlaneTypeById(id);
				if (type == null)
				{
					return NotFound();
				}
				return Ok(type);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // POST: api/PlaneTypes
        [HttpPost]
        public IActionResult Post([FromBody]PlaneTypeDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					airport.CreatePlaneType(value);

					return Ok();
				}
				return BadRequest(ModelState);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
        
        // PUT: api/PlaneTypes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PlaneTypeDTO value)
        {
			try
			{
				if (ModelState.IsValid)
				{
					value.Id = id;
					airport.UpdateType(value);

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
				airport.DeletePlaneType(id);
				return Ok();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
    }
}
