using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.AtlasWebSocketManager.Containers
{
    public class AtlasNotificationContainer : AtlasWebSocketContainer, I_AtlasWebSocketContainer
    {
        public AtlasNotificationType notificationType { get; set; }
        public bool isRead { get; set; }

        public AtlasNotificationContainer() : base()
        {

        }
    }
}
