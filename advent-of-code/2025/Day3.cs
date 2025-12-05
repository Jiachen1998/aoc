using aoc.Shared;

namespace aoc._2025
{
    internal static class Day3
    {
        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 3, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            long result = 0;
            foreach (var line in lines)
            {
                result += GetLargestTwoDigitNumber(line);
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 3, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            long result = 0;
            foreach (var line in lines)
            {
                result += GetLargestTwelveDigitNumber(line);
            }
            return result;
        }

        /// <summary>
        /// Provided a number string, return the largest digits in order of appearance.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static long GetLargestTwoDigitNumber(string line)
        {
            // Find the largest digit in the string, except the final digit.
            int firstLargest = -1;
            int firstLargestIndex = -1;
            
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    int digit = int.Parse(line[i].ToString());
                    if (digit > firstLargest)
                    {
                        firstLargest = digit;
                        firstLargestIndex = i;
                    }
                }
            }
            
            if (firstLargestIndex == -1)
            {
                throw new ArgumentException("String must contain at least two digits (excluding the last character)", nameof(line));
            }
            
            // Get the remaining substring after the largest digit.
            string remainingSubstring = line.Substring(firstLargestIndex + 1);
            
            // Find the largest digit in the remaining substring.
            int secondLargest = -1;
            foreach (char c in remainingSubstring)
            {
                if (char.IsDigit(c))
                {
                    int digit = int.Parse(c.ToString());
                    if (digit > secondLargest)
                    {
                        secondLargest = digit;
                    }
                }
            }
            
            if (secondLargest == -1)
            {
                throw new ArgumentException("String must contain at least two digits", nameof(line));
            }
            
            // Return the two largest digits in order of appearance.
            return int.Parse($"{firstLargest}{secondLargest}");
        }

        public static long GetLargestTwelveDigitNumber(string line)
        {
            List<int> digits = new List<int>();
            string remainingSubstring = line;
            int digitsNeeded = 12;
            
            // We need to ensure we have enough characters left for the remaining digits
            // For each digit we find, we need at least (digitsNeeded - digits.Count - 1) characters remaining
            for (int i = 0; i < digitsNeeded; i++)
            {
                int charsNeededAfter = digitsNeeded - i - 1;
                int searchEndIndex = remainingSubstring.Length - charsNeededAfter;
                
                if (searchEndIndex <= 0)
                {
                    throw new ArgumentException($"String must contain at least {digitsNeeded} digits", nameof(line));
                }
                
                // Find the largest digit in the remaining substring (excluding the last charsNeededAfter characters)
                int largestDigit = -1;
                int largestDigitIndex = -1;
                
                for (int j = 0; j < searchEndIndex; j++)
                {
                    if (char.IsDigit(remainingSubstring[j]))
                    {
                        int digit = int.Parse(remainingSubstring[j].ToString());
                        if (digit > largestDigit)
                        {
                            largestDigit = digit;
                            largestDigitIndex = j;
                        }
                    }
                }
                
                if (largestDigitIndex == -1)
                {
                    throw new ArgumentException($"String must contain at least {digitsNeeded} digits", nameof(line));
                }
                
                digits.Add(largestDigit);
                
                // Get the remaining substring after the largest digit
                remainingSubstring = remainingSubstring.Substring(largestDigitIndex + 1);
            }
            
            // Combine all digits into a 12-digit number
            string numberString = string.Join("", digits);
            return long.Parse(numberString);
        }
    }
}
