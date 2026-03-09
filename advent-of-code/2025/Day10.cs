using aoc.Shared;

namespace aoc._2025
{
    internal static class Day10
    {
        internal static long Part1(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 10, useTest);
            List<string> lines = Utilities.StringToLines(input);
            foreach (var line in lines)
            {
                var components = GetComponents(line);
                var targetLights = ConvertLights(components[0]);
                var buttons = GetButtons(components[1], targetLights.Length);
                
                // Find minimum button presses using Gaussian elimination over GF(2)
                int minPresses = FindMinimumButtonPresses(buttons, targetLights);
                result += minPresses;
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 10, useTest);
            List<string> lines = Utilities.StringToLines(input);
            foreach (var line in lines)
            {
                var components = GetComponents(line);
                var targetJolts = ConvertJoltage(components[2]);
                var buttons = GetButtons(components[1], targetJolts.Length);

                // Find minimum butten presses
                int minPresses = FindMinimumButtonPresses(buttons, targetJolts);
                result += minPresses;
            }
            
            return result;
        }

        // Divide into components. E.g. [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
        private static List<string> GetComponents(string input)
        {
            List<string> components = new List<string>();
            
            // Extract square bracket component [.##.]
            int squareBracketStart = input.IndexOf('[');
            if (squareBracketStart >= 0)
            {
                int squareBracketEnd = input.IndexOf(']', squareBracketStart);
                if (squareBracketEnd >= 0)
                {
                    components.Add(input.Substring(squareBracketStart, squareBracketEnd - squareBracketStart + 1));
                }
            }
            
            // Extract all parentheses components (3) (1,3) (2) etc.
            string parenthesesComponent = "";
            int parenStart = input.IndexOf('(');
            while (parenStart >= 0)
            {
                int parenEnd = input.IndexOf(')', parenStart);
                if (parenEnd >= 0)
                {
                    if (parenthesesComponent.Length > 0)
                        parenthesesComponent += " ";
                    parenthesesComponent += input.Substring(parenStart, parenEnd - parenStart + 1);
                    parenStart = input.IndexOf('(', parenEnd + 1);
                }
                else
                {
                    break;
                }
            }
            components.Add(parenthesesComponent);
            
            // Extract curly braces component {3,5,4,7}
            int curlyStart = input.IndexOf('{');
            if (curlyStart >= 0)
            {
                int curlyEnd = input.IndexOf('}', curlyStart);
                if (curlyEnd >= 0)
                {
                    components.Add(input.Substring(curlyStart, curlyEnd - curlyStart + 1));
                }
            }
            
            return components;
        }

        /// <summary>
        /// Converts input string e.g. [.##.] to int array [0, 1, 1, 0]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static int[] ConvertLights(string input)
        {
            // Remove brackets [ and ]
            string content = input.Trim('[', ']');
            
            // Convert each character: . -> 0, # -> 1
            int[] lights = new int[content.Length];
            for (int i = 0; i < content.Length; i++)
            {
                lights[i] = content[i] == '#' ? 1 : 0;
            }
            
            return lights;
        }

        /// <summary>
        /// Converts input string e.g. {3,5,4,7} to int array [3, 5, 4, 7]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static int[] ConvertJoltage(string input)
        {
            string content = input.Trim('{', '}');
            return content
            .Split(',')
            .Select(i => int.Parse(i))
            .ToArray();
        }

        /// <summary>
        /// Given a string e.g. (3) (1,3) (2) and array length, return a list of int arrays representing the buttons.
        /// E.g. (3) -> [0, 0, 0, 1], (1, 3) -> [0, 1, 0, 1], etc.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static List<int[]> GetButtons(string input, int arrayLength)
        {
            List<int[]> buttons = new List<int[]>();
            
            // Split by spaces to get individual button definitions like "(3)", "(1,3)", etc.
            string[] buttonStrings = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string buttonString in buttonStrings)
            {
                // Remove parentheses
                string content = buttonString.Trim('(', ')');
                
                // Parse comma-separated indices
                int[] button = new int[arrayLength];
                if (!string.IsNullOrEmpty(content))
                {
                    string[] indices = content.Split(',');
                    foreach (string indexStr in indices)
                    {
                        if (int.TryParse(indexStr.Trim(), out int index))
                        {
                            if (index >= 0 && index < arrayLength)
                            {
                                button[index] = 1;
                            }
                        }
                    }
                }
                
                buttons.Add(button);
            }
            
