using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/task")]
    [ApiController]
    [Authorize] // Bu endpoint'lerin yetkili kullanıcılar tarafından erişilebilir olmasını sağlar
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _taskService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _taskService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("getbyuserid/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var result = await _taskService.GetByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(TaskCreateDto taskCreateDto)
        {
            var result = await _taskService.AddAsync(taskCreateDto);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(TaskUpdateDto taskUpdateDto)
        {
            var result = await _taskService.UpdateAsync(taskUpdateDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _taskService.DeleteAsync(id);
            return Ok(result);
        }
    }
}