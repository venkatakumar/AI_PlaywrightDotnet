using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlayDotnet.Pages
{
    public class AdvancedSearchPage
    {
        private readonly IPage _page;

        public AdvancedSearchPage(IPage page)
        {
            _page = page;
        }

        public async Task EnterAddressSearchKeyword(string keyword)
        {
            var locator = _page.Locator("[aria-label='Address-input']");
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await locator.FillAsync(keyword);
        }

        public async Task ClickSearchButton()
        {
            await _page.ClickAsync("button:has-text('Search')");
        }

        public async Task<bool> IsResultWithKeywordPresent(string keyword)
        {
            // Adjust selector as per actual results table/list
            var content = await _page.ContentAsync();
            return content.Contains(keyword, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
