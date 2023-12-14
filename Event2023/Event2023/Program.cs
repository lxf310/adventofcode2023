// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayFourteen;

var reader = new InputReader();
var solver = new DayFourteenPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\14.txt")));

