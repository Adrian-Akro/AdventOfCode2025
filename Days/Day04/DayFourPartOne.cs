using AdventOfCode2025.Abstraction;

namespace AdventOfCode2025.Days.Day04
{
    internal class DayFourPartOne : DaySolutionGeneric
    {
        protected override string GetInputFilePath()
        {
            return "Days/Day04/Input.txt";
        }

        protected override string SolveProblem()
        {
            const char giftItem = '@';
            string[] inputData = ReadInput();

            if (inputData.Length <= 0)
            {
                throw new ArgumentException("Input data is not valid.");
            }

            int[,] adjacentItemCounterTracker = new int[inputData.Length, inputData[0].Length];


            // Iterate every item
            for (int rowIndex = 0; rowIndex < inputData.Length; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < inputData[rowIndex].Length; columnIndex++)
                {
                    char inputItem = inputData[rowIndex][columnIndex];

                    // If an giftItem is found, increase every giftItem's counter of adjacent giftItems
                    if (inputItem.Equals(giftItem))
                    {
                        increaseAdjacentItemCounter(rowIndex, columnIndex, giftItem);
                    }
                }
            }

            void increaseAdjacentItemCounter(int rowIndex, int columnIndex, char itemData)
            {
                for (int rowIndexIterator = rowIndex - 1; rowIndexIterator <= rowIndex + 1; rowIndexIterator++)
                {
                    // If the item we are checking is out of bounds, check the next item
                    if (rowIndexIterator < 0 || rowIndexIterator >= adjacentItemCounterTracker.GetLength(0))
                    {
                        continue;
                    }

                    for (int columnIndexIterator = columnIndex - 1; columnIndexIterator <= columnIndex + 1; columnIndexIterator++)
                    {
                        // If the item we are checking is out of bounds,
                        // is not a itemData
                        // or has the same coordinates as the item supplied,
                        // check the next item
                        if (
                            columnIndexIterator < 0
                            || columnIndexIterator >= adjacentItemCounterTracker.GetLength(1)
                            || !inputData[rowIndexIterator][columnIndexIterator].Equals(itemData)
                            || (rowIndexIterator == rowIndex && columnIndexIterator == columnIndex)
                            )
                        {
                            continue;
                        }
                        adjacentItemCounterTracker[rowIndexIterator, columnIndexIterator]++; 
                    }
                }
            }

            // Iterate the array tracking the number of adjacent items of each item
            // and return the number of items with fewer than N adjacent items
            int getItemsWithFewerThanNumberAdjacentItems(int numberOfAdjacentItems, char itemData)
            {
                int numberOfItems = 0;
                for (int rowIndex = 0; rowIndex < adjacentItemCounterTracker.GetLength(0); rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < adjacentItemCounterTracker.GetLength(1); columnIndex++)
                    {
                        // If the are more number of adjacent items than what we are searching for 
                        // or the current item is not an itemData
                        // check the next item
                        if (
                            !inputData[rowIndex][columnIndex].Equals(itemData)
                            || adjacentItemCounterTracker[rowIndex,columnIndex] >= numberOfAdjacentItems
                            )
                        {
                            continue;
                        }
                        numberOfItems++;
                    }
                }
                return numberOfItems;
            }

            return getItemsWithFewerThanNumberAdjacentItems(4, giftItem).ToString();
        }
    }
}
