namespace aoc._2022
{
    internal class Day9
    {
        public void Day9Part1()
        {
            var lines = Utilities.ReadInput(9);
            var visitedPos = new List<ValueTuple<int, int>>();
            var head = (0, 0);
            var tail = (0, 0);

            var tupleDict = new Dictionary<string, ValueTuple<int, int>>()
            {
                { "U", (0, 1) },
                { "D", (0, -1) },
                { "L", (-1, 0) },
                { "R", (1, 0) },
            };

            foreach (var line in lines)
            {
                // Read input and get new head position
                var input = line.Split();
                var nextHead = MoveHead(input, head);

                Console.WriteLine($"Head moving from {head} to {nextHead}");

                // Tail moves if Chebyshev distance bigger than 1
                if (ChebyshevDistance(nextHead, tail) > 1)
                {
                    // Tail moves to opposite of head direction
                    var nextTail = MoveTail(input, nextHead);

                    Console.WriteLine($"Because distance is {ChebyshevDistance(nextHead, tail)}, tail moves from {tail} to {nextTail}");
                    var tailPos = GetTailPositions(tail, nextHead);
                    visitedPos.AddRange(tailPos);
                    tail = nextTail;
                }

                head = nextHead;
            }

            var uniquePos = visitedPos.Distinct(new TupleEqualityComparer());

            Console.WriteLine($"Day 9 Part 1: {uniquePos.Count()}");
            // If head moves more than 1 in any direction, tail ends up next to head in opposite direction of movement
            // If tail movement then compare positions - get (x, y) deltas, tail moves diagonally to align with the inter delta
            // Add these values

            ValueTuple<int, int> MoveHead(string[] input, ValueTuple<int, int> head)
            {
                var direction = tupleDict[input[0]];
                var distance = int.Parse(input[1]);
                var movement = (direction.Item1 * distance, direction.Item2 * distance);

                return (movement.Item1 + head.Item1, movement.Item2 + head.Item2);
            }

            ValueTuple<int, int> MoveTail(string[] input, ValueTuple<int, int> head)
            {
                var direction = tupleDict[input[0]]; // Get OG Direction
                var reversed = (direction.Item1 * -1, direction.Item2 * -1); // Reverse direction

                // Tail is head + reversed
                return (head.Item1 + reversed.Item1, head.Item2 + reversed.Item2);
            }

            int ChebyshevDistance((int, int) head, (int, int) tail)
            {
                int dx = Math.Abs(head.Item1 - tail.Item1);
                int dy = Math.Abs(head.Item2 - tail.Item2);
                return Math.Max(dx, dy);
            }

            List<ValueTuple<int, int>> GetTailPositions((int, int) tail, (int, int) head)
            {
                var pos = new List<ValueTuple<int, int>>();

                // Easier names to understand
                var xPrev = tail.Item1;
                var yPrev = tail.Item2;
                var xNext = head.Item1;
                var yNext = head.Item2;
                var delta = (xNext - xPrev, yNext - yPrev);

                // Diagonal movement actually doesn't matter at all.
                // Calculate movement positions based on which cardinal direction is longer.

                // Assume straight movement along longer edge, but ignore adjacent position
                bool horizontal = (Math.Abs(delta.Item1) > Math.Abs(delta.Item2));
                if (horizontal)
                {
                    int xMin = Math.Min(xPrev, xNext);
                    int xMax = Math.Max(xPrev, xNext);
                    for (int x = xMin + 1; x < xMax; x++)
                    {
                        pos.Add((x, yNext));
                    }
                }
                else
                {
                    int yMin = Math.Min(yPrev, yNext);
                    int yMax = Math.Max(yPrev, yNext);
                    for (int y = yMin + 1; y < yMax; y++)
                    {
                        pos.Add((xNext, y));
                    }
                }
                return pos;
            }
        }

