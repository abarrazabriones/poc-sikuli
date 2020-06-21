using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using SikuliSharp;
using System;
using System.IO;

namespace poc_sikuli
{
    public class SikuliSharp
    {
        static IWebDriver driver;

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin?service=mail&continue=https://mail.google.com/mail/#identifier");
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            driver.Quit();
        }


        [Test]
        public void SikuliSharpTest()
        {
            using (var loginPage = Sikuli.CreateSession())
            {
                //Patterns
                var nextButton = Patterns.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\nextButton.png"));
                var userNameInput = Patterns.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\emailInput.png"));

                var userPassInput = Patterns.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\passwordInput.png"));
                var searchEmailInput = Patterns.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\searchEmailInput.png"));

                //Waiting until the user name input is present
                loginPage.Wait(userNameInput);

                //Setting user name and password
                loginPage.Type("abarrazabriones");

                //Clicking on the Next button
                loginPage.Click(nextButton);

                //Waiting until the password input is present
                loginPage.Wait(userPassInput);

                //Setting user name and password
                loginPage.Type("cacuca13");

                //Clicking on the "Sign in" button
                loginPage.Click(nextButton);

                //Waiting until the search email input is present
                loginPage.Wait(searchEmailInput);
            }
        }
    }
}
