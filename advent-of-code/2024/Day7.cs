using aoc.Shared;

namespace aoc._2024
{
    internal static class Day7
    {

        /*
         * Day 7 is solved with a branching search since at each point of the sequence, we have additive, multiplicative
         * or concatenation branches. Recursion is ideal for this.
         */

        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 7, useTest);
            List<string> lines = Utilities.StringToLines(input);

            long result = 0;
            foreach (var line in lines)
            {
                var components = line.Split(':');
                var target = long.Parse(components[0]);
                var sequence = components[1].Trim().Split(' ').Select(n => long.Parse(n)).ToList();

                if (IsSolvablePart1(sequence, target))
                {
                    result += target;
                }
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 7, useTest);
            List<string> lines = Utilities.StringToLines(input);

            long result = 0;
            foreach (var line in lines)
            {
                var components = line.Split(':');
                var target = long.Parse(components[0]);
                var sequence = components[1].Trim().Split(' ').Select(n => long.Parse(n)).ToList();

                if (IsSolvablePart2(sequence, target))
                {
                    result += target;
                }
            }
            return result;
        }

        public static bool IsSolvablePart1(List<long> sequence, long target)
        {
            // At end of sequence if we hit target then true
            if (sequence.Count == 1)
            {
                return sequence[0] == target;
            }

            var first = sequence[0];
            var second = sequence[1];

            // Create new list
            var nextSequence = sequence.Skip(2).ToList();

            // Evaluate additive
            nextSequence.Insert(0, first + second);
            if (IsSolvablePart1(nextSequence, target))
                return true;

            // Evaluate multiplicative
            nextSequence[0] = first * second;
            if (IsSolvablePart1(nextSequence, target))
                return true;

            return false;
        }

        public static bool IsSolvablePart2(List<long> sequence, long target)
        {
            // At end of sequence if we hit target then true
            if (sequence.Count == 1)
            {
                return sequence[0] == target;
            }

            var first = sequence[0];
            var second = sequence[1];

            // Create new list
            var nextSequence = sequence.Skip(2).ToList();

            // Evaluate additive
            nextSequence.Insert(0, first + second);
            if (IsSolvablePart2(nextSequence, target))
                return true;

            // Evaluate multiplicative
            nextSequence[0] = first * second;
            if (IsSolvablePart2(nextSequence, target))
                return true;

            // Evaluate concatenation '||'
            nextSequence[0] = long.Parse($"{first}{second}");
            if (IsSolvablePart2(nextSequence, target))
                return true;

            return false;
        }
    }
}
