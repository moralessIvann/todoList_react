using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoList_react.Models;

namespace todoList_react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoListContext _dbcontext;
        public TodoController(TodoListContext dbContext)
        {
            _dbcontext = dbContext;
        }
        
        [HttpGet]
        [Route("List")] //route es para poder llamar el metodo?
        public async Task<IActionResult> GetList()
        {
            List<Models.Task> list = _dbcontext.Tasks.OrderByDescending(t => t.IdTask).ThenBy(t => t.CreationDate).ToList();
            return StatusCode(StatusCodes.Status200OK,list);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] Models.Task request)
        {
            await _dbcontext.Tasks.AddAsync(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPost]
        [Route("Close/{id:int}")]
        public async Task<IActionResult> Close(int id)
        {
            Models.Task task = _dbcontext.Tasks.Find(id);
            _dbcontext.Tasks.Remove(task);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
