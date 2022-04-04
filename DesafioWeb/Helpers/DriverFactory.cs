using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Edge;

namespace CSharpSpecflowTemplate.Helpers
{
    public class DriverFactory
    {
        public static IWebDriver INSTANCE { get; set; } = null;

        public static void CreateInstance()
        {
            string browser = ConfigurationManager.AppSettings["browser"].ToString();
            string execution = ConfigurationManager.AppSettings["execution"].ToString();
            bool headless = bool.Parse(ConfigurationManager.AppSettings["headless"]);

            if (INSTANCE == null)
            {
                switch (browser)
                {
                    case "chrome":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = headless ? Browsers.GetLocalChromeHeadless() : Browsers.GetLocalChrome();
                        }

                        if (execution.Equals("remota"))
                        {
                            INSTANCE = headless ? Browsers.GetRemoteChromeHeadless() : Browsers.GetRemoteChrome();
                        }

                        break;

                    case "ie":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = Browsers.GetLocalInternetExplorer();
                        }

                        if (execution.Equals("remota"))
                        {
                            INSTANCE = Browsers.GetRemoteInternetExplorer();
                        }

                        break;

                    case "firefox":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = Browsers.GetLocalFirefox();
                        }

                        if (execution.Equals("remota"))
                        {
                            INSTANCE = Browsers.GetRemoteFirefox();
                        }

                        break;

                    case "edge":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = Browsers.GetLocalEdge();
                        }

                        if (execution.Equals("remota"))
                        {
                            INSTANCE = Browsers.GetRemoteEdge();
                        }

                        break;

                    default:
                        throw new Exception("O browser informado não existe ou não é suportado pela automação");
                }
            }
        }

        public static void QuitInstace()
        {
            INSTANCE.Quit();
            INSTANCE.Dispose();
            INSTANCE = null;
        }
    }
}
