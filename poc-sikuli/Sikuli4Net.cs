using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_sikuli
{
    public class Sikuli4Net
    {
        static IWebDriver driver;

        APILauncher launcher = new APILauncher(true);

        [OneTimeSetUp]
        public void ClassInitialize()
        {

            launcher.Start();
            driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin?service=mail&continue=https://mail.google.com/mail/#identifier");
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            driver.Quit();
            launcher.Stop();
        }


        [Test]
        public void Sikuli4NetTest()
        {
            //Screen
            Screen loginPage = new Screen();

            //Pattern

            Pattern nextButton = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\nextButton.png"));
            Pattern userNameInput = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\emailInput.png"));

            Pattern userPassInput = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\passwordInput.png"));
            Pattern searchEmailInput = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\searchEmailInput.png"));

            //Waiting until the user name input is present
            loginPage.Wait(userNameInput);

            //Setting user name and password
            loginPage.Type(userNameInput, "abarrazabriones", KeyModifier.NONE);

            //Clicking on the Next button
            loginPage.Click(nextButton);

            //Waiting until the password input is present
            loginPage.Wait(userPassInput);

            //Setting user name and password
            loginPage.Type(userPassInput, "cacuca13", KeyModifier.NONE);

            //Clicking on the "Sign in" button
            loginPage.Click(nextButton);

            //Waiting until the search email input is present
            loginPage.Wait(searchEmailInput);

        }
    }
}
