using AdisoAutomationProject.Pages;
using ClosedXML.Excel;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using Utils.Excel;
using Utils.SeleniumServer;

namespace AdisoAutomationProject
{
    class Program
    {
        static void Main(string[] args)
        {
           // BasicConfigurator.Configure();
            log4net.Config.XmlConfigurator.Configure();
            var server = new Server().StartServer();

            ExcelParser ep = new ExcelParser(string.Format("{0}\\1.xlsx", Environment.CurrentDirectory));
            var a = ep.Values;


            IWebDriver driver = new ChromeDriver();
            //IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnitWithJavaScript());

            driver.Navigate().GoToUrl(@"http://adiso.by/podat-obyavlenie");
            AdvertisementPage ap = new AdvertisementPage(driver);
            ap.Category = "Дача, сад, огород";
            ap.SubCategory = "Парники, теплицы";
            ap.Region = "Витебская область";
            ap.City = "Витебск";
            ap.Header = "BLABLABLA";
            ap.Description = "fdfdfdsfsd \n dfdfsdfs";
            ap.File = @"D:\photo.jpg";
            var s = ap.Category;


            server.StopServer();
        }
    }
}
