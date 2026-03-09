using aoc.Shared;

namespace aoc._2025
{
    internal static class Day8
    {
        internal static long Part1(bool useTest = false)
        {
            long iterations = useTest ? 10 : 1000;
            string input = Utilities.ReadInputFile(2025, 8, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            // Convert each line to a tuple of (x, y, z)
            var points = lines.Select(line =>
            {
                var parts = line.Split(',');
                return (x: long.Parse(parts[0]), y: long.Parse(parts[1]), z: long.Parse(parts[2]));
            }).ToList();

            // List of connected points
            var networks = new List<List<(long x, long y, long z)>>();

            // Find the X closest pairs of points based on Euclidean distance
            // Different pairs can share the same point, but cannot be both points of the same pair
            // O(n²) to generate all pairs, O(n² log n²) to sort, O(X) to take first X = O(n² log n²) overall
            var allPairs = new List<(long distance, (long x, long y, long z) point1, (long x, long y, long z) point2, int index1, int index2)>();
            
            for (int j = 0; j < points.Count; j++)
            {
                for (int k = j + 1; k < points.Count; k++)
                {
                    long distance = Utilities.CalculateEuclideanDistance3D(points[j], points[k]);
                    allPairs.Add((distance, points[j], points[k], j, k));
                }
            }
            
            // Sort by distance and take the first X pairs
            var closestPairs = allPairs
                .OrderBy(p => p.distance)
                .Take((int)iterations)
                .ToList();

            // Connect pairs if they share the same point to form larger networks
            // Use a dictionary to track which network each point belongs to
            var pointToNetwork = new Dictionary<(long x, long y, long z), int>();
            
            foreach (var pair in closestPairs)
            {
                bool point1InNetwork = pointToNetwork.ContainsKey(pair.point1);
                bool point2InNetwork = pointToNetwork.ContainsKey(pair.point2);
                
                if (!point1InNetwork && !point2InNetwork)
                {
                    // Both points are new - create a new network
                    int newNetworkIndex = networks.Count;
                    networks.Add(new List<(long x, long y, long z)> { pair.point1, pair.point2 });
                    pointToNetwork[pair.point1] = newNetworkIndex;
                    pointToNetwork[pair.point2] = newNetworkIndex;
                }
                else if (point1InNetwork && !point2InNetwork)
                {
                    // point1 is in a network, add point2 to the same network (if not already present)
                    int networkIndex = pointToNetwork[pair.point1];
                    if (!networks[networkIndex].Contains(pair.point2))
                    {
                        networks[networkIndex].Add(pair.point2);
                    }
                    pointToNetwork[pair.point2] = networkIndex;
                }
                else if (!point1InNetwork && point2InNetwork)
                {
                    // point2 is in a network, add point1 to the same network (if not already present)
                    int networkIndex = pointToNetwork[pair.point2];
                    if (!networks[networkIndex].Contains(pair.point1))
                    {
                        networks[networkIndex].Add(pair.point1);
                    }
                    pointToNetwork[pair.point1] = networkIndex;
                }
                else
                {
                    // Both points are in networks - merge networks if they're different
                    int network1Index = pointToNetwork[pair.point1];
                    int network2Index = pointToNetwork[pair.point2];
                    
                    if (network1Index != network2Index)
                    {
                        // Merge network2 into network1
                        foreach (var point in networks[network2Index])
                        {
                            pointToNetwork[point] = network1Index;
                            if (!networks[network1Index].Contains(point))
                            {
                                networks[network1Index].Add(point);
                            }
                        }
                        networks[network2Index].Clear(); // Mark as merged (empty list)
                    }
                    // If they're already in the same network, do nothing
                }
            }

            networks.RemoveAll(network => network.Count == 0);

            // Calculate the lengths of the networks in descending order
            var networkLengths = networks
                .Where(network => network.Count > 0) // Filter out merged/empty networks
                .Select(network => network.Count)
                .OrderByDescending(length => length)
                .ToList();

            // Result is length of 3 longest networks multiplied together            
            return (long)networkLengths[0] * networkLengths[1] * networkLengths[2];
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 8, useTest);
            List<string> lines = Utilities.StringToLines(input);          

            // Convert each line to a tuple of (x, y, z)
            var points = lines.Select(line =>
            {
                var parts = line.Split(',');
                return (x: long.Parse(parts[0]), y: long.Parse(parts[1]), z: long.Parse(parts[2]));
            }).ToList();

            // List of connected points
            var networks = new List<List<(long x, long y, long z)>>();

            // Find the X closest pairs of points based on Euclidean distance
            // Different pairs can share the same point, but cannot be both points of the same pair
            // O(n²) to generate all pairs, O(n² log n²) to sort, O(X) to take first X = O(n² log n²) overall
            var allPairs = new List<(long distance, (long x, long y, long z) point1, (long x, long y, long z) point2, int index1, int index2)>();
            
            for (int j = 0; j < points.Count; j++)
            {
                for (int k = j + 1; k < points.Count; k++)
                {
                    long distance = Utilities.CalculateEuclideanDistance3D(points[j], points[k]);
                    allPairs.Add((distance, points[j], points[k], j, k));
                }
            }
            
            // Sort by distance and take the first X pairs
            var closestPairs = allPairs
                .OrderBy(p => p.distance)
                .ToList();

            // Connect pairs if they share the same point to form larger networks
            // Use a dictionary to track which network each point belongs to
            var pointToNetwork = new Dictionary<(long x, long y, long z), int>();
            
            foreach (var pair in closestPairs)
            {
                bool point1InNetwork = pointToNetwork.ContainsKey(pair.point1);
                bool point2InNetwork = pointToNetwork.ContainsKey(pair.point2);
                
                if (!point1InNetwork && !point2InNetwork)
                {
                    // Both points are new - create a new network
                    int newNetworkIndex = networks.Count;
                    networks.Add(new List<(long x, long y, long z)> { pair.point1, pair.point2 });
                    pointToNetwork[pair.point1] = newNetworkIndex;
                    pointToNetwork[pair.point2] = newNetworkIndex;
                }
                else if (point1InNetwork && !point2InNetwork)
                {
                    // point1 is in a network, add point2 to the same network (if not already present)
                    int networkIndex = pointToNetwork[pair.point1];
                    if (!networks[networkIndex].Contains(pair.point2))
                    {
                        networks[networkIndex].Add(pair.point2);
                    }
                    pointToNetwork[pair.point2] = networkIndex;
                }
                else if (!point1InNetwork && point2InNetwork)
                {
                    // point2 is in a network, add point1 to the same network (if not already present)
                    int networkIndex = pointToNetwork[pair.point2];
                    if (!networks[networkIndex].Contains(pair.point1))
                    {
                        networks[networkIndex].Add(pair.point1);
                    }
                    pointToNetwork[pair.point1] = networkIndex;
                }
                else
                {
                    // Both points are in networks - merge networks if they're different
                    int network1Index = pointToNetwork[pair.point1];
                    int network2Index = pointToNetwork[pair.point2];
                    
                    if (network1Index != network2Index)
                    {
                        // Merge network2 into network1
                        foreach (var point in networks[network2Index])
                        {
                            pointToNetwork[point] = network1Index;
                            if (!networks[network1Index].Contains(point))
                            {
                                networks[network1Index].Add(point);
                            }
                        }
                        networks[network2Index].Clear(); // Mark as merged (empty list)
                    }
                    // If they're already in the same network, do nothing
                }

                var longestNetwork = networks.OrderByDescending(network => network.Count).First();
                if (longestNetwork.Count == points.Count)
                {
                    return pair.point1.x * pair.point2.x;
                }
            }
            
            return 0;
        }
    }
}
