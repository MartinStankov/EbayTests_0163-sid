using OpenQA.Selenium;
using System;

namespace EbayTests_0163_sid.Pages
{
    public class HomePage : BasePage
    {
        private const string PageURL = "https://www.ebay.com/";

        private readonly By _ebayLogo = By.CssSelector("#gh-la, #gh-logo, a[aria-label*='eBay']");
        private readonly By _searchInput = By.Id("gh-ac");
        private readonly By _searchButton = By.Id("gh-btn");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        //public HomePage NavigateTo()
        //{
        //    Driver.Navigate().GoToUrl(PageURL);
        //    Wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState")?.ToString() == "complete");
        //    return this;
        //}

        public HomePage NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageURL);
            Wait.Until(d => ((IJavaScriptExecutor)d)
                .ExecuteScript("return document.readyState")?.ToString() == "complete");

            // retry once if temporary eBay error page appears
            if (Driver.Title.Contains("Error Page", StringComparison.OrdinalIgnoreCase) ||
                Driver.PageSource.Contains("Something went wrong on our end", StringComparison.OrdinalIgnoreCase))
            {
                Driver.Navigate().Refresh();
                Wait.Until(d => ((IJavaScriptExecutor)d)
                    .ExecuteScript("return document.readyState")?.ToString() == "complete");
            }

            return this;
        }

        public bool IsLoaded()
        {
            try
            {
                var logo = WaitForElement(_ebayLogo);
                return logo != null && logo.Displayed && Driver.Url.Contains("ebay.com", StringComparison.OrdinalIgnoreCase);
            }
            catch (WebDriverTimeoutException)
            {
                return Driver.Title.Contains("ebay", StringComparison.OrdinalIgnoreCase)
                    && Driver.Url.Contains("ebay.com", StringComparison.OrdinalIgnoreCase);
            }
        }

        public SearchResultsPage SearchFor(string searchTerm)
        {
            var searchBox = WaitForElement(_searchInput);
            searchBox.Clear();
            searchBox.SendKeys(searchTerm);

            // Trying a click on the search button, but if it fails, we will press Enter in the search box instead (we try to capture all possible exceptions that may occur when clicking the search button)
            try
            {
                var searchBtn = Driver.FindElement(_searchButton);
                searchBtn.Click();
            }
            catch (NoSuchElementException)
            {
                searchBox.SendKeys(Keys.Enter);
            }
            catch (ElementClickInterceptedException)
            {
                searchBox.SendKeys(Keys.Enter);
            }
            catch (ElementNotInteractableException)
            {
                searchBox.SendKeys(Keys.Enter);
            }

            return new SearchResultsPage(Driver);
        }
    }
}