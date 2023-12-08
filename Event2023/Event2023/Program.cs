// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayEight;

var reader = new InputReader();
var solver = new DayEightPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\8.txt")));

