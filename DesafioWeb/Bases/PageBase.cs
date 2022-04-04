using CSharpSpecflowTemplate.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;

namespace CSharpSpecflowTemplate.Bases
{
    public class PageBase
    {

        #region Objects and constructor
        protected OpenQA.Selenium.Support.UI.WebDriverWait wait { get; private set; }
        protected IWebDriver driver { get; private set; }
        protected IJavaScriptExecutor javaScriptExecutor { get; private set; }

        public PageBase()
        {
            wait = new OpenQA.Selenium.Support.UI.WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["timeout_default"].ToString())));
            driver = DriverFactory.INSTANCE;
            javaScriptExecutor = (IJavaScriptExecutor)driver;
        }
        #endregion

        #region Custom Actions

        private void WaitUntilPageReady()
        {
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();

            while (timeOut.Elapsed.Seconds <= Convert.ToInt32(ConfigurationManager.AppSettings["timeout_default"].ToString()))
            {
                string documentState = javaScriptExecutor.ExecuteScript("return document.readyState").ToString();
                if (documentState.Equals("complete"))
                {
                    timeOut.Stop();
                    break;
                }
            }
        }

        protected IWebElement WaitForElement(By locator)
        {
            WaitUntilPageReady();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            return element;
        }

        protected IWebElement WaitForElementByTime(By locator, TimeSpan time)
        {
            WaitUntilPageReady();
            OpenQA.Selenium.Support.UI.WebDriverWait waitTime = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, time);
            waitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            waitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            return element;
        }

        protected IWebElement WaitForElementDisabled(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            return element;
        }

        //Função usada para acessar os elementos que estão dentro de um #shadow-root
        //Ex:  WebElement root = driver.findElement(By.tagName("driver-app-shell"))---> elemento onde se encontra o shadow-root
        //     WebElement shadowRoot = expandShadowRootElement(root); ----> pegando os elementos que estão dentro do shadow-root
        protected IWebElement ExpandShadowRootElement(By locator)
        {
            IWebElement shadowRootElement = (IWebElement)javaScriptExecutor.ExecuteScript("return arguments[0].shadowRoot", WaitForElement(locator));
            return shadowRootElement;
        }

        protected void Click(By locator)
        {
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();

            while (timeOut.Elapsed.Seconds <= Convert.ToInt32(ConfigurationManager.AppSettings["timeout_default"]))
            {
                try
                {
                    WaitForElement(locator).Click();
                    timeOut.Stop();
                    return;
                }
                catch (System.Reflection.TargetInvocationException)
                {

                }
                catch (StaleElementReferenceException)
                {

                }
                catch (System.InvalidOperationException)
                {

                }
                catch (WebDriverException e)
                {
                    if (e.Message.Contains("Other element would receive the click"))
                    {
                        continue;
                    }

                    if (e.Message.Contains("Element is not clickable at point"))
                    {
                        continue;
                    }

                    throw e;
                }
            }

            throw new Exception("Given element isn't visible");
        }

        protected void SendKeys(By locator, string text)
        {
            WaitForElement(locator).SendKeys(text);
        }

        protected void SendKeysWithoutWaitVisible(By locator, string text)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            element.SendKeys(text);
        }

        protected void ComboBoxSelectByVisibleText(By locator, string text)
        {
            SelectElement comboBox = new SelectElement(WaitForElement(locator));
            comboBox.SelectByText(text);
        }

        protected void ComboBoxSelectRandomValue(By locator)
        {
            SelectElement comboBox = new SelectElement(WaitForElement(locator));
            Random random = new Random();
            IList<IWebElement> options = comboBox.Options;
            comboBox.SelectByText(options[random.Next(0, options.Count)].Text.Trim());
        }

        protected void MouseOver(By locator)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(WaitForElement(locator)).Build().Perform();
        }

        protected string GetText(By locator)
        {
            string text = WaitForElement(locator).Text;
            return text;
        }

        protected string GetValue(By locator)
        {
            string text = WaitForElement(locator).GetAttribute("value");
            return text;
        }

        protected bool ReturnIfElementIsDisplayed(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Displayed;
            return result;
        }

        protected bool ReturnIfElementIsEnabled(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Enabled;
            return result;
        }

        protected bool ReturnIfElementIsSelected(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Selected;
            return result;
        }

        protected void Clear(By locator)
        {
            WaitForElement(locator).Clear();
        }

        protected void ClearAndSendKeys(By locator, String text)
        {
            WaitForElement(locator).Clear();
            WaitForElement(locator).SendKeys(text);
        }

        protected string ReturnAllAtributesOfAnElement(By locator)
        {
            return WaitForElement(locator).GetAttribute("outerHTML");
        }
        
        #endregion

        #region JavaScript Actions
        protected void SendKeysJavaScript(By locator, string value)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScriptExecutor.ExecuteScript("arguments[0].value='" + value + "';", element);
        }

        protected void ClickJavaScript(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScriptExecutor.ExecuteScript("arguments[0].click();", element);
        }

        protected void ScrollToElementJavaScript(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        protected void ScrollToTop()
        {
            javaScriptExecutor.ExecuteScript("window.scrollTo(0, 0);");
        }
        #endregion

        #region Default Actions
        public void Refresh()
        {
            DriverFactory.INSTANCE.Navigate().Refresh();
        }

        public void NavigateTo(string url)
        {
            DriverFactory.INSTANCE.Navigate().GoToUrl(url);
        }

        public void OpenNewTab()
        {
            javaScriptExecutor.ExecuteScript("window.open();");
        }

        public void SetFocusToLastTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void SetFocusToFirstTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        public string GetTitle()
        {
            string title = driver.Title;

            return title;
        }

        public string GetURL()
        {
            string url = driver.Url;

            return url;
        }
        #endregion
    }
}
