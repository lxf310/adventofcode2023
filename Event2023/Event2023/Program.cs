﻿// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayFour;

var reader = new InputReader();
var solver = new DayFourPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\4.txt")));

