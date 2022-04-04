using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using CSharpSpecflowTemplate.Helpers;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace CSharpSpecflowTemplate.Helpers
{ 
    public class ExtentReportHelpers
    {
        private static ExtentTest feature; 
        private static ExtentTest scenario; 
        private static ExtentReports extent;

        static string reportName = ConfigurationManager.AppSettings["reportName"].ToString() +"_"+ DateTime.Now.ToString("dd-MM-yyyy_HH-mm");

        static string projectBinDebugPath = AppDomain.CurrentDomain.BaseDirectory;
        static FileInfo fileInfo = new FileInfo(projectBinDebugPath);
        static DirectoryInfo projectFolder = fileInfo.Directory;
        static string projectFolderPath = projectFolder.FullName;
        static string reportRootPath = projectFolderPath + "/Reports/";
        static string reportPath = projectFolderPath + "/Reports/" + reportName + "/";
        static string fileName = reportName + ".html";
        static string fullReportFilePath = reportPath + "_" + fileName;
  
        public static void ConfigureReport()
        {
            if (extent == null)
            {
                GeneralHelpers.EnsureDirectoryExists(reportRootPath);
                GeneralHelpers.EnsureDirectoryExists(reportPath);
                var reporter = new ExtentV3HtmlReporter(fullReportFilePath);

                extent = new ExtentReports();

                extent.AttachReporter(reporter);
            }
        }

        public static void CreateFeature()
        {
            feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        public static void CreateScenario()
        {
            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        public static void CreateStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (ConfigurationManager.AppSettings["GET_SCREENSHOT_FOR_EACH_STEP"].ToString().Equals("true"))
                {
                    switch (stepType)
                    {
                        case "Given":
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(GeneralHelpers.GetScreenshot(reportPath));
                            break;
                        case "When":
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(GeneralHelpers.GetScreenshot(reportPath));
                            break;
                        case "Then":
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(GeneralHelpers.GetScreenshot(reportPath));
                            break;
                        case "And":
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(GeneralHelpers.GetScreenshot(reportPath));
                            break;
                    }
                }
                else
                {
                    switch (stepType)
                    {
                        case "Given":
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                            break;
                        case "When":
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                            break;
                        case "Then":
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                            break;
                        case "And":
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                            break;
                    }
                }
            }

            if (ScenarioContext.Current.TestError != null)
            {
                switch (stepType)
                {
                    case "Given":
                        if (ScenarioContext.Current.TestError.InnerException == null)
                        {
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                        }
                        else
                        {
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioStepContext.Current.StepInfo.Text).Error("<pre>" + "Exception: " + ScenarioContext.Current.TestError.InnerException + "</pre>" + "<pre>" + "Stack Trace: " + ScenarioContext.Current.TestError.StackTrace + "</pre>").AddScreenCaptureFromPath(GeneralHelpers.GetScreenshot(reportPath));
                        }
                        break;

                    case "When":
                        if (ScenarioContext.Current.TestError.InnerException == null)
                        {
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                        }
                        else
                        {
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Error(ScenarioStepContext.Current.StepInfo.Text).Error("<pre>" + "Exception: " + ScenarioContext.Current.TestError.InnerException + "</pre>" + "<pre>" + "Stack Trace: " + ScenarioContext.Current.TestError.StackTrace + "</pre>").AddScreenCaptureFromPath(GeneralHelpers.GetScreenshot(reportPath));
                        }
                        break;

                    case "Then":
                        if (ScenarioContext.Current.TestError.InnerException == null)
                        {
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                        }
                        else
                        {
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Error(ScenarioStepContext.Current.StepInfo.Text).Error("<pre>" + "Exception: " + ScenarioContext.Current.TestError.InnerException + "</pre>" + "<pre>" + "Stack Trace: " + ScenarioContext.Current.TestError.StackTrace + "</pre>").AddScreenCaptureFromPath(GeneralHelpers.GetScreenshot(reportPath));
                        }
                        break;

                    case "And":
                        if (ScenarioContext.Current.TestError.InnerException == null)
                        {
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail("<pre>" + ScenarioContext.Current.TestError.Message + "</pre>");
                        }
                        else
                        {
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Error(ScenarioStepContext.Current.StepInfo.Text).Error("<pre>" + "Exception: " + ScenarioContext.Current.TestError.InnerException + "</pre>" + "<pre>" + "Stack Trace: " + ScenarioContext.Current.TestError.StackTrace + "</pre>").AddScreenCaptureFromPath(GeneralHelpers.GetScreenshot(reportPath));
                        }
                        break;
                }
            }
        }

        public static MediaEntityModelProvider GetScreenShotMedia()
        {
            string screenshotPath = GeneralHelpers.GetScreenshot(reportPath);
            TestContext.AddTestAttachment(screenshotPath);
            return MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath.Replace(reportPath, ".")).Build();
        }

        public static void FlushExtent()
        {       
            extent.Flush();
        }
    }
}
