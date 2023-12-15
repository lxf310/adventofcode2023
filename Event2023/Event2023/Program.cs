// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayFifteen;

var reader = new InputReader();
var solver = new DayFifteenPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\15.txt")));

