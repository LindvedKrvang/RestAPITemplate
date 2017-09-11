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
    [Route("api/Videos")]
    public class VideosController : Controller
    {

        private readonly BllFacade _facade = new BllFacade();

        // GET: api/Videos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_facade.VideoService.GetAll());
        }

        // GET: api/Videos/5
        [HttpGet("{id}", Name = "GetVideos")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_facade.VideoService.GetOne(id));
            }
            catch (Exception e)
            {
                return BadRequest($"Couldn't delete the video with the Id: {id}!");
            }
        }
        
        // POST: api/Videos
        [HttpPost]
        public IActionResult Post([FromBody]VideoBO video)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(_facade.VideoService.Create(video));
        }
        
        // PUT: api/Videos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]VideoBO video)
        {
            if (id != video.Id) return StatusCode(404, "Id does not match video Id!");

            try
            {
                return Ok(_facade.VideoService.Update(video));
            }
            catch (Exception e)
            {
                return BadRequest($"Couldn't update the video!");
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_facade.VideoService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest($"Couldn't delete the video with the Id: {id}!");
            }
        }
    }
}
