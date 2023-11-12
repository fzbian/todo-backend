using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoBackend.Data;
using todoBackend.Models;

namespace todoBackend.Services
{
    public interface ITodoServices
    {
        Task<List<Todos>> GetTasks();
        Task<Todos> GetTaskById(Guid id);
        Task<Todos> CreateTask(Todos task);
        Task<Todos> UpdateTask(Guid id, Todos task);
        Task<Todos> CheckTask(Guid id, bool completed);
        bool DeleteTask(Guid id);
    }

    public class TodoService : ITodoServices
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Todos>> GetTasks()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todos> GetTaskById(Guid id)
        {
            var task = await _context.Todos.FirstOrDefaultAsync(x => x.TodoId == id);
            if (task is null)
            {
                throw new KeyNotFoundException($"No se encontró ninguna tarea con el ID {id}");
            }
            return await Task.FromResult(task);
        }

        public async Task<Todos> CreateTask(Todos task)
        {
            var entityEntry = await _context.Todos.AddAsync(task);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<Todos> UpdateTask(Guid id, Todos task)
        {
            var actualTodo = await _context.Todos.FirstOrDefaultAsync(x => x.TodoId == id);
            if (actualTodo == null)
            {
                throw new KeyNotFoundException();
            }

            actualTodo.TodoContent = task.TodoContent;
            actualTodo.TodoCompleted = task.TodoCompleted;
            actualTodo.TodoDateUpdated = DateTime.Now.ToUniversalTime();
            return await Task.FromResult(actualTodo);
        }

        public async Task<Todos> CheckTask(Guid id, bool completed)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.TodoId == id);

            if (todo == null)
            {
                throw new KeyNotFoundException($"No se encontró ninguna tarea con el ID {id}");
            }

            todo.TodoCompleted = completed;
            todo.TodoDateCompleted = DateTime.Now.ToUniversalTime();
            return await Task.FromResult(todo);
        }


        public bool DeleteTask(Guid id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.TodoId == id);
            if (todo == null)
            {
                throw new KeyNotFoundException($"No se encontró ninguna tarea con el ID {id}");
            }

            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return true;
        }
    }
}