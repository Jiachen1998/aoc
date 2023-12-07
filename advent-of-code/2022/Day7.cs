namespace aoc._2022
{
    internal class Day7
    {
        public static void Day7Part1()
        {
            var lines = Utilities.ReadInput(7);
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

        // Tree to handle directory generation in day 7
        public class TreeNode
        {
            public string Name { get; init; }
            public Directory? Parent { get; set; }

            public class Directory : TreeNode
            {
                public List<TreeNode> Children { get; set; }
                public int Size { get; set; } = 0;

                public Directory(string name)
                {
                    Name = name;
                    Children = new List<TreeNode>();
                }

                public void AddChild(TreeNode node)
                {
                    Children.Add(node);
                    node.Parent = this;
                }

                public Directory? SearchChildren(Directory root, string name)
                {
                    if (root.Name == name)
                    {
                        return root;
                    }

                    foreach (TreeNode child in root.Children)
                    {
                        var dir = child as Directory;
                        if (dir != null && dir.Name == name)
                        {
                            return dir;
                        }
                    }
                    // If we reach here, the node with the given name was not found in any of the subtrees.
                    return null;
                }

                public Directory? SearchTree(Directory root, string name)
                {
                    if (root.Name == name)
                    {
                        return root;
                    }

                    // Recursively search all of the root's subtrees.
                    foreach (TreeNode child in root.Children)
                    {
                        var dir = child as Directory;
                        if (dir != null)
                        {
                            Directory? result = SearchTree(dir, name);
                            if (result != null)
                            {
                                return result;
                            }
                        }
                    }
                    return null;
                }

                public int GetDirectorySize(Directory root)
                {
                    int sum = root.Size;
                    foreach (TreeNode child in root.Children)
                    {
                        var checkDir = child as Directory;
                        var checkFile = child as File;
                        if (checkDir != null)
                        {
                            sum += GetDirectorySize(checkDir);
                        }
                        else if (checkFile != null)
                        {
                            sum += checkFile.Size;
                        }
                    }
                    return sum;
                }

                public void TraverseTree(Directory root)
                {
                    if (root == null) return;

                    foreach (TreeNode child in root.Children)
                    {

                    }
                }
            }

            public class File : TreeNode
            {
                public int Size { get; init; }

                public File(int size, string name)
                {
                    Name = name;
                    Size = size;
                }
            }
        }
    }
}
