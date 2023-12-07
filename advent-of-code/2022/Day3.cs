namespace aoc._2022
{
    internal class Day3
    {
        public static void Day3Part1()
        {
            var lines = Utilities.ReadInput(3);
            var sum = 0;
            var alphabetDict = CreateAlphabetDict();

            foreach (var line in lines)
            {
                // Find letter (case sensitive) in both halves of string
                // Split string in halves
                var halfLength = line.Length / 2;
                var firstHalf = line.Substring(0, halfLength);
                var secondHalf = line.Substring(halfLength);

                // Use LINQ to match common characters
                var shared = firstHalf.Intersect(secondHalf).FirstOrDefault();
                sum += alphabetDict[shared];
            }
            Console.WriteLine(sum);
        }

        public static void Day3Part2()
        {
            var lines = Utilities.ReadInput(3);
            var sum = 0;
            var alphabetDict = CreateAlphabetDict();
            while (lines.Count > 0)
            {
                var group = lines.Take(3).ToArray();
                var shared = group[0]
                    .Intersect(group[1])
                    .Intersect(group[2])
                    .FirstOrDefault();

                sum += alphabetDict[shared];
                lines.RemoveRange(0, 3);
            }
            Console.WriteLine(sum);
        }

        private static Dictionary<char, int> CreateAlphabetDict()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                dict.Add(c, c - 96);
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                dict.Add(c, c - 38); // 'A' starts with value of 27
            }
            return dict;
        }
    }
}
