using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlayDotnet.Pages
{
    public class SimpleSearchPage
    {
        private readonly IPage _page;
        public SimpleSearchPage(IPage page)
        {
            _page = page;
        }

        public async Task EnterSearchKeyword(string keyword)
        {
            var locator = _page.Locator("[aria-label='Enter your search']");
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await locator.FillAsync(keyword);
        }

        public async Task ClickSearchButton()
        {
            var locator = _page.Locator("[aria-label='Enter your search']");
            await locator.PressAsync("Enter");
        }

        public async Task<bool> IsResultWithKeywordPresent(string keyword)
        {
            var content = await _page.ContentAsync();
            return content.Contains(keyword, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
