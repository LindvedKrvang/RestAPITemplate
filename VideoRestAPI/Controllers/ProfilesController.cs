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
    [Route("api/Profiles")]
    public class ProfilesController : Controller
    {

        private readonly BllFacade _facade = new BllFacade();

        // GET: api/Profiles
        [HttpGet]
        public IEnumerable<ProfileBO> Get()
        {
            return _facade.ProfileService.GetAll();
        }

        // GET: api/Profiles/5
        [HttpGet("{id}", Name = "GetProfiles")]
        public ProfileBO Get(int id)
        {
            return _facade.ProfileService.GetOne(id);
        }
        
        // POST: api/Profiles
        [HttpPost]
        public void Post([FromBody]ProfileBO profile)
        {
            _facade.ProfileService.Create(profile);
        }
        
        // PUT: api/Profiles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProfileBO profile)
        {
            _facade.ProfileService.Update(profile);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _facade.ProfileService.Delete(id);
        }
    }
}
