using Core.AtlasWebSocketManager.Containers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.AtlasWebSocketManager
{
    public class AtlasHubContainer : TTUtils.IAtlasHubSignalRService
    {
        private IHubContext<AtlasHub> _atlasHubContextSignalR;
        private IClientProxy GenerateClientProxy(IHubClients Clients, I_AtlasWebSocketContainer atlasMessageItems)
        {
            var query = from c in AtlasHub._connections.GetAllClients()
                        where atlasMessageItems.users.Contains(c.userId)
                        select c;

            var targetClientList = query.ToList();
            var clientList = Clients.Clients(targetClientList.Select(x => x.ConnectionId).ToList());
            return clientList;
        }

        public  AtlasHubContainer()
        {
        }
        public AtlasHubContainer(IHubContext<AtlasHub> atlasHubContextSignalR)
        {
            _atlasHubContextSignalR = atlasHubContextSignalR;
        }
        public void HandleUserMessage(string receivedString)
        {
            I_AtlasWebSocketContainer atlasMessageItems = ContainerBuilder.CreateAtlasMessageContainer(receivedString);

            if (atlasMessageItems.dataProcessedSuccessfully)
            {
                SendUsers(atlasMessageItems, RegisteryEventHeaders.HANDLE_USER_MESSAGE);
            }
        }

        public void HandleUserNotification(string receivedString)
        {
            I_AtlasWebSocketContainer atlasNotificationItems = ContainerBuilder.CreateAtlasNotificationContainer(receivedString);

            if (atlasNotificationItems.dataProcessedSuccessfully)
            {
                SendUsers(atlasNotificationItems, RegisteryEventHeaders.HANDLE_USER_NOTIFICATION);
            }
        }

        public void HandleActions(string receivedString)
        {
            I_AtlasWebSocketContainer atlasNotificationItems = ContainerBuilder.CreateAtlasActionContainer(receivedString);

            if (atlasNotificationItems.dataProcessedSuccessfully)
            {
                SendUsers(atlasNotificationItems, RegisteryEventHeaders.HANDLE_USER_NOTIFICATION);
            }
        }

        internal void SendUsers(I_AtlasWebSocketContainer atlasMessageItems, string type)
        {
            var notification = NotificationService.AddNotification(atlasMessageItems);

            foreach (var item in notification.NotificationUsers)
            {
                I_AtlasWebSocketContainer atlasMessageItem = new AtlasWebSocketContainer();
                atlasMessageItems.users = new List<string>() { item.UserID.ToString() };
                IClientProxy clientList = GenerateClientProxy(_atlasHubContextSignalR.Clients, atlasMessageItems);

                var result = new NotificationDto()
                {
                    Notification = notification.Notification,
                    NotificationUser = notification.NotificationUsers.FirstOrDefault(x => x.UserID == item.UserID),
                };

                clientList.SendAsync(type, result);
            }
        }
    }
}
