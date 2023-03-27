using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Notification
{
    
    public class NotificationDTO
    {
        public string ActionData { get; set; }
        public string Content { get; set; }
        public int? ContentType { get; set; }
        public DateTime? CreateTime { get; set; }
        public string ObjectID { get; set; }
        public string ResUser { get; set; }
        public int? SourceType { get; set; }
    }

   
}
