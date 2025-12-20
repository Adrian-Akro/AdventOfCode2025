using AdventOfCode2025.Abstraction;
using AdventOfCode2025.Interfaces;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class DayTwoPartOne : DaySolutionGeneric
    {

        protected override string GetInputFilePath()
        {
            return "Days/Day02/Input.txt";
        }

        protected override string SolveProblem()
        {
            long sumOfInvalidValues = 0;
            string[] inputLines = ReadInput();
            if (inputLines.Length <= 0)
            {
                throw new ArgumentException("Input file is not valid.");
            }

            foreach (string problemInput in inputLines) {
                string[] idsToValidate = problemInput.Split(',');
                foreach (string idRange in idsToValidate)
                {
                    if (idRange.Equals(string.Empty))
                    {
                        continue;
                    }

                    string[] rangeStartAndEnd = idRange.Split("-");
                    if (rangeStartAndEnd.Length != 2)
                    {
                        throw new ArgumentException("Input file is not valid");
                    }

                    if (!long.TryParse(rangeStartAndEnd[0], out long rangeStart) || !long.TryParse(rangeStartAndEnd[1], out long rangeEnd))
                    {
                        throw new ArgumentException("Input file is not valid");
                    }


                    for (long i = rangeStart; i <= rangeEnd; i++)
                    {
                        string currentId = i.ToString();

                        if (currentId.Length % 2 != 0)
                        {
                            continue;
                        }

                        if (currentId.Substring(0, currentId.Length/2).Equals(currentId.Substring(currentId.Length/2)))
                        {
                            sumOfInvalidValues += i;
                        }
                    }
                }
            }
            return sumOfInvalidValues.ToString();
        }
    }
}
