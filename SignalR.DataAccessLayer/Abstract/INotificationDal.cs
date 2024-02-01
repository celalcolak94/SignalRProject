using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();
        List<Notification> GetAllNotificationByFalse();
        void NotificationChangeStatus(int id);
    }
}
