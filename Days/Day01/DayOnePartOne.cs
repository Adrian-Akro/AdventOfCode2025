using System;
using AdventOfCode2025.Days.Day01;
using AdventOfCode2025.Interfaces;

namespace AdventOfCode2025.Days
{
    internal class DayOnePartOne : IDaySolution
    {
        public string SolveProblem() 
        {
            string[] input = ReadInput();
            int numberOfTimesAtZero = 0;
            Dial dial = new Dial(50);

            foreach (string line in input)
            {
                string direction = line.Substring(0, 1);
                int steps = int.Parse(line.Substring(1));

                if (direction.Equals("L"))
                {
                    steps *= -1;
                }

                dial.Turn(steps);

                if (dial.CurrentPosition == 0)
                {
                    numberOfTimesAtZero++;
                }

            }

            return numberOfTimesAtZero.ToString();
        }
        private string[] ReadInput()
        {
            return File.ReadAllLines("Days/Day01/DayOneInput.txt");
        }

        public string GenerateOutput()
        {
            return SolveProblem();
        }
    }
}