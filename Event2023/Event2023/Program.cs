// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DaySeven;

var reader = new InputReader();
var solver = new DaySevenPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\7.txt")));

