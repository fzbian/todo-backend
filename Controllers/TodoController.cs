using Microsoft.AspNetCore.Mvc;
using todoBackend.Services;

namespace todoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoServices _todoServices;

        public TodoController(ITodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("OK");
        }

        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetTasks()
        {
            var todos = await _todoServices.GetTasks();
            return Ok(todos);
        }

        [HttpGet("GetTasksById/{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var todo = await _todoServices.GetTaskById(id);
            return Ok(todo);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] Models.Todos task)
        {
            var todo = await _todoServices.CreateTask(task);
            return Ok(todo);
        }

        [HttpPut("UpdateTask/{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] Models.Todos task)
        {
            var todo = await _todoServices.UpdateTask(id, task);
            return Ok(todo);
        }

        [HttpPut("CheckTask/{id}/{completed}")]
        public async Task<IActionResult> CheckTask(Guid id, bool completed)
        {
            try
            {
                var todo = await _todoServices.CheckTask(id, completed);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                // Loguear la excepción si es necesario
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpDelete("DeleteTask/{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            var todo = _todoServices.DeleteTask(id);
            return Ok(todo);
        }
    }
}