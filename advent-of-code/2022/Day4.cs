namespace aoc._2022
{
    internal class Day4
    {
        public static void Day4Part1()
        {
            var lines = Utilities.ReadInput(4);
            var sum = 0;
            foreach (var line in lines)
            {
                // Split line into two ranges
                var stringRange = line.Split(',');
                int[] range1 = stringRange[0].Split('-').Select(int.Parse).ToArray();
                int[] range2 = stringRange[1].Split('-').Select(int.Parse).ToArray();

                // Check if both min and max of one is bigger or equal to other
                if ((range1[0] <= range2[0] && range1[1] >= range2[1]) ||
                    (range1[0] >= range2[0] && range1[1] <= range2[1]))
                {
                    sum += 1;
                }
            }
            Console.WriteLine(sum);
        }

        public static void Day4Part2()
        {
            var lines = Utilities.ReadInput(4);
            var sum = 0;
            foreach (var line in lines)
            {
                // Split line into two ranges
                var stringRange = line.Split(',');
                int[] bounds1 = stringRange[0].Split('-').Select(int.Parse).ToArray();
                int[] bounds2 = stringRange[1].Split('-').Select(int.Parse).ToArray();

                var range1 = Enumerable.Range(bounds1[0], bounds1[1] - bounds1[0] + 1).ToList();
                var range2 = Enumerable.Range(bounds2[0], bounds2[1] - bounds2[0] + 1).ToList();

                if (range1.Intersect(range2).Any())
                {
                    sum += 1;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
