// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DaySixteen;

var reader = new InputReader();
var solver = new DaySixteenPart1();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\16.txt"), true));

