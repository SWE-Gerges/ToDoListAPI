using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveToDosController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public LiveToDosController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> ReadData() 
        {
            try
            {
                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            
            }
        }
    }
}
