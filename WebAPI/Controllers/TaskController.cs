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

    [RoutePrefix("task")]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {

            _taskService = taskService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Task task)
        {
            if (task == null) return BadRequest("Request is null");
            int id = _taskService.Add(task);
            if (id < 0) return BadRequest("Unable to Create control");
            var payload = new { Id = id };
            return Ok(payload);
        }
        [Route("")]

        public IHttpActionResult Delete(int Id)
        {
            if (_taskService.Delete(Id))
                return Ok("delete");
            else
                return BadRequest("Unable to delete control");

        }
        [Route("")]

        public IHttpActionResult Get(int Id)
        {
            Task task = _taskService.Get(Id);
            if (task != null)
                return Ok(task);
            else
                return BadRequest("Unable to get control");

        }
        [Route("")]
        public IHttpActionResult Put([FromBody] Task task)
        {
            if (task == null) return BadRequest("Request is null");

            if (!_taskService.Update(task))
                return BadRequest("Unable to put control");
            return Ok(task);

        }

    }
}