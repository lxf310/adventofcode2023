// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayEighteen;

var reader = new InputReader();
var solver = new DayEighteenPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\18.txt")));