using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Menu.Controllers
{
    public class MyHub : Hub
    {
        public void Hello(string masaNumarası)
        {
            Clients.Others.hello(masaNumarası);
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}