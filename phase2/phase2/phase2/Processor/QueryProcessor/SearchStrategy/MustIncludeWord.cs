using System.Runtime.InteropServices.JavaScript;

namespace phase2.Processor.QueryProcessor.SearchStrategy;

public class MustIncludeWord
{
    public static List<String> GetDirectoriesContainingWords(List<String> wordsShouldBe)
    {
        List<String> result = new List<string>();
        for (int i = 0; i < wordsShouldBe.Count; i++)
        {
            if (i == 0)
            {
                result = SearchOperation.SearchText(wordsShouldBe[i]);
            }
            else
            {
                result = result.Intersect(SearchOperation.SearchText(wordsShouldBe[i])).ToList();
            }
        }

        return result;
    }
}