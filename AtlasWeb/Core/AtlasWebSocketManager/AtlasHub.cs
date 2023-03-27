using System.Threading.Tasks;
using System;
using Infrastructure.Helpers;
using System.Linq;
using Infrastructure.Models;
using Microsoft.AspNetCore.SignalR;

using Core.AtlasWebSocketManager.Containers;
using System.Collections.Generic;

namespace Core.AtlasWebSocketManager
{

    public class AtlasHub : Hub, TTUtils.IAtlasHubSignalRService
    {
        public readonly static ConnectionMapping _connections = new ConnectionMapping();

        private IClientProxy GenerateClientProxy(I_AtlasWebSocketContainer atlasMessageItems)
        {
            var query = from c in _connections.GetAllClients()
                        where atlasMessageItems.users.Contains(c.userId)
                        select c;

            var targetClientList = query.ToList();

            var clientList = Clients.Clients(targetClientList.Select(x => x.ConnectionId).ToList());
            return clientList;
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
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var hubConnectionId = Context.ConnectionId;
            _connections.Remove(hubConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            var userName = Context.GetHttpContext().Request.Query["uname"];
            var userId = Context.GetHttpContext().Request.Query["connid"];
            var hubConnectionId = Context.ConnectionId;

            var hubConnectionInfo = new HubConnectionInfo();
            hubConnectionInfo.userName = userName;
            hubConnectionInfo.userId = userId;
            hubConnectionInfo.ConnectionId = hubConnectionId;

            System.Diagnostics.Trace.WriteLine($"Hub Connection Id: {hubConnectionId}");
            _connections.Add(userName, hubConnectionInfo);
            
            return base.OnConnectedAsync();
        }

        internal void SendUsers(I_AtlasWebSocketContainer atlasMessageItems, string type)
        {
            var notification = NotificationService.AddNotification(atlasMessageItems);

            foreach (var item in notification.NotificationUsers)
            {
                I_AtlasWebSocketContainer atlasMessageItem = new AtlasWebSocketContainer();
                atlasMessageItems.users = new List<string>() { item.UserID };
                IClientProxy clientList = GenerateClientProxy(atlasMessageItems);

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
