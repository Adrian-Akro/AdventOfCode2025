using AdventOfCode2025.Abstraction;

namespace AdventOfCode2025.Days
{
    internal class DayTwoPartTwo : DaySolutionGeneric
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
                // Get values from input file text.
                string[] idsToValidate = problemInput.Split(',');

                // Loop over array of values.
                foreach (string idRange in idsToValidate)
                {
                    // Ignore empty values.
                    if (idRange.Equals(string.Empty))
                    {
                        continue;
                    }

                    // Each value is a range of numbers defined by an starting number and an ending number.
                    // Values are separated by a -.
                    string[] rangeStartAndEnd = idRange.Split("-");
                    if (rangeStartAndEnd.Length != 2)
                    {
                        throw new ArgumentException("Input file is not valid");
                    }

                    // Convert starting and ending values in range to long to loop over them.
                    // Validate that the values can be converted to long.
                    if (!long.TryParse(rangeStartAndEnd[0], out long rangeStart) || !long.TryParse(rangeStartAndEnd[1], out long rangeEnd))
                    {
                        throw new ArgumentException("Input file is not valid");
                    }

                    // Loop over every value in the range
                    for (long currentRangeValue = rangeStart; currentRangeValue <= rangeEnd; currentRangeValue++)
                    {
                        bool isCurrentIdValid = true;
                        string currentId = currentRangeValue.ToString();

                        // We need to check wether a sequence of numbers within the value is repeated from start to finish
                        // The value is divided into chunks of equal size.
                        for (int sequenceChunkSize = currentId.Length / 2;
                            sequenceChunkSize >= 1 && isCurrentIdValid;
                            sequenceChunkSize--)
                        {
                            // The value needs to be divisible by the chunk size.
                            if (currentId.Length % sequenceChunkSize != 0)
                            {
                                continue;
                            }

                            bool isIdValidWithCurrentChunkSize = false;
                            // Check wether a sequence of the defined size is repeated continuously within the value.
                            for (int sequencePosition = 0;
                                sequencePosition + sequenceChunkSize < currentId.Length;
                                sequencePosition += sequenceChunkSize)
                            {
                                string currentSequenceValue = currentId
                                    .Substring(sequencePosition, sequenceChunkSize);
                                string nextSequenceValue = currentId
                                    .Substring(sequencePosition + sequenceChunkSize, sequenceChunkSize);

                                // If the sequence is not repeated continuously, stop looping over the current value
                                // and check the next value.
                                if (!currentSequenceValue.Equals(nextSequenceValue))
                                {
                                    isIdValidWithCurrentChunkSize = true;
                                    break;
                                }
                            }

                            if (!isIdValidWithCurrentChunkSize)
                            {
                                isCurrentIdValid = false;
                            }
                        }

                        // If an invalid value is found, add it to the sum of invalid values.
                        if (!isCurrentIdValid) 
                        {
                            sumOfInvalidValues += currentRangeValue;
                        }
                    }
                    
                }
            }
            return sumOfInvalidValues.ToString();
        }
    }
}
