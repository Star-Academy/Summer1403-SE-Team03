using System.Runtime.InteropServices.JavaScript;

namespace phase2.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategy
{
    public List<String> ManageSearchStrategy(String inputSearch)
    {
        List<String> atLeastOne = new List<string>();
        List<String> wordsShouldBe = new List<string>();
        List<String> wordsShouldNotBe = new List<string>();
        ManageInputSearchStrategy(SplitSearchInput(inputSearch), out atLeastOne, out wordsShouldBe , out wordsShouldNotBe);
        List<String> atLeastOneResult = ContainOneOfWordSearch.GetFilesContainingAnyWord(atLeastOne);
        List<String> wordsShouldBeResult = MustIncludeWord.GetDirectoriesContainingWords(wordsShouldBe);
        List<String> wordsShouldNotBeResult = MustNotContainWord.GetFilesNotContainingAnyWord(wordsShouldNotBe);
        return GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
    }
    private List<String> SplitSearchInput(String searchInput)
    {
        List<String> splitSearchInput = searchInput.ToUpper().Split(" ").ToList();
        return splitSearchInput;
    }
    private void ManageInputSearchStrategy(List<String> splitInput , out List<String> atLeastOne , out List<String> wordsShouldBe , out List<String> wordsShouldNotBe )
    {
        atLeastOne = new List<string>();
        wordsShouldBe = new List<string>();
        wordsShouldNotBe = new List<string>();
        foreach (String element in splitInput)
        {
            char firstChar = element.ElementAt(0);
            switch (firstChar)
            {
                case '+':
                    atLeastOne.Add(element.Substring(0));
                    break;
                case '-':
                    wordsShouldNotBe.Add(element.Substring(0));
                    break;
                default:
                    wordsShouldBe.Add(element);
                    break;
            }
        }
    }
    private List<String> GetResult(List<String> atLeastOneResult, List<String> wordsShouldBeResult , List<String> wordsShouldNotBeResult )
    {
        List<String> result = new List<String>();
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
            result = result.Except(wordsShouldNotBeResult).ToList();
        }
        return result;

    }
    
}