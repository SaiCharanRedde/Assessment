using System.Collections;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework.Interfaces;
using SeleniumExtras.WaitHelpers;

namespace LawDepotAssessment.Utils
{

    public class Base 
	{


        public IWebDriver driver;

        public String browser,URL;
        ExtentReports extent;
        public ExtentTest test;
        ExtentHtmlReporter reporter;
        public double CartTotal = 0;


     
        //Desc:- initializing the ExtentReportgenerator
        [OneTimeSetUp]
        public void ExtentReportsGenerator()
        {
            
             String LocalDrirectory = Environment.CurrentDirectory;
             String ProjDirect = Directory.GetParent(LocalDrirectory).Parent.Parent.FullName;
             String Path=ProjDirect + "\\Reports\\ExtentReport.html";

            TestContext.Progress.WriteLine("Hi in Onetimesetup");
           

             reporter = new ExtentHtmlReporter(Path);

             extent = new ExtentReports();
             extent.AttachReporter(reporter);
             extent.AddSystemInfo("Host Name", "Swag Labs");
             extent.AddSystemInfo("Assessment", "LawDepot");
             extent.AddSystemInfo("User", "Sai Charan Reddy M");
            

        }

        //Invoking Browser and Creating Test 
        [SetUp]
        public void InvokingBrowser()
        {
         
            
            String testName = TestContext.CurrentContext.Test.Name;
            test=extent.CreateTest(testName);
            
            String browser = getValue("browser");
            String URL = getValue("URL");


            switch (browser)
            {
                case "chrome":
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    }
                case "firefox":
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    }
            }
            driver.Url = URL;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            TestContext.Progress.WriteLine("Hi in setup");
        }  

        //Explicit Wait Method for Specific Elements
        public void ExplicitWaitMethod(IWebDriver driver,int seconds, String xpath, String text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.XPath(xpath)), text));
        }


        //To Perform ScreenShot
        public MediaEntityModelProvider performScreenShot(IWebDriver driver)
        {
            ITakesScreenshot Sc =(ITakesScreenshot)driver;
            String base64=Sc.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64, "ScreenShot " + getInstance()).Build();

            
        }

        //Gives Instance in specified Format
        public String getInstance()
        {
            DateTime T = DateTime.Now;
            String instance = T.ToString("h_mm_ss");
            return instance;
        }

        //Closing Browser and Extent 
        [TearDown]
        public void CloseBrowser()
        {
            

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            String trace=TestContext.CurrentContext.Result.StackTrace;

            if (status==TestStatus.Failed)
            {
                test.Log(Status.Fail, "Test failed due to" + trace);
                //test.Log(Status.Fail, performScreenShot(driver));
                test.Fail(trace, performScreenShot(driver));
            }else if (status == TestStatus.Passed)
            {
                 test.Pass("TestPassed", performScreenShot(driver));
            }
 
            
            driver.Close();
            driver.Quit();
        }

        public void LogToReport(String log)
        {
            test.Log(Status.Info, log);
        }
        public void AddScreenShottoReport()
        {
            test.Log(Status.Info, performScreenShot(driver));
        }


        [OneTimeTearDown]
        public void TearingDown()
        {
            
            extent.Flush();
            TestContext.Progress.WriteLine("After Flush");
        }
        
        public void ExtentFlush()
        {
            extent.Flush();
        }
        public IWebDriver getDriver()
        {
            return driver;
        }

        public void Dispose()
        {
            driver?.Dispose();

        }

      

        public String getValue(String value)
        {
            return new JsonReader().ExtractData(value);
        }
       

    }
}

