using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("mihaela.mandic@mejl.com")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='View all'])[1]/following::div[3]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='View all'])[1]/following::strong[1]")).Click();
            driver.FindElement(By.XPath("//div[@id='newsletter-subscribe-block']/span")).Click();
            driver.FindElement(By.Id("newsletter-email")).Click();
            driver.FindElement(By.Id("newsletter-email")).Clear();
            driver.FindElement(By.Id("newsletter-email")).SendKeys("mihaela.mandic@mejl.com");
            driver.FindElement(By.Id("newsletter-subscribe-button")).Click();
            driver.FindElement(By.Id("newsletter-result-block")).Click();
            driver.FindElement(By.Id("newsletter-result-block")).Click();
            driver.FindElement(By.Id("newsletter-result-block")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=newsletter-result-block | ]]
            driver.FindElement(By.Id("newsletter-result-block")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
