using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ChatEngine
{
    public class ChatConn : Hub
    {
        public void sendmsg(string msg)
        {
            Clients.All.sendmessage(Context.ConnectionId, msg);
        }
    }
}