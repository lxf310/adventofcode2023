﻿// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayTen;

var reader = new InputReader();
var solver = new DayTenPart2();
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\10.txt")));

