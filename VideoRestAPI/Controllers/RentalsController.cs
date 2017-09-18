using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Rentals")]
    public class RentalsController : Controller
    {
        private readonly BllFacade _facade = new BllFacade();
        // GET: api/Rentals
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_facade.RentalService.GetAll());
            }
            catch (Exception)
            {
                return BadRequest("Couldn't get all rentals...");
            }
        }

        // GET: api/Rentals/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_facade.RentalService.GetOne(id));
            }
            catch (Exception)
            {
                return BadRequest($"Couldn't get the rental with the id {id}.");
            }
        }
        
        // POST: api/Rentals
        [HttpPost]
        public IActionResult Post([FromBody]RentalBO rental)
        {
            try
            {
                return Ok(_facade.RentalService.Create(rental));
            }
            catch (Exception)
            {
                return BadRequest($"Couldn't create the rental with the id {rental.Id}.");
            }
        }
        
        // PUT: api/Rentals/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RentalBO rental)
        {
            try
            {
                return Ok(_facade.RentalService.Update(rental));
            }
            catch (Exception)
            {
                return BadRequest($"Couldn't update the rental with the id {rental.Id}.");
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_facade.RentalService.Delete(id));
            }
            catch (Exception)
            {
                return BadRequest($"Couldn't delete the rental with the id {id}.");
            }
        }
    }
}
