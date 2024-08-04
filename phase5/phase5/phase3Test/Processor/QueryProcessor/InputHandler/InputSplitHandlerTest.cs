using phase3.Processor.QueryProcessor.InputHandler;

namespace phase3Test.Processor.QueryProcessor.InputHandler;

public class InputSplitHandlerTest
{
    private readonly InputSplitHandler _sut;
    public InputSplitHandlerTest()
    {
        _sut = new InputSplitHandler();
        
    }
    [Fact]
    public void TokenizeInput_ShouldReturnSpiltInputWithPhrase_WhenInputHavePhraseAndWord()
    {
        string test = @"get +illness +""star academy"" -""apple""  ""orange banana"" sad";
        List<string> expected = new List<string>() { "get", "+illness", "sad", "+star academy", "-apple","orange banana" };
        var result = _sut.TokenizeInput(test);
        Assert.Equal(expected,result);

    }
}