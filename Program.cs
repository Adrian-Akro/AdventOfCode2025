using AdventOfCode2025.Days;
using AdventOfCode2025.Interfaces;
using System.Diagnostics;


List<IDaySolution> previousDaysSolutions = new List<IDaySolution>()
{
    new DayOnePartOne(),
    new DayOnePartTwo(),
    new DayTwoPartOne(),
    new DayTwoPartTwo()
};

for(int i = 1; i <= previousDaysSolutions.Count; i++)
{
    IDaySolution previousDaySolution = previousDaysSolutions[i-1];
    int part = 2;
    int day = i / 2;

    if (i % 2 != 0)
    {
        part = 1;
        day = (i + 1) / 2;
    }

    Console.WriteLine($"Day {day} part {part} solution: {previousDaySolution.GenerateOutput()}");
}

Console.WriteLine("");
IDaySolution currentDaySolution = new DayTwoPartTwo();
Console.WriteLine("Generating output for the current day...");
Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

string output = currentDaySolution.GenerateOutput();

watch.Stop();
long executionTime = watch.ElapsedMilliseconds;

Console.WriteLine(output);
Console.WriteLine($"Output generated in {executionTime/1000d} seconds.");
Console.WriteLine("");
Console.ReadKey();