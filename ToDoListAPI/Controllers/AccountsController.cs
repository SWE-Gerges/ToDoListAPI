using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Core.DTO;
using ToDoListAPI.Core.Interfaces;
using ToDoListAPI.Core.Models;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost(Name = "Register")]
        public IActionResult Register(UserDTO userDTO)
        {
           var user = _mapper.Map<User>(userDTO);
            _unitOfWork.Users.Create(user);
            _unitOfWork.Save();

            return Ok(user);
        }
    }
}
