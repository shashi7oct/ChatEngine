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

        public override Task OnConnected()
        {
            var ip = GetIpAddress();
            Clients.Caller.ipadd(ip);
            return base.OnConnected();
        }
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        protected string GetIpAddress()
        {
            var env = Get<IDictionary<string, object>>(Context.Request.Items, "owin.environment");
            if (env == null)
            {
                return null;
            }
            var ipAddress = Get<string>(env, "server.RemoteIpAddress");
            return ipAddress;
        }
        private static T Get<T>(IDictionary<string, object> env, string key)
        {
            object value;
            return env.TryGetValue(key, out value) ? (T)value : default(T);
        }
    }

    
}