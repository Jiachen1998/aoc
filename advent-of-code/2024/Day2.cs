using aoc.Shared;
using System.Net.WebSockets;

namespace aoc._2024
{
    internal static class Day2
    {
        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 2, useTest);
            List<string> lines = Utilities.StringToLines(input);

            int result = 0;
            foreach (var line in lines)
            {
                var digits = line.Split(' ');
                var nums = digits.Select(x => int.Parse(x)).ToList();
                if (CheckIfInOrder(nums) && CheckDifferenceCondition(nums))
                    result++;
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 2, useTest);
            List<string> lines = Utilities.StringToLines(input);

            int result = 0;
            foreach (var line in lines)
            {
                var digits = line.Split(' ');
                var nums = digits.Select(x => int.Parse(x)).ToList();

                for (int i = 0; i < nums.Count; i++)
                {
                    var copied = nums.Select(x => x).ToList();
                    copied.RemoveAt(i);
                    if (CheckIfInOrder(copied) && CheckDifferenceCondition(copied))
                    {
                        result++;
                        break;
                    }
                }
            }
            return result;
        }

        internal static bool CheckIfInOrder(List<int> report)
        {
            // Sort list ascending and descending, if one of them is equal to input then true
            var sorted = report.OrderBy(x => x).ToList();
            if (sorted.SequenceEqual(report))
                return true;

            sorted.Reverse();
            if (sorted.SequenceEqual(report))
                return true;

            return false;
        }

        internal static bool CheckDifferenceCondition(List<int> report)
        {
            // Loop through report, if next number difference is less than 1 or greater than 3 then false
            for (int i = 0; i < report.Count - 1; i++)
            {
                var next = report[i + 1];
                var curr = report[i];
                if (Math.Abs(next - curr) < 1 || Math.Abs(next - curr) > 3)
                    return false;                
            }
            return true;
        }

        internal static bool CheckIfInOrderPart2(List<int> report)
        {
            
            // Sort list ascending and descending, if one of them is equal to input then true
            var sorted = report.OrderBy(x => x).ToList();
            if (sorted.SequenceEqual(report))
                return true;

            sorted.Reverse();
            if (sorted.SequenceEqual(report))
                return true;

            return false;
        }

        internal static bool CheckDifferenceConditionPart2(List<int> report)
        {
            int errorCounter = 0;
            // Loop through report, if next number difference is less than 1 or greater than 3 then false
            for (int i = 0; i < report.Count - 1; i++)
            {
                var next = report[i + 1];
                var curr = report[i];
                if (Math.Abs(next - curr) < 1 || Math.Abs(next - curr) > 3)
                    errorCounter++;

                if (errorCounter > 1)
                    return false;
            }
            return true;
        }
    }
}
