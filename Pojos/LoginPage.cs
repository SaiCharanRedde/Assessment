using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using LawDepotAssessment.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LawDepotAssessment.Pages
{
	public class LoginPage 
	{
        private IWebDriver driver;
        ExtentTest test;
        public LoginPage(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.test = test;
        }


        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement Usr;

        public IWebElement getUsername()
        {
            return Usr;
        }


        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        public IWebElement getPassword()
        {
            return password;
        }

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement Login;

        public IWebElement getLogin()
        {
            return Login;
        }


        public HomePage loginTask(String username, String pwd)
        {
            Usr.SendKeys(username);
            password.SendKeys(pwd);
            Login.Click();
            test.Log(Status.Info, "Logged In SuccessFully with "+username);

            return new HomePage(driver,test);
        }

        [FindsBy(How = How.Id, Using = "//h3[contains(text(),'Epic sadface: Sorry, this user has been locked out.')]")]
        private IWebElement LockedUserError;

       
        public void LockedUser()
        {
           Base classBase = new Base();
           String errorMessage = "//h3[contains(text(),'Epic sadface: Sorry, this user has been locked out.')]";
           classBase.ExplicitWaitMethod(driver,13, errorMessage, "Epic sadface: Sorry, this user has been locked out.");
           test.Log(Status.Info, "Epic sadface: Sorry, this user has been locked out");
           Assert.Equals(errorMessage, "Epic sadface: Sorry, this user has been locked out.");

        }
        public String getValue(String value)
        {
            return new JsonReader().ExtractData(value);
        }

        public void AlertHandling(String cond)
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                switch (cond)
                {
                    case "ok":
                        alert.Accept();
                        test.Log(Status.Info, "Alert Accept");
                        break;
                    case "dismiss":
                        alert.Dismiss();
                        test.Log(Status.Info, "Alert Dismiss");
                        break;
                    default:
                        break;

                }
            }catch
            {
                Exception E;
            }



        }





    }
}

