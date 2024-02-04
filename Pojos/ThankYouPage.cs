using System;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LawDepotAssessment.Pages
{
	public class ThankYouPage
	{
        IWebDriver driver;
        ExtentTest test;
        public ThankYouPage(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.test = test;
        }

        [FindsBy(How = How.XPath, Using = " //button[contains(text(),'Back Home')]")]
        private IWebElement BackHomeButton;

        public void BackHome()
        {
            BackHomeButton.Click();
            test.Log(Status.Info, "Back To Home Button Clicked");
        }
    }
}

