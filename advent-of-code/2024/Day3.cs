using aoc.Shared;

namespace aoc._2024
{
    internal static class Day3
    {
        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 3, useTest);
            List<string> lines = Utilities.StringToLines(input);

            int result = 0;
            foreach (var line in lines)
            {
                // TODO
                // Find substrings of 'mul'
                var mulIndex = line.AllIndexesOf("mul").ToList();

                foreach (var index in mulIndex)
                {
                    // Basically assert next char is '('
                    var startBracket = index + 3;
                    if (line[startBracket] != '(')
                        continue;

                    // Get next ')' index
                    var endBracket = line.IndexOf(')', index + 3);
                    var internals = line.Substring(startBracket + 1, length: (endBracket - startBracket - 1));

                    // Split by comma, valid segment only has 2 numbers
                    var nums = internals.Split(',');
                    if (nums.Length > 2)
                    {
                        continue;
                    }

                    // Check if we only have number components and then multiply
                    if (int.TryParse(nums[0], out int left) && int.TryParse(nums[1], out int right))
                    {
                        result += left * right;
                    }
                } 
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 3, useTest);
            List<string> lines = Utilities.StringToLines(input);

            int result = 0;
            string combinedLines = "";
            foreach (var line in lines)
            {
                combinedLines += line;
            }

            // Find substrings of 'mul'
            var doIndex = combinedLines.AllIndexesOf(@"do()").ToList();
            var dontIndex = combinedLines.AllIndexesOf(@"don't()").ToList();

            var instructionDict = new Dictionary<int, bool>();
            instructionDict[0] = true; // Default is 'do'
            foreach (var doInd in doIndex)
            {
                instructionDict[doInd] = true;
            }
            foreach (var dontInd in dontIndex)
            {
                instructionDict[dontInd] = false;
            }
            var indexes = instructionDict.Keys.ToList();
            indexes.Sort();

            var mulIndex = combinedLines.AllIndexesOf("mul").ToList();

            foreach (var index in mulIndex)
            {
                // We want to find the largest key in doDontDict that is smaller than index, and continue if it is false
                var lastDictIndex = indexes.Last(i => i <= index);
                if (!instructionDict[lastDictIndex])
                    continue;

                // Basically assert next char is '('
                var startBracket = index + 3;
                if (combinedLines[startBracket] != '(')
                    continue;

                // Get next ')' index
                var endBracket = combinedLines.IndexOf(')', index + 3);
                var internals = combinedLines.Substring(startBracket + 1, length: (endBracket - startBracket - 1));

                // Split by comma, valid segment only has 2 numbers
                var nums = internals.Split(',');
                if (nums.Length > 2)
                {
                    continue;
                }

                // Check if we only have number components and then multiply
                if (int.TryParse(nums[0], out int left) && int.TryParse(nums[1], out int right))
                {
                    result += left * right;
                }
            }
            return result;
        }

        public static IEnumerable<int> AllIndexesOf(this string str, string value)
        {
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    break;
                yield return index;
            }
        }

    }
}
