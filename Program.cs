using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;


namespace OrangeHRMLoginTest
{
    class LoginTest
    {

        static IWebDriver driver = new ChromeDriver();

        static string url = "http://opensource.demo.orangehrmlive.com/";
        static string badLoginUrl = "http://opensource.demo.orangehrmlive.com/index.php/auth/validateCredentials";
        static string userNameId = "txtUsername";
        static string userPasswordId = "txtPassword";
        static string loginButtonId = "btnLogin";
        static string userName = "linda.anderson";
        static string userPassword = "linda.anderson";
        static string myInfoSectionId = "menu_pim_viewMyDetails";
        static string jobSectionCssSelector = "#sidenav > li.selected > a";
        //Main test case id = "TC_IM_01";
        //Specific Test Case id = "TC_J_01";
        //Team 5


        static IWebElement userNameInputField;
        static IWebElement userPasswordInputField;
        static IWebElement loginButton;
        static IWebElement myInfoSection;
        static IWebElement jobSection;



        static void Main()
        {
            driver.Navigate().GoToUrl(url);

            userNameInputField = driver.FindElement(By.Id(userNameId));

            userPasswordInputField = driver.FindElement(By.Id(userPasswordId));

            loginButton = driver.FindElement(By.Id(loginButtonId));

            userNameInputField.SendKeys(userName);





            if (userNameInputField.GetAttribute("value") == userName)
            {
                Console.WriteLine("User name input successful!");
            }

            if (userPasswordInputField.GetAttribute("value") == userPassword)
            {
                Console.WriteLine("User password input successful!");
            }

            userPasswordInputField.SendKeys(userPassword);

            loginButton.Click();

            if (driver.Url != url && driver.Url != badLoginUrl)
            {
                Console.WriteLine("User logged in successfully!");


                myInfoSection = driver.FindElement(By.Id(myInfoSectionId));

                if (myInfoSection.Displayed)
                {
                    myInfoSection.Click();

                    Console.WriteLine("User successfully open My Info Section");

                    try
                    {

                        jobSection = driver.FindElement(By.CssSelector(jobSectionCssSelector));

                        if (jobSection.Displayed)
                        {

                            jobSection.Click();

                            GreenMessage("User successfully sees the job section");
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        RedMessage("User cannot see the Job section");
                    }



                }
            }






            Thread.Sleep(5000);
            driver.Quit();

        }
        private static void RedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void GreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