        public void Day9Part2()
        {
            var lines = Utilities.ReadInput(9);
            var visitedPos = new List<ValueTuple<int, int>>();

            // Create rope array
            (int, int)[] ropePos = new (int, int)[10];
            for (int i = 0; i < ropePos.Length; i++)
            {
                ropePos[i] = (0, 0);
            }

            var tupleDict = new Dictionary<string, ValueTuple<int, int>>()
            {
                { "U", (0, 1) },
                { "D", (0, -1) },
                { "L", (-1, 0) },
                { "R", (1, 0) },
            };
            // Loop through from head to end, running the MoveHead and MoveTail algorithm
            // Run GetTailPositions at the end only
            foreach (var line in lines)
            {
                // Read input and get new head position
                var input = line.Split();
                var nextHead = MoveHead(input, ropePos[0]);
                Console.WriteLine($"Head moving from {ropePos[0]} to {nextHead}");
                ropePos[0] = nextHead;

                // Loop through the remaining rope sections
                for (int i = 1; i < ropePos.Length; i++)
                {
                    // Check distance between two sections
                    if (ChebyshevDistance(ropePos[i - 1], ropePos[i]) > 1)
                    {
                        // Tail moves to opposite of head direction
                        var nextPos = MoveSection(ropePos[i], ropePos[i - 1]);

                        Console.WriteLine($"Because distance is {ChebyshevDistance(ropePos[i - 1], ropePos[i])}, section {i} moves from {ropePos[i]} to {nextPos}");

                        if (i == ropePos.Length - 1)
                        {
                            var tailPos = GetTailPositions(ropePos[9], ropePos[8]);
                            visitedPos.AddRange(tailPos);
                        }
                        ropePos[i] = nextPos;
                    }
                }
            }

            var uniquePos = visitedPos.Distinct(new TupleEqualityComparer());

            Console.WriteLine($"Day 9 Part 2: {uniquePos.Count()}");

            // If head moves more than 1 in any direction, tail ends up next to head in opposite direction of movement
            // If tail movement then compare positions - get (x, y) deltas, tail moves diagonally to align with the longer delta
            // Add these values

            ValueTuple<int, int> MoveHead(string[] input, ValueTuple<int, int> head)
            {
                var direction = tupleDict[input[0]];
                var distance = int.Parse(input[1]);
                var movement = (direction.Item1 * distance, direction.Item2 * distance);

                return (movement.Item1 + head.Item1, movement.Item2 + head.Item2);
            }

            ValueTuple<int, int> MoveSection(ValueTuple<int, int> back, ValueTuple<int, int> front)
            {
                // Get larger direction of movement
                var delta = (front.Item1 - back.Item1, front.Item2 - back.Item2);
                bool horizontal = (Math.Abs(delta.Item1) > Math.Abs(delta.Item2));
                string dir = "";
                if (horizontal)
                {
                    dir = (delta.Item1 > 0) ? "R" : "L";
                }
                else
                {
                    dir = (delta.Item2 > 0) ? "U" : "D";
                }

                var direction = tupleDict[dir]; // Get OG Direction
                var reversed = (direction.Item1 * -1, direction.Item2 * -1); // Reverse direction

                // Tail is head + reversed
                return (front.Item1 + reversed.Item1, front.Item2 + reversed.Item2);
            }

            int ChebyshevDistance((int, int) head, (int, int) tail)
            {
                int dx = Math.Abs(head.Item1 - tail.Item1);
                int dy = Math.Abs(head.Item2 - tail.Item2);
                return Math.Max(dx, dy);
            }

            List<ValueTuple<int, int>> GetTailPositions((int, int) tail, (int, int) head)
            {
                var pos = new List<ValueTuple<int, int>>();

                // Easier names to understand
                var xPrev = tail.Item1;
                var yPrev = tail.Item2;
                var xNext = head.Item1;
                var yNext = head.Item2;
                var delta = (xNext - xPrev, yNext - yPrev);

                // Diagonal movement actually doesn't matter at all.
                // Calculate movement positions based on which cardinal direction is longer.

                // Assume straight movement along longer edge, but ignore adjacent position
                bool horizontal = (Math.Abs(delta.Item1) > Math.Abs(delta.Item2));
                if (horizontal)
                {
                    int xMin = Math.Min(xPrev, xNext);
                    int xMax = Math.Max(xPrev, xNext);
                    for (int x = xMin + 1; x < xMax; x++)
                    {
                        pos.Add((x, yNext));
                    }
                }
                else
                {
                    int yMin = Math.Min(yPrev, yNext);
                    int yMax = Math.Max(yPrev, yNext);
                    for (int y = yMin + 1; y < yMax; y++)
                    {
                        pos.Add((xNext, y));
                    }
                }
                Console.WriteLine($"Section 9 is moving from {tail} to {head} and covers positions: {string.Join(", ", pos)}");
                return pos;
            }
        }

        class TupleEqualityComparer : IEqualityComparer<(int, int)>
        {
            public bool Equals((int, int) x, (int, int) y)
            {
                // Return true if the tuples are equal, false otherwise
                return x.Item1 == y.Item1 && x.Item2 == y.Item2;
            }

            public int GetHashCode((int, int) obj)
            {
                // Return a hash code for the tuple
                return (obj.Item1, obj.Item2).GetHashCode();
            }
        }
    }
}
