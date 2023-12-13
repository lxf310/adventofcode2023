// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayThirteen;

var reader = new InputReader();
var solver = new DayThirteen();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\13.txt", false), true));

