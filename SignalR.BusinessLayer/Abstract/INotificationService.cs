﻿using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        int TNotificationCountByStatusFalse();
        List<Notification> TGetAllNotificationByFalse();
        void TNotificationChangeStatus(int id);
    }
}
