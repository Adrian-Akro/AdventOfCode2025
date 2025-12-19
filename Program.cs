// See https://aka.ms/new-console-template for more information

using AdventOfCode2025.Days;
using AdventOfCode2025.Days.Day01;
using AdventOfCode2025.Interfaces;

IDaySolution solution = new DayOnePartTwo();
string output = solution.GenerateOutput();
Console.WriteLine("Generating output...");
Console.WriteLine(output);
Console.WriteLine("Output generated.");
Console.ReadKey();