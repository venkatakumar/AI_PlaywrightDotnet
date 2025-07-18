using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using PlayDotnet.Pages;

namespace PlayDotnet.Tests
{
    public class AdvancedSearchTests
    {
        private IBrowser? _browser;
        private IPage? _page;
        private IPlaywright? _playwright;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _page = await _browser.NewPageAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
            }
            _playwright?.Dispose();
        }

        [Test]
        public async Task AdvancedSearch_ShouldReturnResults_WithKeywordLA04()
        {
            // Go to the main/simple search page
            await _page.GotoAsync("https://planningregister.planningsystemni.gov.uk/simple-search");
            // Click the 'Advanced search' link/button on the left
            await _page.ClickAsync("a:has-text('Advanced search')");
            // Wait for navigation to advanced search
            await _page.WaitForURLAsync("**/advanced-search");

            var searchPage = new AdvancedSearchPage(_page);
            await searchPage.EnterAddressSearchKeyword("LA04");
            await searchPage.ClickSearchButton();
            await _page.WaitForTimeoutAsync(3000); // Wait for results to load
            (await searchPage.IsResultWithKeywordPresent("LA04")).Should().BeTrue("Search results should contain 'LA04'");
        }
    }
}
