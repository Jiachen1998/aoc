namespace aoc._2022
{
    internal class Day1
    {
        public static void Day1Part2()
        {
            var lines = Utilities.ReadInput(1);
            var sums = new List<int>() { 0 };
            int index = 0;

            foreach (var line in lines)
            {
                if (!int.TryParse(line, out int num))
                {
                    sums.Add(0);
                    index++;
                }
                else
                {
                    sums[index] += num;
                }
            }

            sums.Sort();
            int top3 = sums.TakeLast(3).Sum();

            Console.WriteLine(top3);
        }
    }
}
