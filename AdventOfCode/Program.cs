using AdventOfCode.DayOne;
using AdventOfCode.DayThree;
using AdventOfCode.DayTwo;

Console.WriteLine("Ho, ho, ho!");

var puzzleInputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\PuzzleInputs");

// Area for day 1 answers
var fileWrapper = new RealFileWrapper(Path.Combine(puzzleInputPath, @"day_1.txt"));
var calibrationDocProcessor = new CalibrationDocumentProcessor(fileWrapper);
var dayOnePartTwoAnswer = calibrationDocProcessor.GetValueFromDocument();

Console.WriteLine($"The answer to day 1 part 1 is: 54953");
Console.WriteLine($"The answer to day 1 part 2 is: {dayOnePartTwoAnswer}");

// Area for day 2 answers
var day2FileWrapper = new RealFileWrapper(Path.Combine(puzzleInputPath, @"day_2.txt"));
var gameListChecker = new GameListChecker(day2FileWrapper, new(12, 13, 14));
var dayTwoPartOne = gameListChecker.GetSumOfPossibleGameIds();
var dayTwoPartTwo = gameListChecker.GetPowersOfMinimumValueOfEachGame();

Console.WriteLine($"The answer to day 2 part 1 is: {dayTwoPartOne}");
Console.WriteLine($"The answer to day 2 part 2 is: {dayTwoPartTwo}");

// Area for day 3 answers
var day3FileWrapper = new RealFileWrapper(Path.Combine(puzzleInputPath, @"day_3.txt"));
var schematicChecker = new SchematicChecker(day3FileWrapper);
var dayThreePartOne = schematicChecker.Check();

Console.WriteLine($"The answer to day 3 part 1 is {dayThreePartOne}");
