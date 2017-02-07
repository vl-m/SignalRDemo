using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalRDemo.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(Context.User.Identity.Name, Context.ConnectionId, message);
        }

        private void SystemMsgSend(string message)
        {
            // Call the addNewSystemMessageToPage method to update all clients except the calling client.
            Clients.Others.addNewSystemMessageToPage(Context.User.Identity.Name, Context.ConnectionId, message);
        }

        public override Task OnConnected()
        {
            SystemMsgSend("connected");
            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            SystemMsgSend("disconnected");
            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            SystemMsgSend("reconnected");
            return base.OnReconnected();
        }
    }
}