// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayNineteen;

var reader = new InputReader();
var solver = new DayNineteenPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\19.txt", false)));