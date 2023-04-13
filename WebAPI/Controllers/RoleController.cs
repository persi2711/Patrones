using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebAPI.Controllers
{

    [RoutePrefix("role")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {

            _roleService = roleService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Role role)
        {
            if (role == null) return BadRequest("Request is null");
            int id = _roleService.Add(role);
            if (id < 0) return BadRequest("Unable to Create role");
            var payload = new { Id = id };
            return Ok(payload);
        }


        [Route("")]

        public IHttpActionResult Delete(int Id)
        {
            if (_roleService.Delete(Id))
                return Ok("delete");
            else
                return BadRequest("delete to Create role");

        }
        [Route("")]

        public IHttpActionResult Get(int Id)
        {
            Role role = _roleService.Get(Id);
            if (role != null)
                return Ok(role);
            else
                return BadRequest("get to Create role");

        }
        [Route("")]
        public IHttpActionResult Put([FromBody] Role role)
        {
            if (role == null) return BadRequest("Request is null");

            if (!_roleService.Update(role))
                return BadRequest("put to Create role");
            return Ok(role);

        }

    }
}
