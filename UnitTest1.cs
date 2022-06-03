using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverWaitTests
{
    public class WaitTests
    {
        private WebDriver driver;
        private WebDriverWait wait;

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Wait_THreadSleep()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            //var element = driver.FindElement(By.PartialLinkText("This is"));
            var element = driver.FindElement(By.CssSelector("body > div.container.body-content > div:nth-child(1) > div:nth-child(1) > a"));

            element.Click();

            Thread.Sleep(15000);

            var text_element = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotNull(text_element);


        }

        [Test]
        public void Test_Wait_ImplicitWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            //var element = driver.FindElement(By.PartialLinkText("This is"));
            var element = driver.FindElement(By.CssSelector("body > div.container.body-content > div:nth-child(1) > div:nth-child(1) > a"));

            element.Click();


            //var text_element = driver.FindElement(By.ClassName("Contact")).Text;

            //Assert.IsNotNull(text_element);


        }
        [Test]
        public void Test_Wait_ExPlicit()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            //var element = driver.FindElement(By.PartialLinkText("This is"));
            var element = driver.FindElement(By.CssSelector("body > div.container.body-content > div:nth-child(1) > div:nth-child(1) > a"));

            element.Click();

            var text_element = wait.Until(d =>
            {
                return driver.FindElement(By.CssSelector("body > div.container.body-content > div:nth-child(1) > div:nth-child(1) > a"));
            });
            
            Assert.IsNotNull(text_element);

        }
        [Test]
        public void Test_Wait_ExpectedConditions()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            //var element = driver.FindElement(By.PartialLinkText("This is"));
            var element = driver.FindElement(By.CssSelector("body > div.container.body-content > div:nth-child(1) > div:nth-child(1) > a"));

            element.Click();

            var text_element = this.wait.Until(
                ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.container.body-content > div:nth-child(1) > div:nth-child(1) > a"))
            );

            Assert.IsNotNull(text_element);
        }

            

        }
}