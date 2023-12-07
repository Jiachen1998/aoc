using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc._2022
{
    internal class Day11
    {
        public void Day11Part1(int part)
        {
            var path = $@"C:\Users\1220950\Documents\Repositories\SelfProjects\aoc-2022\aoc-2022\Inputs\Day11Test.txt";
            var input = File.ReadAllText(path);
            long sum = 0;
            var roundCount = part == 1 ? 20 : 10000;
            var LCM = 9699690;

            List<string> MonkeyInputs = input.Split("Monkey").ToList();
            var monkeys = new List<Monkey>();

            // Loop through each new monkey
            foreach (var monkeyInput in MonkeyInputs)
            {
                var lines = monkeyInput.Split("\r\n");
                var monkeyParams = new List<string>();

                // Loop through monkey parameters and add values
                foreach (var rawLine in lines)
                {
                    if (rawLine == string.Empty) continue;
                    var trimmed = rawLine.Trim();
                    var line = trimmed.Split(":");
                    if (line[1] != string.Empty)
                    {
                        monkeyParams.Add(line[1]);
                    }
                    else
                    {
                        monkeyParams.Add(line[0]);
                    }
                }

                if (monkeyParams.Count == 0) continue;

                // Convert string values into monkey obj
                monkeys.Add(new Monkey(monkeyParams));
            }

            for (long i = 0; i < roundCount; i++)
            {
                ComputeRound();
                Console.WriteLine($"Round {i + 1}: \t" +
                    $"\tMonkey {monkeys[0].ID}: {monkeys[0].InspectCount}" +
                    $"\tMonkey {monkeys[1].ID}: {monkeys[1].InspectCount}" +
                    $"\tMonkey {monkeys[2].ID}: {monkeys[2].InspectCount}" +
                    $"\tMonkey {monkeys[3].ID}: {monkeys[3].InspectCount}");
            }

            var topTwo = monkeys.OrderByDescending(x => x.InspectCount).Take(2).ToList();
            sum = topTwo[0].InspectCount * topTwo[1].InspectCount;

            Console.WriteLine($"Day 11 Part 1: {sum}");

            void ComputeRound()
            {
                // Loop through monkeys from start to end
                for (long i = 0; i < monkeys.Count; i++)
                {
                    var thisMonkey = monkeys.FirstOrDefault(x => x.ID == i);

                    // Throw all items from that monkey
                    while (thisMonkey.Items.Count > 0)
                    {
                        var targetMonkeyAndItem = new List<long>();
                        if (part == 1)
                        {
                            targetMonkeyAndItem = thisMonkey.ThrowItem();
                        }
                        else
                        {
                            targetMonkeyAndItem = thisMonkey.ThrowItemPart2(LCM);
                        }
                        monkeys?
                            .FirstOrDefault(x => x.ID == targetMonkeyAndItem[0]) // Get the target monkey
                            .Items.Add(targetMonkeyAndItem[1]); // Add item to it
                    }
                }
            }
        }

        public class Monkey
        {
            public long ID { get; init; }
            public IList<long> Items { get; set; }
            public Operation InspectOperation { get; set; }
            public long DivTest { get; init; }
            public Dictionary<string, long> Throws { get; init; }
            public long InspectCount { get; set; }

            public Monkey(IList<string> inputList)
            {
                ID = long.Parse(inputList[0]);
                Items = inputList[1].Split(',').Select(long.Parse).ToList();
                var opInput = inputList[2].Split(" ").TakeLast(2);
                InspectOperation = new Operation(opInput.First(), opInput.Last());
                DivTest = long.Parse(inputList[3].Split(" ").Last());
                Throws = new Dictionary<string, long>
            {
                { "true", long.Parse(inputList[4].Split(" ").Last()) },
                { "false", long.Parse(inputList[5].Split(" ").Last()) },
            };
                InspectCount = 0;
            }

            public class Operation
            {
                public string Operand { get; init; }
                public string Value { get; set; }
                public Operation(string operand, string value)
                {
                    Operand = operand;
                    Value = value;
                }
            }

            public double MultiplyWorryLevel(long initialWorry)
            {
                long num = long.TryParse(InspectOperation.Value, out num) ? num : initialWorry;
                return InspectOperation.Operand switch
                {
                    "+" => initialWorry + num,
                    "-" => initialWorry - num,
                    "*" => initialWorry * num,
                    "/" => initialWorry / num,
                    _ => throw new InvalidOperationException("Invalid operation"),
                };
            }

            public List<long> ThrowItem()
            {
                // Get first item from list
                long worryLevel = Items.FirstOrDefault();
                Items.RemoveAt(0);

                // Multiply based on operation and divide by 3
                worryLevel = (long)Math.Floor(MultiplyWorryLevel(worryLevel) / 3);

                // Increase inspect count here
                InspectCount++;

                if (worryLevel % DivTest == 0)
                {
                    return new List<long> { Throws["true"], worryLevel };
                }
                else
                {
                    return new List<long> { Throws["false"], worryLevel };
                }
            }

            public List<long> ThrowItemPart2(long LCM)
            {
                // Get first item from list
                long worryLevel = Items.FirstOrDefault();
                Items.RemoveAt(0);

                // Modulo based on LCM
                worryLevel = (long)MultiplyWorryLevel(worryLevel) % LCM;

                // Increase inspect count here
                InspectCount++;

                if (worryLevel % DivTest == 0)
                {
                    return new List<long> { Throws["true"], worryLevel };
                }
                else
                {
                    return new List<long> { Throws["false"], worryLevel };
                }
            }
        }
    }
}
