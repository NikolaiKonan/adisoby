using AdisoAutomationProject.Utils;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdisoAutomationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = Process.Start(string.Format("{0}\\selenium_server.jar", Environment.CurrentDirectory));
            ExcelParser ep = new ExcelParser(@"D:\AdisoBy\adisoby\AdisoAutomationProject\AdisoAutomationProject\bin\Debug\1.xlsx");
            var a = ep.Values;
          

            server.Kill();
        }
    }
}
