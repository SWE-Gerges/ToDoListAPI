using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Core.DTO
{
    public class ToDoDTO
    {
        

        public string Title { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }

        public string NameOfUser { get; set; }

    }
}
