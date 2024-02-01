using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification
            {
                Description = createNotificationDto.Description,
                Type = createNotificationDto.Type,
                Icon = createNotificationDto.Icon,
                Status = false,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };
            _notificationService.TAdd(notification);

            return Ok("Ekleme işlemi başarıyla yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Silindi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification
            {
                NotificationID = updateNotificationDto.NotificationID,
                Description = updateNotificationDto.Description,
                Type = updateNotificationDto.Type,
                Icon = updateNotificationDto.Icon,
                Status = updateNotificationDto.Status,
                Date = updateNotificationDto.Date
            };

            _notificationService.TUpdate(notification);
            return Ok("Bildirim Güncellendi");
        }

        [HttpGet("NotificationChangeStatus/{id}")]
        public IActionResult NotificationChangeStatus(int id)
        {
            _notificationService.TNotificationChangeStatus(id);
            return Ok("Güncelleme yapıldı");
        }
    }
}
