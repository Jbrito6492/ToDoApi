using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {
            return Ok(await _context.Todos.ToListAsync());
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return NotFound();
            return Ok(todo);
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Todo>> Post(Todo todo)
        {
            _context.Todos.Add(todo);

            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = todo.Id }, todo);
        }


        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> Put(int id, Todo todo)
        {
            var todoToUpdate = await _context.Todos.FindAsync(id);
            if (todoToUpdate == null)
                return NotFound();

            todoToUpdate.Name = todo.Name;
            todoToUpdate.IsComplete = todo.IsComplete;
            await _context.SaveChangesAsync();
            return Ok(todoToUpdate);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> Delete(int id)
        {
            var todoToDelete = await _context.Todos.FindAsync(id);
            if (todoToDelete == null)
                return NotFound();

            _context.Todos.Remove(todoToDelete);
            await _context.SaveChangesAsync();
            return Ok(todoToDelete);
        }
    }
}