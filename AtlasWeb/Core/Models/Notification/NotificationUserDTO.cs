using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Notification
{
    public class NotificationUserDTO
    {
        public bool? IsRead { get; set; }
        public string Notification { get; set; }
        public string ObjectID { get; set; }
        public string ResUser { get; set; }
    }
}
