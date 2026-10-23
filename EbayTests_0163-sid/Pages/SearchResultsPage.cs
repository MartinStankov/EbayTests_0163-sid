using OpenQA.Selenium;
using System;
using System.Linq;

namespace EbayTests_0163_sid.Pages
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool HasShippingTo(string countryCode)
        {
            //Url pattern is not always reliable, better to wait for the search results to be displayed and then check the page source for the shipping information
            //Wait.Until(d => d.Url.ToLower().Contains("/sch/") || d.Url.ToLower().Contains("nkw"));
            Wait.Until(d => d.FindElement(By.CssSelector(".srp-results, ul.srp-results")).Displayed);

            //Handles different variations of the shipping information text that may appear on the page
            try
            {
                // Wait for results to load first
                Wait.Until(d => d.FindElement(By.CssSelector(".srp-results, ul.srp-results")).Displayed);

                // Verify shipping text on the left/filter area by text content
                return Wait.Until(d =>
                {
                    var candidates = d.FindElements(By.XPath(
                        "//*[contains(normalize-space(.), 'Shipping to')]"));

                    return candidates.Any(e =>
                        e.Displayed &&
                        e.Text.Contains("Shipping to", StringComparison.OrdinalIgnoreCase) &&
                        e.Text.Contains(countryCode, StringComparison.OrdinalIgnoreCase));
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}