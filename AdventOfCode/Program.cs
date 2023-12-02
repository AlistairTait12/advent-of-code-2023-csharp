using AdventOfCode.DayOne;

Console.WriteLine("Ho, ho, ho!");

// Area for day 1 answers
var fileWrapper = new RealFileWrapper(Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DayOne\day_1_puzzle_input.txt"));
var calibrationDocProcessor = new CalibrationDocumentProcessor(fileWrapper);
var dayOnePartTwoAnswer = calibrationDocProcessor.GetValueFromDocument();

Console.WriteLine($"The answer to day 1 part 1 is: 54953");
Console.WriteLine($"The answer to day 1 part 2 is: {dayOnePartTwoAnswer}");

// Area for day 2 answers
