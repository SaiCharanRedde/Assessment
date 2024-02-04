using AventStack.ExtentReports;
using LawDepotAssessment.Pages;
using LawDepotAssessment.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections;

namespace LawDepotAssessment.TestFiles
{
    [Parallelizable(ParallelScope.Self)]
    public class CompleteFlow : Base
    {



        [Test,Category("Standard_User")]
        public void standard_user_CheckOut()
        {
            LoginPage loginpage = new LoginPage(driver,test);

            String Username = getValue("username1");
            String Password = getValue("password");

            HomePage homepage = loginpage.loginTask(Username, Password);
            homepage.applyFilter("Price (low to high)");
            homepage.CheckOrder("Price (low to high)");
            homepage.EmptyCart();
            CartTotal = 0;
            String producttoAdd = getValue("product1");
            CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd);
            CheckOut checkout = homepage.GotoCart();
            checkout.priceValidation(CartTotal);
            checkout.ContinueShopping();
            
            String producttoAdd2 = getValue("product2");
            CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd2);
            homepage.GotoCart();
            checkout.priceValidation(CartTotal);
            FinalCheckout finalCheckOut= checkout.proceedToCheckOut();
            finalCheckOut.AddDetails(getValue("FirstName"), getValue("LastName"), getValue("ZipCode"));
            OverView Overview=finalCheckOut.ContinueClick();
            Overview.priceValidation(CartTotal);
            Overview.ShippingDetailsVerified();
            Overview.CheckTotal(CartTotal);
            test.Log(Status.Info, performScreenShot(driver));
            ThankYouPage thankyou=Overview.getFinish();
            test.Log(Status.Info, performScreenShot(driver));
            thankyou.BackHome();
            homepage.Logout();



        }


        [Test ,Category("Locked_User")]
        public void LockedUser_CheckOut()
        {
            IWebDriver driver = getDriver();
            String Username = getValue("username4");
            String Password = getValue("password");

            LoginPage loginpage = new LoginPage(driver,test);
            loginpage.loginTask(Username, Password);
            loginpage.LockedUser();
        }

        [Test, Category("Performance_User")]
        public void PerformanceUser_CheckOut()
        {

            LoginPage loginpage = new LoginPage(driver,test);

            String Username = getValue("username5");
            String Password = getValue("password");

            HomePage homepage = loginpage.loginTask(Username, Password);
            homepage.applyFilter("Price (low to high)");
            homepage.CheckOrder("Price (low to high)");
            homepage.EmptyCart();
            CartTotal = 0;
            String producttoAdd = getValue("product1");
            CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd);
            
            CheckOut checkout = homepage.GotoCart();
            checkout.priceValidation(CartTotal);
            checkout.ContinueShopping();
            String producttoAdd2 = getValue("product2"); ;
            CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd2);
            
            homepage.GotoCart();
            checkout.priceValidation(CartTotal);
            FinalCheckout finalCheckOut = checkout.proceedToCheckOut();
            finalCheckOut.AddDetails(getValue("FirstName"), getValue("LastName"), getValue("ZipCode"));
            OverView Overview = finalCheckOut.ContinueClick();
            Overview.priceValidation(CartTotal);
            Overview.ShippingDetailsVerified();
            Overview.CheckTotal(CartTotal);
            test.Log(Status.Info, performScreenShot(driver));
            ThankYouPage thankyou = Overview.getFinish();
            test.Log(Status.Info, performScreenShot(driver));
            thankyou.BackHome();
            homepage.Logout();




        }

        [Test, Category("Problem_User")]
        public void problem_user_CheckOut()
        {
            {


                LoginPage loginpage = new LoginPage(driver,test);

                String Username = getValue("username2");
                String Password = getValue("password");

                HomePage homepage = loginpage.loginTask(Username, Password);
                homepage.applyFilter("Price (low to high)");
                homepage.CheckOrder("Price (low to high)");
                homepage.EmptyCart();
                CartTotal = 0;
                String producttoAdd = getValue("product1");
                CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd);
                CheckOut checkout = homepage.GotoCart();
                checkout.priceValidation(CartTotal);
                checkout.ContinueShopping();

                String producttoAdd2 = getValue("product2"); ;
                CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd2);
                homepage.GotoCart();
                checkout.priceValidation(CartTotal);
                FinalCheckout finalCheckOut = checkout.proceedToCheckOut();
                finalCheckOut.AddDetails(getValue("FirstName"), getValue("LastName"), getValue("ZipCode"));
                OverView Overview = finalCheckOut.ContinueClick();
                Overview.priceValidation(CartTotal);
                Overview.ShippingDetailsVerified();
                Overview.CheckTotal(CartTotal);
                test.Log(Status.Info, performScreenShot(driver));
                ThankYouPage thankyou = Overview.getFinish();
                test.Log(Status.Info, performScreenShot(driver));
                thankyou.BackHome();
                homepage.Logout();


            }
        }
        [Test, Category("error_user")]
        public void error_user_CheckOut()
        {
            {


                LoginPage loginpage = new LoginPage(driver,test);

                String Username = getValue("username3");
                String Password = getValue("password");

                
               
                HomePage homepage = loginpage.loginTask(Username, Password);
                Thread.Sleep(3000);
                loginpage.AlertHandling("ok");
                homepage.applyFilter("Price (low to high)");
                homepage.CheckOrder("Price (low to high)");
                homepage.EmptyCart();
                CartTotal = 0;
                String producttoAdd = getValue("product1");
                CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd);
                CheckOut checkout = homepage.GotoCart();
                checkout.priceValidation(CartTotal);
                checkout.ContinueShopping();

                String producttoAdd2 = getValue("product2"); ;
                CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd2);
                homepage.GotoCart();
                checkout.priceValidation(CartTotal);
                FinalCheckout finalCheckOut = checkout.proceedToCheckOut();
                finalCheckOut.AddDetails(getValue("FirstName"), getValue("LastName"), getValue("ZipCode"));
                OverView Overview = finalCheckOut.ContinueClick();
                Overview.priceValidation(CartTotal);
                Overview.ShippingDetailsVerified();
                Overview.CheckTotal(CartTotal);
                test.Log(Status.Info, performScreenShot(driver));
                ThankYouPage thankyou = Overview.getFinish();
                test.Log(Status.Info, performScreenShot(driver));
                thankyou.BackHome();
                homepage.Logout();


            }


        }
        [Test, Category("Visual_User")]
        public void visual_user_CheckOut()
        {
            {


                LoginPage loginpage = new LoginPage(driver,test);

                String Username = getValue("username6");
                String Password = getValue("password");

                HomePage homepage = loginpage.loginTask(Username, Password);
                homepage.applyFilter("Price (low to high)");
                homepage.CheckOrder("Price (low to high)");
                homepage.EmptyCart();
                CartTotal = 0;
                String producttoAdd = getValue("product1");
                CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd);
                CheckOut checkout = homepage.GotoCart();
                checkout.priceValidation(CartTotal);
                checkout.ContinueShopping();

                String producttoAdd2 = getValue("product2"); ;
                CartTotal = CartTotal + homepage.AddtoCArt(producttoAdd2);
                homepage.GotoCart();
                checkout.priceValidation(CartTotal);
                FinalCheckout finalCheckOut = checkout.proceedToCheckOut();
                finalCheckOut.AddDetails(getValue("FirstName"), getValue("LastName"), getValue("ZipCode"));
                OverView Overview = finalCheckOut.ContinueClick();
                Overview.priceValidation(CartTotal);
                Overview.ShippingDetailsVerified();
                Overview.CheckTotal(CartTotal);
                test.Log(Status.Info, performScreenShot(driver));
                ThankYouPage thankyou = Overview.getFinish();
                test.Log(Status.Info, performScreenShot(driver));
                thankyou.BackHome();
                homepage.Logout();


            }



        }
    }

}


