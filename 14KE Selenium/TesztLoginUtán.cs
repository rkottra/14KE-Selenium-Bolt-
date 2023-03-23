using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14KE_Selenium
{
    
    internal class TesztLoginUtán
    {
        FirefoxDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("--headless");
            this.driver = new FirefoxDriver(options);
            this.driver.Url = "http://localhost:4200/";

            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            var div = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//fieldset/input[@type=\"button\"]")));

            /*IJavaScriptExecutor js = (IJavaScriptExecutor)this.driver;
            js.ExecuteScript("sessionStorage.removeItem('token');");
            this.driver.Navigate().Refresh();*/

            this.InteractLogin();
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value=\"Logout\"]")));
        }

        [Test]
        public void FejlécTest()
        {
            IWebElement h1 = driver.FindElement(By.XPath("//header/h1"));
            Assert.AreEqual(h1.Text, "Bolt");
        }

        [Test]
        public void LoginAblakTest()
        {
            IWebElement logout = driver.FindElement(By.XPath("//fieldset/input[@type=\"button\"]"));
            Assert.AreEqual(logout.GetAttribute("value"), "Logout");
        }

        [Test]
        public void EditButtonTest()
        {
            Boolean matIconShow = driver.FindElement(By.XPath("//mat-icon")).Displayed;
            Assert.IsTrue(matIconShow);
            IWebElement matIcon = driver.FindElement(By.XPath("//mat-icon"));
            Assert.AreEqual(matIcon.Text, "edit");
        }

        private void InteractLogin()
        {
            IWebElement inputEmail = driver.FindElement(By.Id("email"));
            inputEmail.Clear();
            inputEmail.SendKeys("kottra.richard@jedlik.eu");

            IWebElement inputPassword = driver.FindElement(By.Id("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("123");

            IWebElement loginButton = driver.FindElement(By.XPath("//fieldset/input[@type=\"button\"]"));

            loginButton.Click();

            Thread.Sleep(1000);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            this.driver.Quit();
        }
    }
}
