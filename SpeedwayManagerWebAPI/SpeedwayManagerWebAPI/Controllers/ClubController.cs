﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedwayManagerWebAPI.Application.Club.Create;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeedwayManagerWebAPI.Controllers
{
    [Route("api/club")]
    [Authorize]
    public class ClubController : Controller
    {
        private readonly IMediator _mediator;

        public ClubController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateClubRequest request)
        {
            try
            {
                var response = _mediator.Send(request);
                return Created(Url.Action("Get"), response.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
