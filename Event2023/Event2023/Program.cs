﻿// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayThree;

var reader = new InputReader();
var solver = new DayThreePart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\3.txt")));


