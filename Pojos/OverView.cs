using System;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LawDepotAssessment.Pages
{
	public class OverView
	{
        IWebDriver driver;
        ExtentTest test;
        public OverView(IWebDriver driver,ExtentTest test)
        {
          this.driver = driver;
          PageFactory.InitElements(driver, this);
           this.test = test;
        }

        [FindsBy(How = How.XPath, Using = "//button[@id='finish']")]
        private IWebElement Finish;

        [FindsBy(How = How.XPath, Using = "//button[@id='cancel']")]
        private IWebElement Cancel;


        public double ValidateProductFinal(String product)
        {
            String cartValue = driver.FindElement(By.XPath("//div[contains(text(),\"" + product + "\")]/parent::a/following-sibling::div[2]/div")).Text;
            return Convert.ToDouble(cartValue.Substring(1));
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='summary_info']/div[2]")]
        private IWebElement PaymentInformation;

        [FindsBy(How = How.XPath, Using = "//div[@class='summary_info']/div[4]")]
        private IWebElement ShippingInfo;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Price Total')]/following-sibling::div[1]")]
        private IWebElement Total;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Price Total')]/following-sibling::div[2]")]
        private IWebElement Tax;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Price Total')]/following-sibling::div[3]")]
        private IWebElement SubTotal;

        public ThankYouPage getFinish()
        {
            Finish.Click();
            return new ThankYouPage(driver,test);
        }
        public void priceValidation(double price)
        {
            double totalPrice = 0;
            TestContext.Progress.WriteLine(driver.FindElements(By.XPath("//div[@class='cart_item']/div/div/div")));
            IList<IWebElement> list = driver.FindElements(By.XPath("//div[@class='cart_item']/div/div/div"));
            foreach (IWebElement element in list)
            {
                totalPrice = totalPrice + Convert.ToDouble((element.Text).Substring(1));
                TestContext.Progress.WriteLine(" In Price Validation");
            }
            Assert.That(totalPrice, Is.EqualTo(price));
            test.Log(Status.Info, "All products price verified $" + price);
        }

        public void ShippingDetailsVerified()
        {
            Assert.That(PaymentInformation.Text, Is.EqualTo("SauceCard #31337"));
            test.Log(Status.Info, "PaymentInformation is "+ PaymentInformation.Text);
            Assert.That(ShippingInfo.Text, Is.EqualTo("Free Pony Express Delivery!"));
            test.Log(Status.Info, "Shipping Information is " + ShippingInfo.Text);
        }

        public void CheckTotal(Double cartTotal)
        {
            
            String[] value = (Total.Text).Split("$");
            String[] Taxvalue = (Tax.Text).Split("$");
            String[] subtotal = (SubTotal.Text).Split("$");
            double total=Convert.ToDouble(value[1]);
            double tax=Convert.ToDouble(subtotal[1]);
            double FullAmount = Convert.ToDouble(Taxvalue[1]);
            Assert.That(total, Is.EqualTo(cartTotal));
            test.Log(Status.Info, "Validated Item Total with CartTotal");
            test.Log(Status.Info, "Tax is "+Tax.Text);

            if (cartTotal == total)
            {
                test.Log(Status.Info, "Validated Item Total with CartTotal");
                
            }
            if((total+tax)== FullAmount)
            test.Log(Status.Info, "Total Price is Validate After Taxes");
       
        }

        
    }
}

