// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayTwelve;

var reader = new InputReader();
var solver = new DayTwelvePart1();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\12.txt")));

