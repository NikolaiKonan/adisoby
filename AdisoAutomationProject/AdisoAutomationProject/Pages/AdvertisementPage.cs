using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdisoAutomationProject.Extensions;

namespace AdisoAutomationProject.Pages
{
    public class AdvertisementPage : BasePage
    {
        private IWebDriver _driver;
        public AdvertisementPage(IWebDriver driver)
            : base(driver)
        {
            _driver = driver;
        }

        public string Category
        {
            set
            {
                Log.Debug(string.Format("Selecting {0} option in 'Category' dropdown...", value));
                var root = _driver.FindElement(By.Id("category_l1_chzn"));
                root.Click();
                var items = root.FindElements(By.XPath(".//ul/li[@class='active-result']"));
                items.First(i => i.Text == value).Click(); //i.GetAttribute("innerHTML") when chrome
            }

            get { return _driver.FindElement(By.Id("category_l1_chzn")).FindElement(By.XPath("./a")).Text; }
        }

        public string SubCategory
        {
            set
            {
                Log.Debug(string.Format("Selecting {0} option in 'SubCategory' dropdown...", value));
                var root = _driver.FindElement(By.Id("category_l2_chzn"));
                _driver.TryPerform(() => root.FindElements(By.XPath(".//ul/li[@class='active-result']")).Count > 0, () => root.Click(), TimeSpan.FromSeconds(1));
                var items = root.FindElements(By.XPath(".//ul/li[@class='active-result']"));
                items.First(i => i.Text == value).Click(); //i.GetAttribute("innerHTML") when chrome
            }
        }
    }
}
