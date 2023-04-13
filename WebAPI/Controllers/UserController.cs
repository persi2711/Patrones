﻿using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{

    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {

            _userService = userService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] User user)
        {
            if (user == null) return BadRequest("Request is null");
            int id = _userService.Add(user);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }
        [Route("")]
        
        public IHttpActionResult Delete( int Id)
        {
            if (_userService.Delete(Id))
                return Ok("delete");
            else
                return BadRequest("Unable to Create User");

        }
        [Route("")]
        
        public IHttpActionResult Get( int Id)
        {
            User user = _userService.Get(Id);
            if (user != null)
                return Ok(user);
            else
                return BadRequest("Unable to Create User");

        }
        [Route("")]
        public IHttpActionResult Put([FromBody] User user)
        {
            if (user == null) return BadRequest("Request is null");

            if (!_userService.Update(user))
                return BadRequest("Unable to Create User");
            return Ok(user);

        }

    }

}
