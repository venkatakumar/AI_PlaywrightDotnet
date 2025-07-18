using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PlayDotnet.Pages;

using FluentAssertions;

namespace PlayDotnet.Tests
{
    public class SimpleSearchTests
    {
        private IBrowser? _browser;
        private IPage? _page;
        private IPlaywright? _playwright;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
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
        public async Task Search_ShouldReturnResults_WithKeywordBt1()
        {
            var searchPage = new SimpleSearchPage(_page);
            await _page.GotoAsync("https://planningregister.planningsystemni.gov.uk/simple-search");
            await searchPage.EnterSearchKeyword("bt1");
            await searchPage.ClickSearchButton();
            await _page.WaitForTimeoutAsync(3000); // Wait for results to load
            (await searchPage.IsResultWithKeywordPresent("bt1")).Should().BeTrue("Search results should contain 'bt1'");
        }
    }
}
