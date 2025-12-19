using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Days.Day01
{
    internal class Dial
    {
        public int CurrentPosition { get; private set; }
        public Dial(int startingPosition)
        {
            CurrentPosition = startingPosition;
        }

        public void Turn(int steps)
        {
            CurrentPosition += steps;

            while (CurrentPosition > 99)
            {
                CurrentPosition -= 100;
            }

            while (CurrentPosition < 0)
            {
                CurrentPosition += 100;
            }
        }
    }
}
