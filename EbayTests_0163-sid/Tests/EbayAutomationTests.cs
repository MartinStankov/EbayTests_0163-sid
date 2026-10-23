using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using EbayTests_0163_sid.Pages;

namespace EbayTests_0163_sid.Tests
{
    [TestFixture]
    public class EbayAutomationTests : BaseTest
    {
        [Test]
        [Description("1. Navigate to eBay homepage and verify that the page is loaded")]
        public void TC01_NavigateToEbayAndVerifyPageLoaded()
        {
            var homePage = new HomePage(Driver);
            homePage.NavigateTo();

            homePage.IsLoaded()
                .Should()
                .BeTrue("The eBay homepage should be loaded and the eBay logo should be visible.");

            Driver.Title.ToLower()
                .Should()
                .Contain("ebay", "The page title should contain 'eBay' to confirm that the correct page is loaded.");
        }

        [Test]
        [Description("2. Type Monopoly in Search field and click Search; verify that on the left side there is 'Shipping to : BGR'")]
        public void TC02_SearchMonopoly_ShouldDisplayShippingToBGR()
        {
            var homePage = new HomePage(Driver);
            homePage.NavigateTo();

            var resultsPage = homePage.SearchFor("Monopoly");
            
            resultsPage.HasShippingTo("BGR")
                .Should()
                .BeTrue("The search results should indicate that shipping is available to Bulgaria (BGR).");

        }

    }
}
