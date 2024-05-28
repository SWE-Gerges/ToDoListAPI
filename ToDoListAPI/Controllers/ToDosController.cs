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
    public class ToDosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ToDosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var todos = _unitOfWork.ToDos.GetAll(new[] { "User" });
            var dtos = _mapper.Map<IEnumerable<ToDoDTO>>(todos);
            return Ok(dtos);
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var toDo = _unitOfWork.ToDos.Find(t => t.Id == id, new[] {"User"});
            ToDoDTO dto = _mapper.Map<ToDoDTO>(toDo);
            return Ok(dto);
        }
        [HttpPost]
        public IActionResult Create(ToDoDTO toDoDTO)
        {
            ToDo toDo =  _mapper.Map<ToDo>(toDoDTO);
            _unitOfWork.ToDos.Create(toDo);
            _unitOfWork.Save();
            return Ok(toDo);
        }
        [HttpPut("id")]
        public IActionResult Update(ToDoDTO toDoDTO, int id)
        {
            var todoEntity = _unitOfWork.ToDos.GetById(id);

            ToDo toDo = _mapper.Map<ToDo>(toDoDTO);

            todoEntity.Title = toDo.Title;
            todoEntity.Completed = toDo.Completed;
            todoEntity.UserId = todoEntity.UserId;

            _unitOfWork.ToDos.Update(todoEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
          var todo =   _unitOfWork.ToDos.GetById(id);
            _unitOfWork.ToDos.Delete(todo);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
