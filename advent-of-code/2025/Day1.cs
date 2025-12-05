using aoc.Shared;

namespace aoc._2025
{
    internal static class Day1
    {
        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 1, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            int position = 50;
            int zeroCount = 0;

            foreach (var line in lines)
            {
                // Apply movement
                if (line.StartsWith('L'))
                {
                    position -= int.Parse(line[1..]);
                }
                else if (line.StartsWith('R'))
                {
                    position += int.Parse(line[1..]);
                }

                // Handle overflow
                while (position < 0)
                {
                    position += 100;
                }
                while (position > 99)
                {
                    position -= 100;
                }


                if (position == 0)
                {
                    zeroCount++;
                }
            }

            return zeroCount;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 1, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            int position = 50;
            int clickCounter = 0;

            foreach (var line in lines)
            {
                int startPosition = position;
                int movement = line.StartsWith('L') ? -int.Parse(line[1..]) : int.Parse(line[1..]);
                
                // Apply movement
                int endPosition = position + movement;

                // Normalize positions to 0-99 range
                int startNorm = ((startPosition % 100) + 100) % 100;
                int endNorm = ((endPosition % 100) + 100) % 100;

                // Count how many times we cross 0 during movement
                // Check each step to see if we pass through position 0
                int steps = Math.Abs(movement);
                int stepDirection = movement > 0 ? 1 : -1;
                
                for (int i = 1; i <= steps; i++)
                {
                    int checkPos = startPosition + (i * stepDirection);
                    int checkNorm = ((checkPos % 100) + 100) % 100;
                    if (checkNorm == 0)
                    {
                        // Don't count if we started at actual position 0 and this is the first step (leaving 0)
                        if (!(startPosition == 0 && i == 1))
                        {
                            clickCounter++;
                        }
                    }
                }

                // Update position (normalized)
                position = endNorm;
            }

            return clickCounter;
        }
    }
}
