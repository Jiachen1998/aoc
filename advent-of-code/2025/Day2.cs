using aoc.Shared;

namespace aoc._2025
{
    internal static class Day2
    {
        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 2, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            long result = 0;
            foreach (var line in lines)
            {
                var ranges = line.Split(',').Where(s => !string.IsNullOrEmpty(s));
                var numberPairs = ranges
                .Select(r => r.Split('-'))
                .Select(n => (long.Parse(n[0]), long.Parse(n[1])));

                foreach (var numberPair in numberPairs)
                {
                    for (long i = numberPair.Item1; i <= numberPair.Item2; i++)
                    {
                        if (IsRepeatingNumberTwice(i))
                        {
                            result += i;
                        }
                            
                    }
                }
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 2, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            long result = 0;
            foreach (var line in lines)
            {
                var ranges = line.Split(',').Where(s => !string.IsNullOrEmpty(s));
                var numberPairs = ranges
                .Select(r => r.Split('-'))
                .Select(n => (long.Parse(n[0]), long.Parse(n[1])));

                foreach (var numberPair in numberPairs)
                {
                    for (long i = numberPair.Item1; i <= numberPair.Item2; i++)
                    {
                        if (IsRepeatingNumberAtLeastTwice(i))
                        {
                            result += i;
                        }
                            
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// This method checks wither the provided number contains a sequence of digits that repeats once.
        /// E.g. 1212, 123123, 12341234 are all considered repeating numbers. 999 is not considered a repeating number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsRepeatingNumberTwice(long number)
        {
            string numberStr = number.ToString();
            int length = numberStr.Length;
            for (int i = 0; i < length / 2; i++)
            {
                int patternLength = i + 1;
                // The length must be divisible by the pattern length
                if (length % patternLength != 0)
                    continue;
                    
                string pattern = numberStr.Substring(0, patternLength);
                int repetitions = length / patternLength;
                
                // Must repeat exactly twice (the pattern appears twice total)
                if (repetitions != 2)
                    continue;
                    
                string expected = string.Concat(Enumerable.Repeat(pattern, repetitions));
                if (numberStr == expected)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks whether the provided number is purely a sequence of repeating digits.
        /// E.g. 11, 22, 1010, 1188511885 are all considered repeating numbers.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsRepeatingNumberAtLeastTwice(long number)
        {
            string numberStr = number.ToString();
            int length = numberStr.Length;
            
            for (int patternLength = 1; patternLength <= length / 2; patternLength++)
            {
                if (length % patternLength != 0)
                    continue;
                
                string pattern = numberStr.Substring(0, patternLength);
                int repetitions = length / patternLength;
                
                string expected = string.Concat(Enumerable.Repeat(pattern, repetitions));
                if (numberStr == expected)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
