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

        public async Task EnterSearchKeyword(string keyword)
        {
            // Assuming the advanced search input has a different selector
            await _page.FillAsync("#advancedSearchText", keyword);
        }

        public async Task ClickSearchButton()
        {
            // Assuming the advanced search button has a different selector
            await _page.ClickAsync("#advancedSearchButton");
        }

        public async Task<bool> IsResultWithKeywordPresent(string keyword)
        {
            // Adjust selector as per actual results table/list
            var content = await _page.ContentAsync();
            return content.Contains(keyword, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
