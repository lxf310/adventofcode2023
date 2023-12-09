// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayNine;

var reader = new InputReader();
var solver = new DayNinePart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\9.txt")));

