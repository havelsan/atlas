using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses.DTOs
{
    public class UTSReceiveNotificationSendDTO
    {
        public string ObjectId
        {
            get; set;
        }
        public int Amount
        {
            get; set;
        }
        public string IncomingDeliveryNotifID
        {
            get; set;
        }
    }
}
