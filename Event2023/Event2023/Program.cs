// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DaySix;

var reader = new InputReader();
var solver = new DaySixPart2();
Console.WriteLine(solver.Possibility(reader.ReadInputs("Inputs\\6.txt")));

