using aoc.Shared;

namespace aoc._2025
{
    internal static class Day5
    {
        internal static long Part1(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 5, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            var divider = lines.IndexOf("");
            var ranges = lines.Take(divider).ToList();
            var ingredients = lines.Skip(divider + 1).ToList();

            foreach (var ingredient in ingredients)
            {
                if (IsValidIngredient(ingredient, ranges))
                {
                    result++;
                }
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 5, useTest);
            List<string> lines = Utilities.StringToLines(input);

            var divider = lines.IndexOf("");
            var rangeStrings = lines.Take(divider).ToList();
            
            // Parse all ranges into (start, end) tuples
            List<(long start, long end)> parsedRanges = new List<(long, long)>();
            foreach (var range in rangeStrings)
            {
                var parts = range.Split('-');
                if (parts.Length != 2)
                    continue;
                
                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);
                parsedRanges.Add((start, end));
            }
            
            // Sort ranges by start value
            parsedRanges.Sort((a, b) => a.start.CompareTo(b.start));
            
            // Merge overlapping/adjacent ranges
            List<(long start, long end)> mergedRanges = new List<(long, long)>();
            if (parsedRanges.Count > 0)
            {
                long currentStart = parsedRanges[0].start;
                long currentEnd = parsedRanges[0].end;
                
                for (int i = 1; i < parsedRanges.Count; i++)
                {
                    var (start, end) = parsedRanges[i];
                    
                    // If this range overlaps or is adjacent to the current range, merge it
                    if (start <= currentEnd + 1)
                    {
                        // Merge: extend currentEnd if needed
                        currentEnd = Math.Max(currentEnd, end);
                    }
                    else
                    {
                        // No overlap: save current merged range and start a new one
                        mergedRanges.Add((currentStart, currentEnd));
                        currentStart = start;
                        currentEnd = end;
                    }
                }
                
                // Don't forget the last merged range
                mergedRanges.Add((currentStart, currentEnd));
            }
            
            // Sum the sizes of all merged ranges
            long totalCount = 0;
            foreach (var (start, end) in mergedRanges)
            {
                totalCount += end - start + 1; // Inclusive: end - start + 1
            }
            
            return totalCount;
        }

        /// <summary>
        /// Method that checks if the ingredient number is contained within any of the ranges, inclusive.
        /// </summary>
        /// <param name="ingredient"></param>
        /// <param name="ranges"></param>
        /// <returns></returns>
        private static bool IsValidIngredient(string ingredient, List<string> ranges)
        {
            long ingredientValue = long.Parse(ingredient);
            
            foreach (var range in ranges)
            {
                var parts = range.Split('-');
                if (parts.Length != 2)
                    continue;
                
                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);
                
                // Check if ingredient is within the range (inclusive)
                if (ingredientValue >= start && ingredientValue <= end)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
