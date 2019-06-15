using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.General
{
    public class DocumentManagementSystem
    {
        public static void Run()
        {
            var lines = new List<string>
            {
                "H1 US",
                "H2 UK",
                "H3 UD",
                "H3 UE",
                "H2 UF",
                "H3 UZ",
                "H3 UX",
                "H1 UQ",
            };

            var result = Solve(lines);
            Console.WriteLine("Result for DocumentManagementSystem: " + result);
        }

        public static string Solve(List<string> lines)
        {
            var tree = new Tree(lines);
            return tree.Print();
        }
    }

    public class Tree
    {
        public List<TreeNode> Roots { get; set; }

        public Tree(List<string> lines)
        {
            Roots = BuildTree(lines);
        }

        public string Print()
        {
            var result = PrintHelper(Roots);
            return result;
        }

        public string PrintHelper(List<TreeNode> roots)
        {
            var result = "<ul>";
            foreach (var root in roots)
            {
                result += $"<li>{root.Text} \n";
                if (root.Nodes.Any())
                {
                    result += PrintHelper(root.Nodes);
                }

                result += "</li>";
            }

            result += "</ul>";

            return result;
        }

        private List<TreeNode> BuildTree(List<string> lines)
        {
            var root = new TreeNode(-1);
            var temp = root;
            foreach (var line in lines)
            {
                var values = line.Split(" ");
                var newNode = new TreeNode(int.Parse($"{values[0][1]}"), values[1]);
                if (newNode.Number > temp.Number)
                {
                    newNode.SetParent(temp);
                }
                else
                {
                    var tempNode = temp;
                    while (tempNode.Parent != null && newNode.Number <= tempNode.Number)
                    {
                        tempNode = tempNode.Parent;
                    }
                    newNode.SetParent(tempNode);
                }

                temp = newNode;
            }

            return root.Nodes;
        }
    }

    public class TreeNode
    {
        public string Text { get; }
        public TreeNode Parent { get; set; }
        public List<TreeNode> Nodes { get; set; }
        public int Number { get; set; }

        public TreeNode(int number, string text = null)
        {
            Text = text;
            Number = number;
            Nodes = new List<TreeNode>();
        }

        public void SetParent(TreeNode parent)
        {
            Parent = parent;
            parent.AddChild(this);
        }

        public void AddChild(TreeNode node)
        {
            Nodes.Add(node);
        }
    }
}
