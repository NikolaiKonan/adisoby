using AdisoAutomationProject.Pages;
using AdisoAutomationProject.Utils;
using ClosedXML.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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
            if (Process.GetProcesses().Select(p => p.ProcessName == "javaw").Count() > 0)
            {
                foreach (var process in Process.GetProcessesByName("javaw"))
                { process.Kill(); }
            }
            var server = Process.Start(string.Format("{0}\\selenium_server.jar", Environment.CurrentDirectory));
            ExcelParser ep = new ExcelParser(string.Format("{0}\\1.xlsx", Environment.CurrentDirectory));
            var a = ep.Values;


            //IWebDriver driver = new ChromeDriver();
            IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnitWithJavaScript());

            driver.Navigate().GoToUrl(@"http://adiso.by/podat-obyavlenie");
            AdvertisementPage ap = new AdvertisementPage(driver);
            ap.Category = "Все для дома и быта";
            var s = ap.Category;
            server.Kill();
        }
    }
}
