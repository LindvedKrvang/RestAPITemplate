using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;

namespace VideoRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly BllFacade _facade = new BllFacade();

        // GET: api/User
        //[Authorize]
        [HttpGet]
        public IEnumerable<UserBO> Get() {
            return _facade.UserService.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUsers")]
        public UserBO Get(int id) {
            return _facade.UserService.GetOne(id);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody]UserBO users) {
            _facade.UserService.Create(users);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UserBO user) {
            _facade.UserService.Update(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            _facade.UserService.Delete(id);
        }
    }
}
