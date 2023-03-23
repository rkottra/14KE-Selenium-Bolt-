using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14KE_Selenium
{
    
    internal class TesztLoginElőtt
    {
        FirefoxDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("--headless");
            this.driver = new FirefoxDriver(options);
            this.driver.Url = "http://localhost:4200/";
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
            IWebElement legend = driver.FindElement(By.XPath("//fieldset/legend"));
            Assert.AreEqual(legend.Text, "Login");
        }

        [Test]
        public void EditButtonTest()
        {
             Assert.IsNull(FindMatIcon("//mat-icon"));
        }

        private IWebElement? FindMatIcon(string xpath)
        {
            try
            {
                return driver.FindElement(By.XPath(xpath));
            }
            catch
            {
                return null;
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            this.driver.Quit();
        }
    }
}
