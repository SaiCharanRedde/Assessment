using System;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LawDepotAssessment.Pages
{
	public class FinalCheckout
	{
        IWebDriver driver;
        ExtentTest test;
        public FinalCheckout(IWebDriver driver,ExtentTest test)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.test = test;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='first-name']")]
        private IWebElement FirstName;

        [FindsBy(How = How.XPath, Using = "//input[@id='last-name']")]
        private IWebElement LastName;

        [FindsBy(How = How.XPath, Using = "//input[@id='postal-code']")]
        private IWebElement PostalCode;


        public void AddDetails(String fn, String ln, String postalcode)
        {
            FirstName.SendKeys(fn);
            LastName.SendKeys(ln);
            PostalCode.SendKeys(postalcode);
            test.Log(Status.Info, "Checked out with " + fn + "  " + ln+"  "+postalcode);
        }

       

        [FindsBy(How = How.XPath, Using = "//input[@id='continue']")]
        private IWebElement Continue;

        [FindsBy(How = How.XPath, Using = "//button[@id='cancel']")]
        private IWebElement Cancel;


        public IWebElement getCancel()
        {
            return Cancel;
        }

        public OverView ContinueClick()
        {
            Continue.Click();
            return new OverView(driver,test);
        }


      


    }
}

