using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static List<Todo> _todos = new List<Todo>
        {
            new Todo { Id = 1, Name = "Todo 1", IsComplete = false }
        };

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {
            return Ok(_todos);
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Todo>> Post(Todo todo)
        {
            _todos.Add(todo);
            return CreatedAtAction("Get", new { id = todo.Id }, todo);
        }


        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> Put(int id, Todo todo)
        {
            var todoToUpdate = _todos.FirstOrDefault(t => t.Id == id);
            if (todoToUpdate == null)
            {
                return NotFound();
            }

            todoToUpdate.Name = todo.Name;
            todoToUpdate.IsComplete = todo.IsComplete;
            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> Delete(int id)
        {
            var todoToDelete = _todos.FirstOrDefault(t => t.Id == id);
            if (todoToDelete == null)
            {
                return NotFound();
            }

            _todos.Remove(todoToDelete);
            return NoContent();
        }
    }
}