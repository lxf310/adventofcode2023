// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayTwo;

var reader = new InputReader();
var solver = new DayTwoPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\2.txt")));


