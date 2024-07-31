// using Moq;
// using phase3.Processor.QueryProcessor.SearchStrategy;
//
// namespace phase3Test.IO.OutPutManager;
//
// public class ConsoleOutPutTest
// {
//     private readonly ConsoleOutPutTest _consoleOutPutTest;
//     private readonly Mock<ISearchStrategy> _manageSearchStratey;
//
//     public ConsoleOutPutTest()
//     {
//         _manageSearchStratey = new Mock<ISearchStrategy>();
//         _consoleOutPutTest = new ConsoleOutPutTest(_manageSearchStratey.Object);
//     }
//
//     [Fact]
//     public void ProcessOnWord_ShouldReturnUniqueResult_WhenInputContainAnyWordOfList()
//     {
//         // arrange
//         var inputData = new List<string> { "mahdi", "mahshad" };
//         var expectedData = new Dictionary<string, List<string>>
//         {
//             { "mahdi", new List<string> { "5000", "5001", "5002" } },
//             { "mahshad", new List<string> { "5000", "5001" } },
//         };
//         var result = new List<string> { "5000", "5001", "5002" };
//
//         _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
//         _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);
//         // act
//         var resultProcessOnWords = _containOneOfWordSearch.ProcessOnWords(inputData);
//
//         // assert
//         Assert.Equal(result, resultProcessOnWords);
//     }
//
//     [Fact]
//     public void ProcessOnWord_ShouldReturnUniqueResult_WhenInputContainDuplicateList()
//     {
//         // arrange
//         var inputData = new List<string> { "mahdi", "mahshad" };
//         var expectedData = new Dictionary<string, List<string>>
//         {
//             { "mahdi", new List<string> { "5000", "5001" } },
//             { "mahshad", new List<string> { "5000", "5001" } },
//         };
//         var result = new List<string> { "5000", "5001" };
//
//         _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
//         _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);
//         // act
//         var resultProcessOnWords = _containOneOfWordSearch.ProcessOnWords(inputData);
//
//         // assert
//         Assert.Equal(result, resultProcessOnWords);
//     }
//
//     [Fact]
//     public void ProcessOnWord_ShouldReturnEmptyList_WhenInputContainNoWord()
//     {
//         // arrange
//         var inputData = new List<string> { };
//         var expectedData = new Dictionary<string, List<string>>
//         {
//             { "mahdi", new List<string> { "5000", "5001" } },
//             { "mahshad", new List<string> { "5000", "5001" } },
//         };
//         var result = new List<string> { };
//
//         _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
//         _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);
//         // act
//         var resultProcessOnWords = _containOneOfWordSearch.ProcessOnWords(inputData);
//
//         // assert
//         Assert.Equal(result, resultProcessOnWords);
//     }
// }