using Domain.Model;



namespace Business.Contracts
{
    public interface ITaskService
    {
        //Create
        int Add(Task task);
        //Read
        Task Get(int id);
        //Update
        bool Update(Task task);
        //Delete
        bool Delete(int id);
    }
}
