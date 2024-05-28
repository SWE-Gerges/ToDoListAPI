using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Core.DTO;
using ToDoListAPI.Core.Models;

namespace ToDoListAPI.Infrastructure.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
