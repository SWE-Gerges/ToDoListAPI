

using ToDoListAPI.Core.Models;

namespace ToDoListAPI.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ToDo> ToDos {  get; }


        int Save();
    }
}
