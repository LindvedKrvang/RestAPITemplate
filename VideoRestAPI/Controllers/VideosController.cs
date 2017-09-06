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
        public IEnumerable<VideoBO> Get()
        {
            return _facade.VideoService.GetAll();
        }

        // GET: api/Videos/5
        [HttpGet("{id}", Name = "Get")]
        public VideoBO Get(int id)
        {
            return _facade.VideoService.GetOne(id);
        }
        
        // POST: api/Videos
        [HttpPost]
        public void Post([FromBody]VideoBO video)
        {
            _facade.VideoService.Create(video);
        }
        
        // PUT: api/Videos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]VideoBO video)
        {
            _facade.VideoService.Update(video);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _facade.VideoService.Delete(id);
        }
    }
}
