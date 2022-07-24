using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = new List<Todo>
            {
                new Todo { Id = 1, Name = "Laundry", IsComplete = false }
            };
            return Ok(todos);
        }
    }
}