using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdisoAutomationProject.Pages
{
    public class BasePage
    {
        private IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected ILog Log
        {
            get { return LogManager.GetLogger(typeof(BasePage)); }
        }
    }
}
