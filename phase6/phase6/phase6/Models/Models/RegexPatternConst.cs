namespace phase6.Models.Models;

public static class RegexPatternConst
{
    public const string PatternExtraSpace = @"\s+";
    public const string PatternPunctuation = @"\W";
    public const string ExtractSingle = "([+-| ]\"([^\"]*)\")";
    public const string SignRegex = @"([+-]?)\s*""([^""]*)""";
    public const string PhraseRegex = @"[-+ ]""([^""]*)""";


}