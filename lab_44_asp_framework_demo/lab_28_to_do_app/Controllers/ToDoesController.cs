using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab_47_to_do_app.Models;

namespace lab_47_to_do_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoesController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public ToDoesController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/ToDoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayTodoWithUserName>>> GetToDos()
        {
            var returnObject =
                (from todo in _context.ToDos
                 select new DisplayTodoWithUserName()
                 {
                     Id = todo.ToDoId,
                     Item = todo.ToDoName,
                     UserName = todo.User.UserName
                 }).ToListAsync<DisplayTodoWithUserName>();
            return await returnObject;
        }

        // GET: api/ToDoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayTodoWithUserName>> GetToDo(int id)
        {
            
            var toDo = await _context.ToDos.Include("User").SingleOrDefaultAsync(t => t.UserId == id);
            //var song = await _context.Songs.Include("Artist").SingleOrDefaultAsync(s => s.ArtistId == id);

            if (toDo == null)
            {
                return NotFound();
            }
            var toDos = await _context.ToDos.FindAsync(id);
            var users = await _context.Users.FindAsync(id);

            var returnObject = new DisplayTodoWithUserName()
                 {
                     Id = toDos.ToDoId,
                     Item = toDos.ToDoName,
                     UserName = users.UserName
                 };
            return returnObject;
        }

        // PUT: api/ToDoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDo(int id, ToDo toDo)
        {
            if (id != toDo.ToDoId)
            {
                return BadRequest();
            }

            _context.Entry(toDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ToDo>> PostToDo(ToDo toDo)
        {
            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDo", new { id = toDo.ToDoId }, toDo);
        }

        // DELETE: api/ToDoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDo>> DeleteToDo(int id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();

            return toDo;
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.ToDoId == id);
        }
    }
}
