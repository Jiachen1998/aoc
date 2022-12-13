using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022
{
    internal static class Helpers
    {
        public static List<string> ReadInput(int day)
        {
            var path = $@"C:\Users\jiach\Documents\GitRepos\Visual Studio\Playground\aoc-2022\aoc-2022\Inputs\Day{day}.txt";
            var lines = File.ReadAllLines(path).ToList();
            return lines;
        }

        public static int RockPaperScizzorsSolver(string line)
        {
            var inputs = line.Split(' ');
            var score = scoreDict[inputs[1]]; // Add the score of player's shape first

            var result = matchupDict1
                [inputs[1]]  // Use player's shape to get possible outcomes
                [inputs[0]]; // Get the outcome based on opponent's shape
            score += scoreDict[result];
            return score;
        }

        public static int RockPaperScizzorsSolverPart2(string line)
        {
            var inputs = line.Split(' ');
            var score = scoreDict2[inputs[1]]; // Add the outcome first

            // Get array of shapes in { Lose, Draw, Win } based on opponent choice
            var playerShape = matchupDict2
                [inputs[0]]  // Use opponent's shape to get possible player shapes
                [inputs[1]];  // Use desired outcome to get player's shape

            score += scoreDict2[playerShape];
            return score;
        }

        // Key - Player Shape || Value - Dict of outcomes based on opponent
        private static Dictionary<string, Dictionary<string, string>> matchupDict1 = new Dictionary<string, Dictionary<string, string>>()
        {
            { "X", new Dictionary<string, string>()
                {
                    // Key - Opponent Shape || Value - Outcome
                    { "B", "Lose" },
                    { "A", "Draw" },
                    { "C", "Win" }
                }
            },
            { "Y", new Dictionary<string, string>()
                {
                    { "C", "Lose" },
                    { "B", "Draw" },
                    { "A", "Win" }
                }
            },
            { "Z", new Dictionary<string, string>()
                {
                    { "A", "Lose" },
                    { "C", "Draw" },
                    { "B", "Win" }
                }
            },
        };

        // Key - Opponent Shape || Value - Dict of player shapes outcomes based on outcome
        private static Dictionary<string, Dictionary<string, string>> matchupDict2 = new Dictionary<string, Dictionary<string, string>>()
        {
            { "A", new Dictionary<string, string>()
                {
                    // Key - Outcome || Value - Player shape needed
                    { "X", "C" },
                    { "Y", "A" },
                    { "Z", "B" }
                }
            },
            { "B", new Dictionary<string, string>()
                {
                    { "X", "A" },
                    { "Y", "B" },
                    { "Z", "C" }
                }
            },
            { "C", new Dictionary<string, string>()
                {
                    { "X", "B" },
                    { "Y", "C" },
                    { "Z", "A" }
                }
            },
        };

        private static Dictionary<string, int> scoreDict = new Dictionary<string, int>()
        {
            { "X", 1 },
            { "Y", 2 },
            { "Z", 3 },
            { "Win", 6 },
            { "Draw", 3 },
            { "Lose", 0 }
        };

        private static Dictionary<string, int> scoreDict2 = new Dictionary<string, int>()
        {
            { "A", 1 }, // Rock
            { "B", 2 }, // Paper
            { "C", 3 }, // Scizzors
            { "X", 0 }, // Lose
            { "Y", 3 }, // Draw
            { "Z", 6 }  // Win
        };

        public static Dictionary<char, int> createAlphabetDict()
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
