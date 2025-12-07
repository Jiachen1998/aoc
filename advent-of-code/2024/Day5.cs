using aoc.Shared;
using System;

namespace aoc._2024
{
    internal static class Day5
    {
        internal class Rules
        {
            public int Left { get; set; }
            public int Right { get; set; }

            public Rules(int left, int right)
            {
                Left = left;
                Right = right;
            }
        }

        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 5, useTest);
            List<string> lines = Utilities.StringToLines(input);

            var rules = new List<Rules>();
            var updates = new List<List<int>>();

            var validUpdates = new List<List<int>>();

            int result = 0;
            foreach (var line in lines)
            {
                if (line.Contains('|'))
                {
                    var nums = line.Split('|').Select(n => int.Parse(n)).ToList();                    
                    rules.Add(new Rules(nums[0], nums[1]));
                }
                else if (line.Contains(','))
                {
                    var nums = line.Split(",").Select(n => int.Parse(n)).ToList();
                    updates.Add(nums);
                }
            }

            //  Foreach number, look up rules and evaluate if it breaks any rules
            foreach (var update in  updates)
            {
                // Console.WriteLine($"This Update: {string.Join(",", update)}");
                var isValid = true;
                for (int i = 1; i < update.Count; i++)
                {
                    var num = update[i];
                    // If number is in the first half of the update
                    if (i <  update.Count / 2)
                    {                        
                        // Find all rules where number is on Left
                        var validRulesRight = rules.Where(r => r.Left == num).Select(r => r.Right).ToList();

                        // Get sublist to the left of num
                        var previousSeg = update.Take(new Range(0, i)).ToList();

                        // Assert that for our valid rules, no 'right' number should be present in the segment
                        var intersection = previousSeg.Intersect(validRulesRight);
                        if (intersection.Count() > 0)
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        // If number is in the second half, then find all rules where number is on Right, check following segment if right number exists
                        var validRulesLeft = rules.Where(r => r.Right == num).Select(r => r.Left).ToList();
                        var followingSeg = update.Take(new Range(i + 1, update.Count)).ToList();
                        var intersection = followingSeg.Intersect(validRulesLeft);
                        if (intersection.Count() > 0)
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    Console.WriteLine($"This Update is valid: {string.Join(",", update)}");
                    validUpdates.Add(update);
                }
                    
            }
            
            foreach(var update in validUpdates)
            {
                // 0 0 0 0 0
                var count = update.Count;
                result += update[count / 2];
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 5, useTest);
            List<string> lines = Utilities.StringToLines(input);

            var rules = new List<Rules>();
            var updates = new List<List<int>>();

            var invalid = new List<List<int>>();

            int result = 0;
            foreach (var line in lines)
            {
                if (line.Contains('|'))
                {
                    var nums = line.Split('|').Select(n => int.Parse(n)).ToList();
                    rules.Add(new Rules(nums[0], nums[1]));
                }
                else if (line.Contains(','))
                {
                    var nums = line.Split(",").Select(n => int.Parse(n)).ToList();
                    updates.Add(nums);
                }
            }

            //  Foreach number, look up rules and evaluate if it breaks any rules
            foreach (var update in updates)
            {
                var isValid = true;
                for (int i = 1; i < update.Count; i++)
                {
                    var num = update[i];
                    // If number is in the first half of the update
                    if (i < update.Count / 2)
                    {
                        // Find all rules where number is on Left
                        var validRulesRight = rules.Where(r => r.Left == num).Select(r => r.Right).ToList();

                        // Get sublist to the left of num
                        var previousSeg = update.Take(new Range(0, i)).ToList();

                        // Assert that for our valid rules, no 'right' number should be present in the segment
                        var intersection = previousSeg.Intersect(validRulesRight);
                        if (intersection.Count() > 0)
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        // If number is in the second half, then find all rules where number is on Right, check following segment if right number exists
                        var validRulesLeft = rules.Where(r => r.Right == num).Select(r => r.Left).ToList();
                        var followingSeg = update.Take(new Range(i + 1, update.Count)).ToList();
                        var intersection = followingSeg.Intersect(validRulesLeft);
                        if (intersection.Count() > 0)
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (!isValid)
                {
                    // Console.WriteLine($"This Update is valid: {string.Join(",", update)}");
                    invalid.Add(update);
                }
            }

            foreach (var update in invalid)
            {
                // TODO: Reorganise and get middle
                // While loop to keep sorting until all rules are met?
                var isSorted = false;
                // Console.WriteLine($"Sorting: {string.Join(",", update)}");
                while (!isSorted)
                {
                    int anyIntersection = 0;
                    for (int i = 1; i < update.Count; i++)
                    {
                        var num = update[i];

                        // Find all rules where number is on Left
                        var validRulesRight = rules.Where(r => r.Left == num).Select(r => r.Right).ToList();

                        // Get sublist to the left of num
                        var previousSeg = update.Take(new Range(0, i)).ToList();

                        // Assert that for our valid rules, no 'right' number should be present in the segment
                        var intersection = previousSeg.Intersect(validRulesRight).ToList();

                        // Any numbers intersecting is breaking the rules
                        if (intersection.Count > 0)
                        {
                            anyIntersection += intersection.Count;
                            // We get index of rule breaker and swap positions in list
                            var invalidIndex = update.IndexOf(intersection[0]);
                            // Console.WriteLine($"Swapping: {num}, {intersection[0]}");
                            update.Swap(i, invalidIndex);
                            // Console.WriteLine($"After Swap: {string.Join(",", update)}");
                            break;
                        }
                    }
                    if (anyIntersection == 0)
                    {
                        isSorted = true;
                        // Console.WriteLine($"Sorted: {string.Join(",", update)}");
                    }
                    
                }
            }

            foreach (var update in invalid)
            {
                // 0 0 0 0 0
                var count = update.Count;
                result += update[count / 2];
            }
            return result;
        }

        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

    }
}
