namespace aoc_2022
{
    internal static class Solution
    {

        public static void Day1()
        {
            var lines = Helpers.ReadInput(1);
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

        public static void Day2()
        {
            var lines = Helpers.ReadInput(2);
            var scoreTotal = 0;
            foreach (var line in lines)
            {
                scoreTotal += Helpers.RockPaperScizzorsSolver(line);
            }
            Console.WriteLine(scoreTotal);
        }

        public static void Day2Part2()
        {
            var lines = Helpers.ReadInput(2);
            var scoreTotal = 0;
            foreach (var line in lines)
            {
                scoreTotal += Helpers.RockPaperScizzorsSolverPart2(line);
            }
            Console.WriteLine(scoreTotal);
        }

        public static void Day3()
        {
            var lines = Helpers.ReadInput(3);
            var sum = 0;
            var alphabetDict = Helpers.createAlphabetDict();

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
            var lines = Helpers.ReadInput(3);
            var sum = 0;
            var alphabetDict = Helpers.createAlphabetDict();
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

        public static void Day4()
        {
            var lines = Helpers.ReadInput(4);
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
            var lines = Helpers.ReadInput(4);
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

        public static void Day5()
        {
            var lines = Helpers.ReadInput(5);

            var delimiters = new string[] { "move", "from", "to" };
            var stacksInRightOrder = false;
            var stacks = new List<Stack<char>>();
            for (int i = 0; i < 9; i++)
            {
                stacks.Add(new Stack<char>());
            }

            foreach (var line in lines)
            {
                if(line.Contains("["))
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

                if(line.Contains("move"))
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
                        stacksInRightOrder= true;
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
            var lines = Helpers.ReadInput(5);

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

        public static void Day6()
        {
            var line = Helpers.ReadInput(6).FirstOrDefault();
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
            var line = Helpers.ReadInput(6).FirstOrDefault();
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

        public static void Day7()
        {
            var lines = Helpers.ReadInput(7);
            var root = new TreeNode.Directory("/");
            var currentDir = root;
            var sum = 0;

            foreach (var line in lines)
            {
                var inputs = line.Split(' ');
                Console.WriteLine($"Current Dir: {currentDir.Name}, Parent: {currentDir.Parent?.Name}");
                Console.WriteLine($"Inputs: {line}");
                Console.WriteLine();
                if (inputs[0] == "$")
                {
                    // Traversal to new directory
                    if (inputs[1] == "cd")
                    {
                        // Go up
                        if (inputs[2] == "..")
                        {
                            if (currentDir.Parent != null)
                            {
                                currentDir = currentDir.Parent;
                            }
                        }
                        else
                        {
                            currentDir = root.SearchTree(root, inputs[2]);
                            // currentDir = currentDir.SearchChildren(currentDir, inputs[2]);
                        }
                    }
                }
                // Add directory
                else if (inputs[0] == "dir")
                {
                    var newDir = new TreeNode.Directory(name: inputs[1]);
                    currentDir.AddChild(newDir);
                }
                // Add file
                else if (int.TryParse(inputs[0], out int size))
                {
                    var newFile = new TreeNode.File(size: size, name: inputs[1]);
                    currentDir.AddChild(newFile);
                }
            }

            

        }
    }
}
