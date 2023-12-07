namespace aoc._2022
{
    internal class Day6
    {
        public static void Day6Part1()
        {
            var line = Utilities.ReadInput(6).FirstOrDefault();
            var queue = new Queue<char>(4);
            for (int i = 0; i < line.Length; i++)
            {
                queue.Enqueue(line[i]);
                if (queue.Count > 4)
                {
                    queue.Dequeue();
                }

                if (queue.Distinct().Count() == queue.Count &&
                    queue.Count >= 4)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }

        public static void Day6Part2()
        {
            var line = Utilities.ReadInput(6).FirstOrDefault();
            var queue = new Queue<char>(14);
            for (int i = 0; i < line.Length; i++)
            {
                queue.Enqueue(line[i]);
                if (queue.Count > 14)
                {
                    queue.Dequeue();
                }

                if (queue.Distinct().Count() == queue.Count &&
                    queue.Count >= 14)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }
    }
}
