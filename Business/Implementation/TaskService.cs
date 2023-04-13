using Business.Contracts;
using Data.Contracts;
using Domain.Model;



namespace Business.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;
        public TaskService(ITaskRepository userRepo)
        {
            _taskRepo = userRepo;
        }
        public int Add(Task task)
        {
            if (task.Id <= 0) return 0;
            if (string.IsNullOrEmpty(task.Nombre)) return 0;
            if (string.IsNullOrEmpty(task.Descripcion)) return 0;
            if (string.IsNullOrEmpty(task.Status)) return 0;
            return _taskRepo.Add(task);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_taskRepo.Delete(id));
        }

        public Task Get(int id)
        {
            Task u = _taskRepo.Get(id);
            return u;
        }

        public bool Update(Task task)
        {
            if (task.Id <= 0) return false;
            if (string.IsNullOrEmpty(task.Nombre)) return false;
            if (string.IsNullOrEmpty(task.Descripcion)) return false;
            if (string.IsNullOrEmpty(task.Status)) return false;
            return _taskRepo.Update(task);
        }
    }
}
