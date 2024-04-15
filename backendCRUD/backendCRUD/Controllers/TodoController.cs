using backendCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _todoDbContext;

        // Using constructor injection, the controller gets the TodoDbContext.
        public TodoController(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        // GET method to retrieve all todo items.
        [HttpGet]
        [Route("GetTodo")]
        public async Task<IEnumerable<Todo>> GetTodo()
        {
            return await _todoDbContext.Todo.ToListAsync();
        }

        // POST method to add a new todo item.
        [HttpPost]
        [Route("AddTodo")]
        public async Task<Todo> AddTodo(Todo objTodo)
        {
            _todoDbContext.Todo.Add(objTodo);
            await _todoDbContext.SaveChangesAsync();
            return objTodo;
        }

        // PATCH method to update an existing todo item.
        [HttpPatch]
        [Route("UpdateTodo/{id}")]
        public async Task<Todo> UpdateTodo(Todo objTodo)
        {
            _todoDbContext.Entry(objTodo).State = EntityState.Modified;
            await _todoDbContext.SaveChangesAsync();
            return objTodo;
        }

        // DELETE method to delete a todo item.
        [HttpDelete]
        [Route("DeleteTodo/{id}")]
        public bool DeleteTodo(int id)
        {
            bool a = false;
            var todo = _todoDbContext.Todo.Find(id);
            if (todo != null)
            {
                a = true;
                _todoDbContext.Entry(todo).State = EntityState.Deleted;
                _todoDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;
        }
    }
}


