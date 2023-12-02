using AdventOfCode.DayOne;

Console.WriteLine("Ho, ho, ho!");

// Area for day 1 answers
var fileWrapper = new RealFileWrapper(Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DayOne\day_1_puzzle_input.txt"));
var calibrationDocProcessor = new CalibrationDocumentProcessor(fileWrapper);
Console.WriteLine(calibrationDocProcessor.GetValueFromDocument());