using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using todoBackend.Modules;

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
        private static readonly List<Todos> _todos = new List<Todos>();

        public async Task<List<Todos>> GetTasks()
        {
            return await Task.FromResult(_todos);
        }

        public async Task<Todos> GetTaskById(Guid id)
        {
            var task = _todos.FirstOrDefault(x => x.TodoId == id);
            if (task is null)
            {
                throw new KeyNotFoundException($"No se encontró ninguna tarea con el ID {id}");
            }
            return await Task.FromResult(task);
        }

        public async Task<Todos> CreateTask(Todos task)
        {
            _todos.Add(task);
            return await Task.FromResult(task);
        }

        public async Task<Todos> UpdateTask(Guid id, Todos task)
        {
            var actualTodo = _todos.FirstOrDefault(x => x.TodoId == id);
            if (actualTodo == null)
            {
                throw new KeyNotFoundException();
            }

            actualTodo.TodoContent = task.TodoContent;
            actualTodo.TodoCompleted = task.TodoCompleted;
            actualTodo.TodoDateUpdated = DateTime.Now;
            return await Task.FromResult(actualTodo);
        }

        public async Task<Todos> CheckTask(Guid id, bool completed)
        {
            var todo = _todos.FirstOrDefault(x => x.TodoId == id);

            if (todo == null)
            {
                throw new KeyNotFoundException($"No se encontró ninguna tarea con el ID {id}");
            }

            todo.TodoCompleted = completed;
            return await Task.FromResult(todo);
        }


        public bool DeleteTask(Guid id)
        {
            var index = _todos.FindIndex(x => x.TodoId == id);
            if (index == -1)
            {
                throw new KeyNotFoundException();
            }

            _todos.RemoveAt(index);
            return true;
        }

        public static TodoService Current { get; } = new TodoService();
    }

}