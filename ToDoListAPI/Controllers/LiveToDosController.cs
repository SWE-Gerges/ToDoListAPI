using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Core.Models;
using ToDoListAPI.Core.Pagination;
using ToDoListAPI.Infrastructure;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LiveToDosController : ControllerBase
    {
        private readonly APIConsumer _apiConsumer;

        public LiveToDosController(APIConsumer apiConsumer)
        {
            _apiConsumer = apiConsumer;
        }

        [HttpGet]
        public async Task<IActionResult> ReadData([FromQuery] PaginationParameters paginationParameters) 
        {
            try
            {
                var data = await _apiConsumer.ReadFromAPI("https://jsonplaceholder.typicode.com/todos");
                var pagedData = data
            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
            .Take(paginationParameters.PageSize)
            .ToList();
                return Ok(pagedData);
            }

            catch (Exception ex) {

                return BadRequest();
            }

            
        }

        
    }
}
