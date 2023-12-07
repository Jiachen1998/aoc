namespace aoc._2022
{
    internal class Day5
    {
        public static void Day5Part1()
        {
            var lines = Utilities.ReadInput(5);

            var delimiters = new string[] { "move", "from", "to" };
            var stacksInRightOrder = false;
            var stacks = new List<Stack<char>>();
            for (int i = 0; i < 9; i++)
            {
                stacks.Add(new Stack<char>());
            }

            foreach (var line in lines)
            {
                if (line.Contains("["))
                {
                    string[] chunks = Enumerable.Range(0, 9)
                            .Select(i => line.Substring(i * 4, 3))
                            .ToArray();

                    for (int i = 0; i < 9; i++)
                    {
                        char elem = chunks[i][1];
                        if (!elem.Equals(' '))
                        {
                            stacks[i].Push(elem);
                        }
                    }
                    continue;
                }

                if (line.Contains("move"))
                {
                    if (!stacksInRightOrder)
                    {
                        for (int i = 0; i < stacks.Count; i++)
                        {
                            var temp = new Stack<char>();
                            while (stacks[i].Count > 0)
                            {
                                temp.Push(stacks[i].Pop());
                            }
                            stacks[i] = temp;
                        }
                        stacksInRightOrder = true;
                    }

                    int[] values = line.Split(delimiters, StringSplitOptions.None)
                        .TakeLast(3) // First elem is "" to be ignored
                        .Select(s => int.Parse(s)) // Cast string to int
                        .ToArray();

                    for (int i = 0; i < values[0]; i++)
                    {
                        var package = stacks[values[1] - 1].Pop();
                        stacks[values[2] - 1].Push(package);
                    }
                }
            }

            foreach (var stack in stacks)
            {
                Console.Write($"{stack.Pop()}");
            }
        }

        public static void Day5Part2()
        {
            var lines = Utilities.ReadInput(5);

            var delimiters = new string[] { "move", "from", "to" };
            var stacksInRightOrder = false;
            var stacks = new List<Stack<char>>();
            for (int i = 0; i < 9; i++)
            {
                stacks.Add(new Stack<char>());
            }

            foreach (var line in lines)
            {
                if (line.Contains("["))
                {
                    string[] chunks = Enumerable.Range(0, 9)
                            .Select(i => line.Substring(i * 4, 3))
                            .ToArray();

                    for (int i = 0; i < 9; i++)
                    {
                        char elem = chunks[i][1];
                        if (!elem.Equals(' '))
                        {
                            stacks[i].Push(elem);
                        }
                    }
                    continue;
                }

                if (line.Contains("move"))
                {
                    if (!stacksInRightOrder)
                    {
                        for (int i = 0; i < stacks.Count; i++)
                        {
                            var temp = new Stack<char>();
                            while (stacks[i].Count > 0)
                            {
                                temp.Push(stacks[i].Pop());
                            }
                            stacks[i] = temp;
                        }
                        stacksInRightOrder = true;
                    }

                    int[] values = line.Split(delimiters, StringSplitOptions.None)
                        .TakeLast(3) // First elem is "" to be ignored
                        .Select(s => int.Parse(s)) // Cast string to int
                        .ToArray();

                    var crate = new Stack<char>();
                    for (int i = 0; i < values[0]; i++)
                    {
                        crate.Push(stacks[values[1] - 1].Pop());
                    }
                    for (int i = 0; i < values[0]; i++)
                    {
                        stacks[values[2] - 1].Push(crate.Pop());
                    }
                }
            }

            foreach (var stack in stacks)
            {
                Console.Write($"{stack.Pop()}");
            }
        }
    }
}
