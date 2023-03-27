using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Notification
{
    public class NotificationResponseDTO
    {
        public NotificationDTO Notification { get; set; }

        public NotificationUserDTO NotificationUser { get; set; }
    }
}
