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
            HashSet<string> validDirections = new HashSet<string> { "L", "R" };
            Dial dial = new Dial(50);

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