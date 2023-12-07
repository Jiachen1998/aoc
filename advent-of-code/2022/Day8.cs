namespace aoc._2022
{
    internal class Day8
    {
        public void Day8Part1()
        {
            var lines = Utilities.ReadInput(8);
            var map = new List<List<int>>(); // Apparently O(1) for element access

            var visibleCount = 0;

            // Build the map
            foreach (var line in lines)
            {
                var row = line
                    .ToList()
                    .Select(x => int.Parse(x.ToString()))
                    .ToList();
                map.Add(row);
            }

            for (int i = 0; i < map.Count; i++)
            {
                var row = map[i];
                for (int j = 0; j < row.Count; j++)
                {
                    var element = map[i][j];

                    // Borders guaranteed visible
                    if (i == 0 ||
                        j == 0 ||
                        i == (row.Count - 1) ||
                        j == (map.Count - 1))
                    {
                        Console.WriteLine($"Element [{i}, {j}] is visible as it is on the border");
                        visibleCount += 1;
                        continue;
                    }

                    // Check Row Visibility
                    var left = row.GetRange(0, j);
                    var right = row.GetRange((j + 1), (row.Count - (j + 1)));
                    if (element > left.Max() || element > right.Max())
                    {
                        Console.WriteLine($"Element [{i}, {j}] is visible as it is taller than either left {string.Join(", ", left)} or right {string.Join(", ", right)}");
                        visibleCount += 1;
                        continue;
                    }

                    // Build Column
                    var col = new List<int>();
                    foreach (var rowAgain in map) // Disgusting but the only way to do it in C#
                    {
                        col.Add(rowAgain[j]);
                    }

                    // Check Col Visibility
                    var top = col.GetRange(0, i);
                    var bot = col.GetRange((i + 1), (col.Count - (i + 1)));
                    if (element > top.Max() || element > bot.Max())
                    {
                        Console.WriteLine($"Element [{i}, {j}] is visible as it is taller than either top {string.Join(", ", top)} or bot {string.Join(", ", bot)}");
                        visibleCount += 1;
                    }
                }
            }

            Console.WriteLine($"Day 8 Part 1: {visibleCount}");
        }

        public void Day8Part2()
        {
            var lines = Utilities.ReadInput(8);
            var map = new List<List<int>>(); // Apparently O(1) for element access

            var bestScore = 0;

            // Build the map
            foreach (var line in lines)
            {
                var row = line
                    .ToList()
                    .Select(x => int.Parse(x.ToString()))
                    .ToList();
                map.Add(row);
            }

            for (int i = 0; i < map.Count; i++)
            {
                var row = map[i];
                for (int j = 0; j < row.Count; j++)
                {
                    var element = map[i][j];

                    // Ignore borders
                    if (i == 0 ||
                        j == 0 ||
                        i == (row.Count - 1) ||
                        j == (map.Count - 1))
                    {
                        continue;
                    }

                    Console.WriteLine($"Checking element [{i}, {j}]");

                    // Build Column
                    var col = new List<int>();
                    foreach (var rowAgain in map) // Disgusting but the only way to do it in C#
                    {
                        col.Add(rowAgain[j]);
                    }

                    // Get directions
                    var left = row.GetRange(0, j);
                    var right = row.GetRange((j + 1), (row.Count - (j + 1)));
                    var top = col.GetRange(0, i);
                    var bot = col.GetRange((i + 1), (col.Count - (i + 1)));

                    // Invert left and top directions so closest trees are first
                    left.Reverse();
                    top.Reverse();

                    // Calculate score
                    var leftScore = GetScore(element, left);
                    var rightScore = GetScore(element, right);
                    var topScore = GetScore(element, top);
                    var botScore = GetScore(element, bot);

                    var tempScore = leftScore * rightScore * topScore * botScore;
                    Console.WriteLine($"Tree [{i}, {j}] has score {leftScore} * {rightScore} * {topScore} * {botScore} = {tempScore}");
                    if (tempScore > bestScore)
                    {
                        Console.WriteLine($"Tree [{i}, {j}] is the new best with scores {leftScore} * {rightScore} * {topScore} * {botScore} = {tempScore}");
                        bestScore = tempScore;
                    }
                }
            }

            Console.WriteLine($"Day 8 Part 2: {bestScore}");

            static int GetScore(int element, List<int> trees)
            {
                for (int i = 0; i < trees.Count; i++)
                {
                    if (trees[i] >= element)
                    {
                        return i + 1;
                    }
                }
                return trees.Count;
            }
        }
    }
}
