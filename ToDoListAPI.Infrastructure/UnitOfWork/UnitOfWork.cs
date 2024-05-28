using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Core.Interfaces;
using ToDoListAPI.Core.Models;
using ToDoListAPI.Infrastructure.Data;
using ToDoListAPI.Infrastructure.Repositories;

namespace ToDoListAPI.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<ToDo> ToDos { get; private set; }
        public IGenericRepository<User> Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            ToDos = new GenericRepository<ToDo>(_context);
            Users = new GenericRepository<User>(_context);
        }


        public int Save()
        { 
            return _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
