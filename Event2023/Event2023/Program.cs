// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayTwenty;

var solver = new DayTwentyPart2();
Console.WriteLine(solver.Total(Helper.ReadInputs("Inputs\\20.txt")));