            return buttons;
        }

        /// <summary>
        /// Uses Gaussian elimination to find the minimum number of button presses
        /// needed to reach the target configuration.
        /// Automatically detects GF(2) for binary targets or integer arithmetic for values >1.
        /// </summary>
        private static int FindMinimumButtonPresses(List<int[]> buttons, int[] target)
        {
            // Check if we're working in GF(2) (binary) or integer arithmetic
            bool isGF2 = true;
            foreach (int val in target)
            {
                if (val > 1)
                {
                    isGF2 = false;
                    break;
                }
            }
            
            // Also check button values
            if (isGF2)
            {
                foreach (var button in buttons)
                {
                    foreach (int val in button)
                    {
                        if (val > 1)
                        {
                            isGF2 = false;
                            break;
                        }
                    }
                    if (!isGF2) break;
                }
            }
            
            if (isGF2)
            {
                return FindMinimumButtonPressesGF2(buttons, target);
            }
            else
            {
                return FindMinimumButtonPressesInteger(buttons, target);
            }
        }
        
        /// <summary>
        /// Uses Gaussian elimination over GF(2) for binary targets (0/1)
        /// </summary>
        private static int FindMinimumButtonPressesGF2(List<int[]> buttons, int[] target)
        {
            int n = target.Length;
            int m = buttons.Count;
            
            // Create augmented matrix: [buttons | target]
            // Each row represents a light position, each column represents a button
            List<int[]> matrix = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] row = new int[m + 1];
                for (int j = 0; j < m; j++)
                {
                    row[j] = buttons[j][i];
                }
                row[m] = target[i]; // Augmented column
                matrix.Add(row);
            }
            
            // Gaussian elimination over GF(2)
            int rank = 0;
            List<int> pivotColumns = new List<int>();
            
            for (int col = 0; col < m && rank < n; col++)
            {
                // Find a row with 1 in this column
                int pivotRow = -1;
                for (int row = rank; row < n; row++)
                {
                    if (matrix[row][col] == 1)
                    {
                        pivotRow = row;
                        break;
                    }
                }
                
                if (pivotRow == -1) continue; // No pivot in this column
                
                // Swap rows
                if (pivotRow != rank)
                {
                    var temp = matrix[rank];
                    matrix[rank] = matrix[pivotRow];
                    matrix[pivotRow] = temp;
                }
                
                pivotColumns.Add(col);
                
                // Eliminate this column in other rows
                for (int row = 0; row < n; row++)
                {
                    if (row != rank && matrix[row][col] == 1)
                    {
                        // XOR row rank into row (GF(2) addition/subtraction)
                        for (int c = 0; c <= m; c++)
                        {
                            matrix[row][c] ^= matrix[rank][c];
                        }
                    }
                }
                
                rank++;
            }
            
            // Check if system is solvable
            for (int row = rank; row < n; row++)
            {
                if (matrix[row][m] == 1) // Non-zero in augmented column
                {
                    return -1; // No solution
                }
            }
            
            // Find free variables (columns without pivots)
            List<int> freeVars = new List<int>();
            HashSet<int> pivotSet = new HashSet<int>(pivotColumns);
            for (int col = 0; col < m; col++)
            {
                if (!pivotSet.Contains(col))
                {
                    freeVars.Add(col);
                }
            }
            
            // Try all combinations of free variables to find minimum weight solution
            int minWeight = int.MaxValue;
            int combinations = 1 << freeVars.Count;
            for (int combo = 0; combo < combinations; combo++)
            {
                int[] solution = new int[m];
                
                // Set free variables based on current combination
                for (int i = 0; i < freeVars.Count; i++)
                {
                    solution[freeVars[i]] = (combo & (1 << i)) != 0 ? 1 : 0;
                }
                
                // Back substitute to find pivot variable values
                for (int i = pivotColumns.Count - 1; i >= 0; i--)
                {
                    int pivotCol = pivotColumns[i];
                    int value = matrix[i][m]; // Augmented column value
                    
                    // Subtract contributions from all dependent variables (GF(2) subtraction = XOR)
                    for (int j = pivotCol + 1; j < m; j++)
                    {
                        if (matrix[i][j] == 1 && solution[j] == 1)
                        {
                            value ^= 1; // Toggle
                        }
                    }
                    
                    solution[pivotCol] = value;
                }
                
                // Count weight
                int weight = 0;
                foreach (int pressed in solution)
                {
                    if (pressed == 1) weight++;
                }
                
                minWeight = Math.Min(minWeight, weight);
            }
            return minWeight;
        }
        
        /// <summary>
        /// Hybrid approach: Use Gaussian elimination to find free variables,
        /// then only brute force the free variables and back-substitute for pivot variables.
        /// </summary>
        private static int FindMinimumButtonPressesInteger(List<int[]> buttons, int[] target)
        {
            int n = target.Length;
            int m = buttons.Count;
            
            if (m == 0)
            {
                return target.All(t => t == 0) ? 0 : -1;
            }
            
            // Create augmented matrix: [buttons | target]
            // Each row represents a position, each column represents a button
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[m + 1];
                for (int j = 0; j < m; j++)
                {
                    matrix[i][j] = buttons[j][i];
                }
                matrix[i][m] = target[i]; // Augmented column
            }
            
            // Gaussian elimination to row echelon form
            int rank = 0;
            List<int> pivotColumns = new List<int>();
            int[] pivotRows = new int[m]; // Maps column to its pivot row (-1 if free)
            for (int j = 0; j < m; j++) pivotRows[j] = -1;
            
            for (int col = 0; col < m && rank < n; col++)
            {
                // Find a row with non-zero value in this column
                int pivotRow = -1;
                for (int row = rank; row < n; row++)
                {
                    if (matrix[row][col] != 0)
                    {
                        pivotRow = row;
                        break;
                    }
                }
                
                if (pivotRow == -1) continue; // No pivot in this column, it's a free variable
                
                // Swap rows
                if (pivotRow != rank)
                {
                    var temp = matrix[rank];
                    matrix[rank] = matrix[pivotRow];
                    matrix[pivotRow] = temp;
                }
                
                pivotColumns.Add(col);
                pivotRows[col] = rank;
                
                // Eliminate this column in all other rows (both above and below)
                for (int row = 0; row < n; row++)
                {
                    if (row != rank && matrix[row][col] != 0)
                    {
                        // Subtract: row = row - (matrix[row][col] / matrix[rank][col]) * pivotRow
                        // For integer systems, we need the multiplier
                        int pivotValue = matrix[rank][col];
                        int rowValue = matrix[row][col];
                        
                        // Scale rows to allow integer elimination
                        // row = row * pivotValue - rowValue * pivotRow
                        for (int c = 0; c <= m; c++)
                        {
                            matrix[row][c] = matrix[row][c] * pivotValue - rowValue * matrix[rank][c];
                        }
                    }
                }
                
                rank++;
            }
            
            // Check if system has no solution (non-zero row with zero coefficients)
            for (int row = rank; row < n; row++)
            {
                if (matrix[row][m] != 0)
                {
                    return -1; // No solution
                }
            }
            
            // Find free variables (columns without pivots)
            List<int> freeVars = new List<int>();
            HashSet<int> pivotSet = new HashSet<int>(pivotColumns);
            for (int col = 0; col < m; col++)
            {
                if (!pivotSet.Contains(col))
                {
                    freeVars.Add(col);
                }
            }
            
            // Upper bound for free variable values
            int maxPresses = target.Max();
            
            int minWeight = int.MaxValue;
            
            // Brute force only the free variables
            int numFreeVars = freeVars.Count;
            long combinations = (long)Math.Pow(maxPresses + 1, numFreeVars);
            
            for (long combo = 0; combo < combinations; combo++)
            {
                int[] solution = new int[m];
                long temp = combo;
                int freeVarsWeight = 0;
                
                // Set free variables based on current combination
                for (int i = 0; i < numFreeVars; i++)
                {
                    int val = (int)(temp % (maxPresses + 1));
                    solution[freeVars[i]] = val;
                    freeVarsWeight += val;
                    temp /= (maxPresses + 1);
                }
                
                // Early pruning on free variables weight
                if (freeVarsWeight >= minWeight)
                {
                    continue;
                }
                
                // Back substitute to find pivot variable values
                bool valid = true;
                for (int i = pivotColumns.Count - 1; i >= 0; i--)
                {
                    int pivotCol = pivotColumns[i];
                    int pivotRowIdx = i; // After elimination, pivot i is in row i
                    
                    int pivotValue = matrix[pivotRowIdx][pivotCol];
                    if (pivotValue == 0)
                    {
                        valid = false;
                        break;
                    }
                    
                    // Calculate RHS value
                    int rhs = matrix[pivotRowIdx][m];
                    
                    // Subtract contributions from variables to the right (already computed)
                    for (int j = pivotCol + 1; j < m; j++)
                    {
                        rhs -= matrix[pivotRowIdx][j] * solution[j];
                    }
                    
                    // Check if we get an integer solution
                    if (rhs % pivotValue != 0)
                    {
                        valid = false;
                        break;
                    }
                    
                    int pivotSolution = rhs / pivotValue;
                    if (pivotSolution < 0)
                    {
                        valid = false;
                        break;
                    }
                    
                    solution[pivotCol] = pivotSolution;
                }
                
                if (valid)
                {
                    // Validate the complete solution against original system
                    if (ValidateSolution(buttons, target, solution))
                    {
                        int weight = solution.Sum();
                        minWeight = Math.Min(minWeight, weight);
                    }
                }
            }
            
            return minWeight == int.MaxValue ? -1 : minWeight;
        }
        
        /// <summary>
        /// Validates that a solution satisfies AX = B
        /// </summary>
        private static bool ValidateSolution(List<int[]> buttons, int[] target, int[] solution)
        {
            int n = target.Length;
            int m = buttons.Count;
            
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += buttons[j][i] * solution[j];
                }
                if (sum != target[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
