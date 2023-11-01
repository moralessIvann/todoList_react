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
    }
}
