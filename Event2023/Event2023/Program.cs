// See https://aka.ms/new-console-template for more information

using Event2023;
using Event2023.Puzzles.DayOne;

var reader = new InputReader();
var solver = new DayOne(new NumberReaderTwo());
Console.WriteLine(solver.Total(reader.ReadInputs("Inputs\\1.txt")));

//var numReader = new NumberReaderTwo();
//Console.WriteLine(numReader.Read("1tcrgthmeight5mssseight"));
