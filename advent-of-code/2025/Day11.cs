using aoc.Shared;

namespace aoc._2025
{
    internal static class Day11
    {
        internal static long Part1(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 11, useTest);
            List<string> lines = Utilities.StringToLines(input);

            var devices = InitialiseDevices(lines);
            var paths = TraverseGraph(devices, "you", "out");
            result = paths.Count;
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 11, useTest);
            List<string> lines = Utilities.StringToLines(input);
            var devices = InitialiseDevices(lines);

            // Count paths that go through both dac and fft (in any order)
            HashSet<string> mustVisit = new HashSet<string> { "dac", "fft" };
            result = CountPathsThrough(devices, "svr", "out", mustVisit);
            
            return result;
        }

        private static Dictionary<string, Device> InitialiseDevices(List<string> lines)
        {
            Dictionary<string, Device> deviceGraph = new Dictionary<string, Device>();
            
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || !line.Contains(':')) continue;
                
                var components = line.Split(':');
                var name = components[0].Trim();
                var outputNames = components[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                
                // Get or create the source device
                if (!deviceGraph.ContainsKey(name))
                {
                    deviceGraph[name] = new Device(name, new List<Device>());
                }
                
                // Get or create output devices and link them
                foreach (var outputName in outputNames)
                {
                    if (!deviceGraph.ContainsKey(outputName))
                    {
                        deviceGraph[outputName] = new Device(outputName, new List<Device>());
                    }
                    deviceGraph[name].Outputs!.Add(deviceGraph[outputName]);
                }
            }
            
            return deviceGraph;
        }

        /// <summary>
        /// Given a graph, start and end, return all unique paths from start to end.
        /// </summary>
        /// <param name="deviceGraph"></param>
        /// <param name="startDeviceName"></param>
        /// <param name="endDeviceName"></param>
        /// <returns>List of paths, where each path is a list of device names</returns>
        private static List<List<string>> TraverseGraph(Dictionary<string, Device> deviceGraph, string startDeviceName, string endDeviceName)
        {
            if (!deviceGraph.ContainsKey(startDeviceName) || !deviceGraph.ContainsKey(endDeviceName))
            {
                return new List<List<string>>();
            }
            
            List<List<string>> allPaths = new List<List<string>>();
            List<string> currentPath = new List<string>();
            HashSet<string> visited = new HashSet<string>();
            
            FindPaths(deviceGraph[startDeviceName], endDeviceName, visited, currentPath, allPaths);
            
            return allPaths;
        }
        
        /// <summary>
        /// DFS helper to find all unique paths from current device to end.
        /// Uses visited set to avoid cycles.
        /// </summary>
        private static void FindPaths(Device current, string endDeviceName, HashSet<string> visited, List<string> currentPath, List<List<string>> allPaths)
        {
            // Add current node to path
            currentPath.Add(current.Name);
            visited.Add(current.Name);
            
            // Reached the destination - save a copy of the path
            if (current.Name == endDeviceName)
            {
                allPaths.Add(new List<string>(currentPath));
            }
            else if (current.Outputs != null && current.Outputs.Count > 0)
            {
                // Continue exploring outputs
                foreach (var output in current.Outputs)
                {
                    if (!visited.Contains(output.Name))
                    {
                        FindPaths(output, endDeviceName, visited, currentPath, allPaths);
                    }
                }
            }
            
            // Backtrack: remove current node so other paths can use it
            currentPath.RemoveAt(currentPath.Count - 1);
            visited.Remove(current.Name);
        }
        
        /// <summary>
        /// Count paths from start to end that pass through ALL nodes in mustVisit.
        /// Uses memoization - assumes graph is a DAG (no cycles).
        /// </summary>
        private static long CountPathsThrough(
            Dictionary<string, Device> deviceGraph, 
            string startName, 
            string endName, 
            HashSet<string> mustVisit)
        {
            if (!deviceGraph.ContainsKey(startName) || !deviceGraph.ContainsKey(endName))
            {
                return 0;
            }
            
            // Memoization cache: (deviceName, fft, dac) -> count
            Dictionary<(string, bool, bool), long> memo = new Dictionary<(string, bool, bool), long>();
            
            return CountPathsDFS(deviceGraph, startName, false, false, mustVisit, memo);
        }
        
        /// <summary>
        /// DFS with memoization. Assumes DAG. State: (current node, has seen first required, has seen second required)
        /// </summary>
        private static long CountPathsDFS(
            Dictionary<string, Device> graph,
            string current, 
            bool seenFirst,
            bool seenSecond,
            HashSet<string> mustVisit,
            Dictionary<(string, bool, bool), long> memo)
        {
            // Update checkpoint flags based on current node
            // Assumes mustVisit has exactly 2 elements for this optimization
            var required = mustVisit.ToList();
            if (current == required[0]) seenFirst = true;
            if (current == required[1]) seenSecond = true;
            
            // Reached destination
            if (current == "out")
            {
                return (seenFirst && seenSecond) ? 1 : 0;
            }
            
            // Check memo
            var key = (current, seenFirst, seenSecond);
            if (memo.TryGetValue(key, out long cached))
            {
                return cached;
            }
            
            // No outputs - dead end
            if (!graph.TryGetValue(current, out var device) || 
                device.Outputs == null || 
                device.Outputs.Count == 0)
            {
                memo[key] = 0;
                return 0;
            }
            
            // Sum paths through all outputs
            long count = 0;
            foreach (var output in device.Outputs)
            {
                count += CountPathsDFS(graph, output.Name, seenFirst, seenSecond, mustVisit, memo);
            }
            
            memo[key] = count;
            return count;
        }

        internal record Device
        {
            public string Name { get; set; }
            public List<Device>? Outputs { get; set; }

            public Device(string name, List<Device>? outputs)
            {
                Name = name;
                Outputs = outputs;
            }
        }
    }
}
