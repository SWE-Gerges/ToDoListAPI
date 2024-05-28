

using ToDoListAPI.Core.Models;

namespace ToDoListAPI.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ToDo> ToDos {  get; }
        IGenericRepository<User> Users {  get; }


        int Save();
    }
}
