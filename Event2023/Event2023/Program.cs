// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayEleven;

var reader = new InputReader();
var solver = new DayElevenPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\11.txt"), 1000000));

