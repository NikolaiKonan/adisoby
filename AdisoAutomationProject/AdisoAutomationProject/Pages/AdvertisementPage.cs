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
                //items.First(i => i.Text == value).Click(); //i.GetAttribute("innerHTML") when chrome
                items.First(i => i.GetAttribute("innerHTML") == value).Click(); 
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
                //items.First(i => i.Text == value).Click(); //i.GetAttribute("innerHTML") when chrome
                items.First(i => i.GetAttribute("innerHTML") == value).Click(); 
            }
        }

        public string Region
        {
            set
            {
                Log.Debug(string.Format("Selecting {0} option in 'Region' dropdown...", value));
                var root = _driver.FindElement(By.Id("region_selector_chzn"));
                root.Click();
                var items = root.FindElements(By.XPath(".//ul/li[@class='active-result']"));
                //items.First(i => i.Text == value).Click(); //i.GetAttribute("innerHTML") when chrome
                items.First(i => i.GetAttribute("innerHTML").Contains(value)).Click(); 
            }

            get { return _driver.FindElement(By.Id("region_selector_chzn")).FindElement(By.XPath("./a")).Text; }
        }

        public string City
        {
            set
            {
                Log.Debug(string.Format("Selecting {0} option in 'City' dropdown...", value));
                var root = _driver.FindElement(By.Id("city_selector_chzn"));
                root.Click();
                var items = root.FindElements(By.XPath(".//ul/li[@class='active-result']"));
                //items.First(i => i.Text == value).Click(); //i.GetAttribute("innerHTML") when chrome
                items.First(i => i.GetAttribute("innerHTML") == value).Click();
            }

            get { return _driver.FindElement(By.Id("city_selector_chzn")).FindElement(By.XPath("./a")).Text; }
        }

        public string Header
        {
            set { _driver.FindElement(By.Id("text1")).SendKeys(value); }
        }

        public string Description
        {
            set { _driver.FindElement(By.Id("text2")).SendKeys(value); }
        }

        public string File
        {
            set { _driver.FindElement(By.XPath("//input[@class='file-block']")).SendKeys(value); }
        }
    }
}
