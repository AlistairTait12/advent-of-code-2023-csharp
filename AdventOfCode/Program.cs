using AdventOfCode.DayOne;
using AdventOfCode.DayTwo;

Console.WriteLine("Ho, ho, ho!");

var puzzleInputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\PuzzleInputs");

// Area for day 1 answers
var fileWrapper = new RealFileWrapper(Path.Combine(puzzleInputPath, @"day_1_puzzle_input.txt"));
var calibrationDocProcessor = new CalibrationDocumentProcessor(fileWrapper);
var dayOnePartTwoAnswer = calibrationDocProcessor.GetValueFromDocument();

Console.WriteLine($"The answer to day 1 part 1 is: 54953");
Console.WriteLine($"The answer to day 1 part 2 is: {dayOnePartTwoAnswer}");

// Area for day 2 answers
var day2FileWrapper = new RealFileWrapper(Path.Combine(puzzleInputPath, @"day_2_puzzle_input.txt"));
var gameListChecker = new GameListChecker(day2FileWrapper, new(12, 13, 14));
var answer = gameListChecker.GetSumOfPossibleGameIds();

Console.WriteLine($"The answer to day 2 part 1 is: {answer}");
