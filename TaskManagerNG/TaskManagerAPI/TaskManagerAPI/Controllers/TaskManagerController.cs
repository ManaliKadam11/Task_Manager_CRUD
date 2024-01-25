using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagerAPI.Data;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private readonly DataContext _context;
            public TaskManagerController(DataContext context)
            {
            _context = context;
            }

        [HttpGet]
        public async Task<ActionResult<List<TaskManager>>> GetTaskManagers()
        {
            return Ok(await _context.TaskManagers.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskManager>>> CreateTaskManager(TaskManager task)
        {
            _context.TaskManagers.Add(task);
            await _context.SaveChangesAsync();

            return Ok(await _context.TaskManagers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TaskManager>>> UpdateTaskManager(TaskManager task)
        {
            var dbTask = await _context.TaskManagers.FindAsync(task.Id);
            if (dbTask == null)
                return BadRequest("Task not found!");

            dbTask.Name = task.Name;
            dbTask.FirstName = task.FirstName;
            dbTask.LastName = task.LastName;
            dbTask.Status = task.Status;

            await _context.SaveChangesAsync();

            return Ok(await _context.TaskManagers.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<TaskManager>>> DeleteTaskManager(int id)
        {

            var dbTask = await _context.TaskManagers.FindAsync(id);
            if (dbTask == null)
                return BadRequest("Task not found!");

            _context.TaskManagers.Remove(dbTask);   
            await _context.SaveChangesAsync();

            return Ok(await _context.TaskManagers.ToListAsync());
        }
    }
}
