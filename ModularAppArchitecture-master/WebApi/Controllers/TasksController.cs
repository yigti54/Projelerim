using Business.Abstract;
using Core.Utilities.Security.Authorization;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("add")]
        [AuthorizeRoles("User")] // Yetkilendirmeyi tekrar aktif hale getiriyoruz
        public IActionResult AddTask(AddTaskDto addTaskDto)
        {
            // Token'dan kullanıcının Guid'ini alıyoruz
            var userGuidClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userGuidClaim == null || !Guid.TryParse(userGuidClaim.Value, out var userGuid))
            {
                return Unauthorized("Kullanıcı kimliği alınamadı.");
            }

            // Orijinal iş mantığımızı çalıştırıyoruz
            var result = _taskService.AddTask(addTaskDto, userGuid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}