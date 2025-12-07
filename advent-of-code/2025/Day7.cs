using System.ComponentModel;
using aoc.Shared;

namespace aoc._2025
{
    internal static class Day7
    {
        internal static long Part1(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 7, useTest);
            List<string> lines = Utilities.StringToLines(input);

            // Store list of all the x positions of the beams
            var beamXPos = new HashSet<int>();

            var startCoords = (lines[0].IndexOf('S'), 0);
            beamXPos.Add(startCoords.Item1);

            // Descend through the grid
            foreach (var line in lines)
            {
                // Create a new set of x positions for the next iteration
                var nextBeamXPos = new HashSet<int>();

                // For each x position of the beam, check if we hit a splitter
                foreach (var x in beamXPos)
                {
                    // If we hit a splitter, modify the x positions
                    if (line[x] == '^')
                    {
                        nextBeamXPos.UnionWith(SplitBeam(x, beamXPos));
                        result++;
                    }
                    else
                    {
                        // Beam continues straight down if no splitter
                        nextBeamXPos.Add(x);
                    }
                }

                // Update the beamXPos set
                beamXPos = nextBeamXPos;
            }

            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 7, useTest);
            List<string> lines = Utilities.StringToLines(input);

            // Track number of paths reaching each x position
            // Dictionary: x position -> number of unique paths reaching that position
            var pathCounts = new Dictionary<int, long>();

            var startX = lines[0].IndexOf('S');
            pathCounts[startX] = 1; // Start with 1 path at the starting position

            // Descend through the grid
            foreach (var line in lines)
            {
                // Create a new dictionary for the next row
                var nextPathCounts = new Dictionary<int, long>();

                // Process each position that has paths
                foreach (var kvp in pathCounts)
                {
                    int x = kvp.Key;
                    long pathCount = kvp.Value;

                    // If we hit a splitter, split the paths
                    if (line[x] == '^')
                    {
                        int leftX = x - 1;
                        int rightX = x + 1;

                        // Add paths to left position (sum if multiple paths reach same position)
                        nextPathCounts.TryGetValue(leftX, out long existingLeft);
                        nextPathCounts[leftX] = existingLeft + pathCount;

                        // Add paths to right position
                        nextPathCounts.TryGetValue(rightX, out long existingRight);
                        nextPathCounts[rightX] = existingRight + pathCount;
                    }
                    else
                    {
                        // Beam continues straight down - paths continue to same x position
                        nextPathCounts.TryGetValue(x, out long existing);
                        nextPathCounts[x] = existing + pathCount;
                    }
                }

                // Update pathCounts for next iteration
                pathCounts = nextPathCounts;
            }

            // Sum all path counts to get total unique paths
            result = pathCounts.Values.Sum();
            return result;
        }

        /// <summary>
        /// Method that splits the beam at a given x position, by assigning the left and right x positions to the beamXPos set.
        /// E.g. if we hit a splitter at x = 5, then the beamXPos set will be updated to contain the values 4 and 6, and 5 is removed.
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="beamXPos"></param>
        private static HashSet<int> SplitBeam(int xPos, HashSet<int> beamXPos)
        {
            HashSet<int> splitPositions = new HashSet<int>();
            
            // Split the beam into left and right positions
            splitPositions.Add(xPos - 1); // Left position
            splitPositions.Add(xPos + 1); // Right position
            
            return splitPositions;
        }
    }
}
