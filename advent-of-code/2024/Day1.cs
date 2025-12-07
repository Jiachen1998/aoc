using aoc.Shared;

namespace aoc._2024
{
    internal static class Day1
    {
        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 1, useTest);
            List<string> lines = Utilities.StringToLines(input);

            List<int> left = new();
            List<int> right = new();

            int result = 0;
            foreach (var line in lines)
            {
                // Setup left and right arrays
                var numbers = line.Split("  ");
                left.Add(int.Parse(numbers[0]));
                right.Add(int.Parse(numbers[1]));
            }
            
            // Sort each array
            left.Sort();
            right.Sort();

            // Iterate and find the difference (abs array 1 - array 2)
            for (int i = 0; i < left.Count; i++)
            {
                var thisDiff = Math.Abs(left[i] - right[i]);
                result += thisDiff;
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 1, useTest);
            List<string> lines = Utilities.StringToLines(input);

            List<int> left = new();
            List<int> right = new();

            int result = 0;
            foreach (var line in lines)
            {
                // Setup left and right arrays
                var numbers = line.Split("  ");
                left.Add(int.Parse(numbers[0]));
                right.Add(int.Parse(numbers[1]));
            }

            // Iterate through left, find number of count in right
            for (int i = 0; i < left.Count; i++)
            {
                var thisNum = left[i];

                // Find count in right
                var appearances = right.Count(x => x ==  thisNum);
                result += thisNum * appearances;
            }
            return result;
        }
    }
}
