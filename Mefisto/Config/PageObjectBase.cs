using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Config
{
    public class PageObjectBase : SeleniumBase
    {
        public void WaitForPageLoad(int time)
        {
            TimeSpan seconds = new TimeSpan(0, 0, 0, time, 0 );
            WebDriverWait wait = new WebDriverWait(browser, seconds);
            wait.Until(d =>
            {
                return WaitForReady(browser, seconds);
            });
        }

        public bool WaitForReady(IWebDriver driver, TimeSpan waitTime)
        {
            WaitForDocumentReady(driver, waitTime);
            bool ajaxReady = WaitForAjaxReady(driver, waitTime);
            WaitForDocumentReady(driver, waitTime);
            return ajaxReady;
        }
        private void WaitForDocumentReady(IWebDriver driver, TimeSpan waitTime)
        {
            var wait = new WebDriverWait(driver, waitTime);
            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                        "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
        private bool WaitForAjaxReady(IWebDriver driver, TimeSpan waitTime)
        {
            System.Threading.Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, waitTime);
            return wait.Until<bool>((d) =>
            {
                return driver.FindElements(By.CssSelector(".waiting, .tb-loading")).Count == 0;
            });
        }

        public IWebElement WaitUntilElementVisible(By elementLocator, int timeout = 5)
        {
            try
            {
                var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public IWebElement WaitUntilElementClickable(By elementLocator, int timeout = 5)
        {
            try
            {
                var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                browser.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsElementPresent(IWebElement element ,By by)
        {
            try
            {
                element.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
