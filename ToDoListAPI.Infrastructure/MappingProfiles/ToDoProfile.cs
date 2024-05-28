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
    public class ToDoProfile : Profile
    {
        public ToDoProfile() 
        {
        
            CreateMap<ToDo, ToDoDTO>()
                .ForMember(
                dest => dest.NameOfUser,
                src => src.MapFrom(x => x.User.UserName))
                .ReverseMap();
        }
    }
}
