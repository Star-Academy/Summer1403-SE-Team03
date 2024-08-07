using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

namespace phase6.Controllers;
[ApiController]
[Route("Search")]
public class SearchController : ControllerBase
{
    private readonly ISearchStrategy _searchStrategy;

    public SearchController(ISearchStrategy searchStrategy)
    {
        _searchStrategy = searchStrategy;
    }
    [HttpGet("{input}")]
    public IActionResult GetQuery(String input)
    {
        var result =_searchStrategy.ManageSearchStrategy(input);
        return Ok(result);
    }
}