using Application.Dtos;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace auth_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("notifyEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> NotifyEmail([FromBody] EmailNotificationDto emailNotificationDto)
        {
            await _notificationService.SendEmailAsync(emailNotificationDto);
            return Ok();
        }
    }
}