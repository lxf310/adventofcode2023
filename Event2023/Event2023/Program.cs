// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DaySeventeen;

var reader = new InputReader();
var solver = new DaySeventeenPart1();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\17.txt"), true));

