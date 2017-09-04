﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoMenuBLL.BusinessObjects;

namespace VideoRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        //R in CRUD
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //R in CRUD
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //C in CRUD
        //BO comes from JSON using ModelBinding
        [HttpPost]
        public void Post([FromBody]VideoBO video)
        {
        }

        // PUT api/values/5
        //U in CRUD
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        //D in CRUD
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
