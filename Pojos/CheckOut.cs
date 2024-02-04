using System;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LawDepotAssessment.Pages
{
    public class CheckOut
    {
        IWebDriver driver;
        ExtentTest test;
        public CheckOut(IWebDriver driver,ExtentTest test){
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.test = test;
        }


        [FindsBy(How = How.XPath, Using = "//button[@id='checkout']")]
        private IWebElement Checkout;


        [FindsBy(How = How.XPath, Using = "//button[@id='continue-shopping']")]
        private IWebElement ContinueShooping;


        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Remove')]")]
        private IWebElement RemoveFromCart;


        public void priceValidation(double price)
        {
            double totalPrice=0;
            TestContext.Progress.WriteLine(driver.FindElements(By.XPath("//div[@class='cart_item']/div/div/div")));
            IList<IWebElement> list= driver.FindElements(By.XPath("//div[@class='cart_item']/div/div/div"));
            foreach (IWebElement element in list)
            {
                totalPrice= totalPrice+ Convert.ToDouble((element.Text).Substring(1));
                TestContext.Progress.WriteLine(" In Price Validation");
            }
            Assert.That(totalPrice, Is.EqualTo(price));
            test.Log(Status.Info, "All products price verified $"+ price);
        }


        public FinalCheckout proceedToCheckOut()
        {
            Checkout.Click();
            return new FinalCheckout(driver,test);
        }

        public void ContinueShopping()
        {
            ContinueShooping.Click();
          
        }

        public double ValidatePrices(String value)
        {
            String cartValue = driver.FindElement(By.XPath("//div[contains(text(),\"" + value + "\")]/parent::a/following-sibling::div[2]/div")).Text;
            //    test.Log(Status.Info, "Opened Cart");
            return Convert.ToDouble(cartValue.Substring(1));
        }
       


    }



 


    
    
    
}

