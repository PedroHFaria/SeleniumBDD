using CSharpSpecflowTemplate.Helpers;
using TechTalk.SpecFlow;


namespace CSharpSpecflowTemplate.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportHelpers.ConfigureReport();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            ExtentReportHelpers.CreateFeature();
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            ExtentReportHelpers.CreateScenario();
            DriverFactory.CreateInstance();
            DriverFactory.INSTANCE.Manage().Window.Maximize();
        }

        [AfterStep]
        public static void AfterStep()
        {
            ExtentReportHelpers.CreateStep();
        }

        [AfterScenario]
        public static void TearDownScenario()
        {
            DriverFactory.QuitInstace();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportHelpers.FlushExtent();
        }
    }
}
