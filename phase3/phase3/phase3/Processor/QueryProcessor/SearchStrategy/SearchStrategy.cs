namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategy
{
    public IEnumerable<string> ManageSearchStrategy(string inputSearch)
    {
        List<string> atLeastOne = new();
        List<string> wordsShouldBe = new();
        List<string> wordsShouldNotBe = new();
        ManageInputSearchStrategy(SplitSearchInput(inputSearch), out atLeastOne, out wordsShouldBe,
            out wordsShouldNotBe);
        List<string> atLeastOneResult = new ContainOneOfWordSearch().Execute(atLeastOne);;
        List<string> wordsShouldBeResult = new MustIncludeWord().Execute(wordsShouldBe);
        List<string> wordsShouldNotBeResult = new MustNotContainWord().Execute(wordsShouldNotBe);
        return GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
    }

    private List<string> SplitSearchInput(string searchInput)
    {
        List<string> splitSearchInput = searchInput.ToUpper().Split(" ").ToList();
        return splitSearchInput;
    }

    private void ManageInputSearchStrategy(List<string> splitInput, out List<string> atLeastOne,
        out List<string> wordsShouldBe, out List<string> wordsShouldNotBe)
    {
        atLeastOne = new List<string>();
        wordsShouldBe = new List<string>();
        wordsShouldNotBe = new List<string>();
        foreach (var element in splitInput)
        {
            var firstChar = element.ElementAt(0);
            switch (firstChar)
            {
                case '+':
                    atLeastOne.Add(element.Substring(1));
                    break;
                case '-':
                    wordsShouldNotBe.Add(element.Substring(1));
                    break;
                default:
                    wordsShouldBe.Add(element);
                    break;
            }
        }
    }

    private IEnumerable<string> GetResult(List<string> atLeastOneResult, List<string> wordsShouldBeResult,
        List<string> wordsShouldNotBeResult)
    {
        List<string> result = new List<string>();
        if (atLeastOneResult.Count == 0)
        {
            result = wordsShouldBeResult;
        }
        else if (wordsShouldBeResult.Count == 0)
        {
            result = atLeastOneResult;
        }
        else
        {
            result = atLeastOneResult.Intersect(wordsShouldBeResult).ToList();
        }
        result = result.Except(wordsShouldNotBeResult).ToList();
        return result;
    }
}