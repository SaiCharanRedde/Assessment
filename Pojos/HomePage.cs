using System;
using System.Collections;
using AventStack.ExtentReports;
using LawDepotAssessment.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace LawDepotAssessment.Pages
{

	public class HomePage : Base
	{

       private IWebDriver driver;
        ExtentTest test;
        public HomePage(IWebDriver driver,ExtentTest test)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.test = test;
        }
      


        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Swag Labs')]")]
        private IWebElement SwagLabsLogo;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Products')]")]
        private IWebElement ProductsHeading;

        [FindsBy(How = How.XPath, Using = "//select[@class='product_sort_container'] ")]
        private IWebElement Filter;

        
        public void ProductsHeadingValidation()
        {
            test.Log(Status.Info, "Products text Validated");
            Assert.That(ProductsHeading.Text, Is.EqualTo("Products"));
        }

        public void EmptyCart()
        {
            this.CartTotal = 0.0;
            test.Log(Status.Info, "Carty Emptied");
            IList<IWebElement> list = driver.FindElements(By.XPath("//button[contains(text(),'Remove')]"));
            if (list.Count > 0)
            {
                foreach (IWebElement element in list)
                {
                    element.Click();
                }
            }
        }


        public void applyFilter(String value)
        {

            Filter.Click();
            SelectElement select = new SelectElement(Filter);
            select.SelectByText(value);
            test.Log(Status.Info, "Filter Applied with "+value);

        }

        public ArrayList getAllPricesintoArray()
        {
            IList<IWebElement> list = driver.FindElements(By.XPath("//div[@class=\"inventory_item_price\"]"));
            ArrayList allvalues = new ArrayList();
            foreach(IWebElement ls in list)
            {
                allvalues.Add(((ls.Text).Substring(1)));   
            }
            return allvalues;

        }

        public double AddtoCArt(String value)
        {

            driver.FindElement(By.XPath("//div[contains(text(),\""+value+"\")]/parent::a/parent::div/following-sibling::div/button")).Click();

            String price = driver.FindElement(By.XPath("//div[contains(text(),\"" + value + "\")]/parent::a/parent::div/following-sibling::div/div")).Text;
            test.Log(Status.Info, "Added to cart worth $" + value);
            return Convert.ToDouble(price.Substring(1));

        }

        [FindsBy(How = How.XPath, Using = "//span[@class='shopping_cart_badge']/parent::a")]
        private IWebElement ShoopingCart;



        public CheckOut GotoCart()
        {
            ShoopingCart.Click();
            test.Log(Status.Info, "Cart image Clicked");
            return new CheckOut(driver,test);
        }
           
        
        


        public void RemoveFromecart(String value)
        {

            driver.FindElement(By.XPath("//div[contains(text(),\"" + value + "\")]/parent::a/parent::div/following-sibling::div/button")).Click();
            test.Log(Status.Info, $"Item {value} removed from Cart");
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Open Menu')]")]
        private IWebElement hamburger;
        [FindsBy(How = How.XPath, Using = " //a[contains(text(),'Logout')]")]
        private IWebElement LogOut;

       
        public void Logout()
        {
            hamburger.Click();
            LogOut.Click();
            test.Log(Status.Info, $"Logged Out Successfully");
        }

        public Boolean CheckOrder(String condition)
        {

            IList<IWebElement> list = driver.FindElements(By.XPath("//div[@class=\"inventory_item_price\"]"));
            ArrayList allvalues = new ArrayList();
            foreach (IWebElement ls in list)
            {
                allvalues.Add(((ls.Text).Substring(1)));
            }

            Boolean flag = true;
            switch (condition)
            {
                case "Price (low to high)":
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        if (Convert.ToDouble(allvalues[i]) > Convert.ToDouble(allvalues[i + 1]))
                        {
                            flag = false;
                        }

                    }
                    break;
                case "Name (Z to A)":


                    break;

                case "Name (A to Z)":


                    break;

                case "Price (high to low)":
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        if (Convert.ToDouble(list[i]) < Convert.ToDouble(list[i + 1]))
                        {
                            flag = false;
                        }

                    }

                    break;

            }

            Assert.That(flag, Is.True);

            return flag;

        }

    }

}

