# EbayTests_0163-sid

NUnit UI automation project for eBay, built with Selenium WebDriver in C# using the Page Object Model (POM).

The Project is Built For Software Testing Discipline in University of Library Studies and Information Technologies (UNIBIT).

## Project Goal

Automate and validate:

1. Navigate to `https://ebay.com/` and verify the page is loaded.
2. Search for `Monopoly` and verify on the left side that shipping is set to `BGR`.

## Test Cases

### TC01_NavigateToEbayAndVerifyPageLoaded
- Open eBay home page
- Verify page is loaded (logo/title/url checks)

### TC02_SearchMonopoly_ShouldDisplayShippingToBGR
- Type `Monopoly` in search
- Click Search
- Verify left-side section contains shipping destination with `BGR`

## How to Run

### Visual Studio
1. Open solution `EbayTests_0163-sid.slnx`
2. Build solution (You Could Use Control+Shift+B)
3. Run tests from **Test Explorer** (Tests > Run All Tests)

## After Executing the Tests

You're going to encounter Google Chrome Testing opening twice.

The first time is like the picture below (and it closes by itself after 5 seconds, can be configured in [`Tests/BaseTest.cs`](EbayTests_0163-sid/Tests/BaseTest.cs).
![TC01 - Home Page](/screenshots/FirstTestScreenshot.png)

The second run looks like this and you will have 15 seconds to verify if everything is correct (can also be reconfigured in: [`Tests/BaseTest.cs`](EbayTests_0163-sid/Tests/BaseTest.cs)) and also set the shipping to `BGR`:

![TC02 - Search Results](/screenshots/SecondTestResults.png)
