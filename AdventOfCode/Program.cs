using AdventOfCode.DayOne;

Console.WriteLine("Ho, ho, ho!");

// Area for day 1 answers
var calibrationDocProcessor = new CalibrationDocumentProcessor(Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DayOne\day_1_puzzle_input.txt"));
Console.WriteLine(calibrationDocProcessor.GetValueFromDocument());