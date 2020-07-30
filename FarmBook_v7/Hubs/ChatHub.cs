namespace FarmBook_v7.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Web;

    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    using FarmBook_v7.Models;
    using FarmBook_v7.Repositories;

    public class ChatHub : Hub
    {
        public void SendText(string userName, string message)
        {
            ChatMessage msg = new ChatMessage { Username = userName, MessageText = message, TimeSent = DateTime.UtcNow };

            ChatRepository.AddMsg(msg);
            Clients.All.messageSent(msg);
        }

        public void RegisterChatClient(string userName)
        {
            UserRepository.AddUser(Context.ConnectionId, userName);
            UsersSignedIn user = new UsersSignedIn { Username = userName };

            Clients.All.userSignedIn(user);
        }
        
        //public virtual Task OnDisconnected(bool s)
        public override Task OnDisconnected(bool stopCalled)
        {
            string userName = UserRepository.RemoveUser(Context.ConnectionId);
            if (!string.IsNullOrEmpty(userName)) //  if (stopCalled)
            //if (stopCalled)
            {
                Clients.All.userSignedOut(userName);
            }
  //          else { }

            return base.OnDisconnected(stopCalled);
        }
  
    }
}