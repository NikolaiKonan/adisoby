using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdisoAutomationProject.Extensions
{
    public static class IWebDriverExtension
    {
        public static void TryPerform(this IWebDriver driver, Func<bool> until, Action action, TimeSpan waitBeforeRetry)
        {
            Thread.Sleep(waitBeforeRetry);
            if (until.Invoke())
            {
                action.Invoke();
            }
            else
            {
                driver.TryPerform(until, action, waitBeforeRetry);
            }
        }
    }
}
