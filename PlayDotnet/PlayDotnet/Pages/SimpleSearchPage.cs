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
            await _page.FillAsync("#simpleSearchString", keyword);
        }

        public async Task ClickSearchButton()
        {
            await _page.ClickAsync("#simpleSearchButton");
        }

        public async Task<bool> IsResultWithKeywordPresent(string keyword)
        {
            var content = await _page.ContentAsync();
            return content.Contains(keyword, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
