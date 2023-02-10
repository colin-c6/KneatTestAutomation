using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task test_QueryInputAndSearchButtonAreOnTheMainScreen()
    {
        var searchInput = Page.Locator("[id='search-input']");
        var searchButton = Page.Locator("[id='search-button']");

        // Expect a title "to contain" a substring.
        await Expect(searchInput).ToBeVisibleAsync();
        await Expect(searchButton).ToBeVisibleAsync();
    }

    [Test]
    public async Task test_SearchingWithEmptyQueryIsForbidden()
    {
        var searchButton = Page.Locator("[id='search-button']");

        await searchButton.ClickAsync();
        var errorMessage = Page.Locator("[id='error-empty-query']");        
        await Expect(errorMessage).ToBeVisibleAsync();
    }

    [Test]
    public async Task test_ResultsAreReturnedWithValidSearch()
    {
        var searchInput = Page.Locator("[id='search-input']");
        var searchButton = Page.Locator("[id='search-button']");

        await searchInput.FillAsync("isla");
        await searchButton.ClickAsync();
        var firstSearchResult = Page.Locator("ul[id='search-results'] li >> nth=1");
        await Expect(firstSearchResult).ToBeVisibleAsync();
    }

    [Test]
    public async Task test_UserGetsFeedbackMessageForNoResults()
    {
        var searchInput = Page.Locator("[id='search-input']");
        var searchButton = Page.Locator("[id='search-button']");

        await searchInput.FillAsync("castle");
        await searchButton.ClickAsync();
        var noResultsMessage = Page.Locator("[id='error-no-results']");
        await Expect(noResultsMessage).ToBeVisibleAsync();
    }

    [Test]
    public async Task test_SearchResultsMatchQuery()
    {
        var searchInput = Page.Locator("[id='search-input']");
        var searchButton = Page.Locator("[id='search-button']");

        await searchInput.FillAsync("port");
        await searchButton.ClickAsync();
        var allSearchResult = Page.Locator("ul[id='search-results'] li");
        await Expect(allSearchResult).ToHaveCountAsync(1);
    }

    [SetUp]
    public async Task SetUp() 
    {
        await Page.GotoAsync("https://codility-frontend-prod.s3.amazonaws.com/media/task_static/qa_csharp_search/862b0faa506b8487c25a3384cfde8af4/static/attachments/reference_page.html");
    }
}