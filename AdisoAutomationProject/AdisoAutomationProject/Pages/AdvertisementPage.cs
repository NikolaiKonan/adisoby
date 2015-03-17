using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdisoAutomationProject.Pages
{
    public class AdvertisementPage
    {
        private IWebDriver _driver;
        public AdvertisementPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string Category
        {
            set
            {
                var root = _driver.FindElement(By.Id("category_l1_chzn"));
                root.Click();
                var field = root.FindElement(By.XPath(".//div[@class='chzn-search']/input"));
                field.SendKeys(value);
                field.SendKeys(Keys.Enter);
            }

            get { return _driver.FindElement(By.Id("category_l1_chzn")).FindElement(By.XPath("./a")).Text; }
        }
    }
}
