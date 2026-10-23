using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace EbayTests_0163_sid.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--lang=en-US");

            // Do NOT spoof user-agent or override navigator.webdriver.
            Driver = new ChromeDriver(options);
        }
        //[SetUp]
        //public void SetUp()
        //{
        //    var options = new ChromeOptions();

        //    // Remove bot markers which Ebay detects (trying to make automation less detectable, annoying bot protection :angry: )
        //    options.AddArgument("--start-maximized");
        //    options.AddArgument("--disable-notifications");
        //    options.AddArgument("--disable-blink-features=AutomationControlled");
        //    options.AddExcludedArgument("enable-automation");
        //    options.AddAdditionalOption("useAutomationExtension", false);

        //    // Provide Real Headers (to pretend to be a real user and mimic a normal browser)
        //    options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/130.0.0.0 Safari/537.36");

        //    var chromeDriver = new ChromeDriver(options);

        //    // Removes flag navigator.webdriver through CDP on ChromeDriver (injects JS via CDP to hite Selenium's automation flag)
        //    chromeDriver.ExecuteCdpCommand(
        //        "Page.addScriptToEvaluateOnNewDocument",
        //        new Dictionary<string, object>
        //        {
        //            { "source", "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})" }
        //        }
        //    );

        //    Driver = chromeDriver;
        //}

        [TearDown]


        public void TearDown()
        {
            // Delay only for the tests, so it's all clearly visable (first one by 5 seconds, second one by 15 seconds currently)
            if (TestContext.CurrentContext.Test.Name == "TC01_NavigateToEbayAndVerifyPageLoaded")
            {
                Thread.Sleep(5000);
            }
            else if (TestContext.CurrentContext.Test.Name == "TC02_SearchMonopoly_ShouldDisplayShippingToBGR")
            {
                Thread.Sleep(15000);
            }
         
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}