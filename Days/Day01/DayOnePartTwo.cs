using AdventOfCode2025.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Days.Day01
{
    internal class DayOnePartTwo : IDaySolution
    {
        public string SolveProblem()
        {
            string[] input = ReadInput();
            int numberOfTimesCrossingZero = 0;
            Dial dial = new Dial(50);
            HashSet<string> validDirections = new HashSet<string> { "L", "R" };
            foreach (string line in input)
            {
                string direction = line.Substring(0, 1);

                if (!int.TryParse(line.Substring(1), out int steps) || !validDirections.Contains(direction))
                {
                    throw new ArgumentException($"{line} is not a valid argument.");
                }

                if (direction.Equals("L"))
                {
                    steps *= -1;
                }

                int dialPlusStepsRawValue = dial.CurrentPosition + steps;
                int timesCrossedInCurrentRotation = 0;
                timesCrossedInCurrentRotation += Math.Abs(dialPlusStepsRawValue) / 100;
                if (dialPlusStepsRawValue == 0 || dialPlusStepsRawValue < 0 && dial.CurrentPosition != 0)
                {
                    timesCrossedInCurrentRotation++;
                }
                dial.Turn(steps);

                numberOfTimesCrossingZero += timesCrossedInCurrentRotation;

            }

            return numberOfTimesCrossingZero.ToString();
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

