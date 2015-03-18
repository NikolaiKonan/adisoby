using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.SeleniumServer
{
    public class Server
    {
        private Process _server;

        public Server StartServer()
        {
            if (Process.GetProcesses().Select(p => p.ProcessName == "javaw").Count() > 0)
            {
                foreach (var process in Process.GetProcessesByName("javaw"))
                { process.Kill(); }
            }
             _server = Process.Start(string.Format("{0}\\selenium_server.jar", Environment.CurrentDirectory));
             return this;
        }

        public void StopServer() {
            _server.Kill();
        }
    }
}
