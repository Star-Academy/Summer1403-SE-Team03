namespace phase3.Exceotions;

public class InvalidInputException : Exception
{
    public string InputValue { get; }
    public string ExpectedFormat { get; }
    public InvalidInputException(string inputValue, string expectedFormat, Exception innerException)
        : base($"Invalid Input: '{inputValue}' does not match the expected format: '{expectedFormat}'.", innerException)
    {
        InputValue = inputValue;
        ExpectedFormat = expectedFormat;
    }
}