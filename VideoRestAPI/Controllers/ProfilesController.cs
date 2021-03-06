﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;

namespace VideoRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Profiles")]
    public class ProfilesController : Controller
    {

        private readonly BllFacade _facade = new BllFacade();

        // GET: api/Profiles
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_facade.ProfileService.GetAll());
            }
            catch (Exception)
            {
                return BadRequest($"Couldn't get all profiles!");
            }
        }

        // GET: api/Profiles/5
        [HttpGet("{id}", Name = "GetProfiles")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_facade.ProfileService.GetOne(id));
            }
            catch (Exception)
            {
                return BadRequest($"Couldn't get the profile with the Id: {id}!");
            }
        }
        
        // POST: api/Profiles
        [HttpPost]
        public IActionResult Post([FromBody]ProfileBO profile)
        {
            return StatusCode(403, "Can't create a profile without a user. Create a new user to create a new profile.");
        }
        
        // PUT: api/Profiles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProfileBO profile)
        {
            if (id != profile.Id) return StatusCode(404, "Id does not match profile Id!");
            try
            {
                return Ok(_facade.ProfileService.Update(profile));
            }
            catch (Exception)
            {
                return BadRequest($"Couldn't update the profile!");
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(403,
                "Can't directly delete a profile. Delete the User accossiated with the profile to delete the profile.");
        }
    }
}
