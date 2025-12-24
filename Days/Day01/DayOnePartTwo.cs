using AdventOfCode2025.Abstraction;

namespace AdventOfCode2025.Days
{
    internal class DayOnePartTwo : DaySolutionGeneric
    {
        protected override string SolveProblem()
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


        protected override string GetInputFilePath()
        {
            return "Days/Day01/Input.txt";
        }
    }
}

