using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.DataStructure.Graph
{
    public class Graph
    {
        private readonly int _vertices;
        private readonly LinkedList<int>[] _adj;
        private readonly bool[][] _adjMatrix;

        public Graph(int vertices)
        {
            _vertices = vertices;
            _adj = new LinkedList<int>[vertices];
            _adjMatrix = new bool[vertices][];
            for (var i = 0; i < vertices; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            _adj[v].AddFirst(w);
        }

        public void Dfs(int startingVertex)
        {
            var visited = new bool[_vertices];
            Dfs(startingVertex, visited);
        }

        public void Bfs(int startingVertex)
        {
            var visited = new bool[_vertices];
            Bfs(startingVertex, visited);
        }

        public void Traverse(int startingVertex)
        {
            var visited = new bool[_vertices];
            Traverse(startingVertex, visited);
        }

        public void TopologicalSort()
        {
            var visited = new bool[_vertices];
            var stack = new Stack<int>();

            for (int i = 0; i < _vertices; i++)
            {
                if (!visited[i])
                {
                    TopologicalSort(i, visited, stack);
                }
            }

            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }
        }

        public bool IsMotherVertex(int vertex)
        {
            var visited = new bool[_vertices];
            Bfs(vertex, visited, false);

            return visited.All(e => e);
        }

        public bool ContainsMotherVertex()
        {
            var visited = new bool[_vertices];
            var lastVertex = 0;

            for (var i = 0; i < _vertices; i++)
            {
                if (!visited[i])
                {
                    Bfs(i, visited, false);
                    lastVertex = i;
                }
            }

            Array.Fill(visited, false);
            Dfs(lastVertex, visited, false);

            return visited.All(e => e);
        }

        public bool DoesPathExists(int startVertex, int endVertex)
        {
            var visited = new bool[_vertices];

            var queue = new Queue<int>();
            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Any())
            {
                startVertex = queue.Dequeue();
                foreach (var node in _adj[startVertex])
                {
                    if (!visited[node])
                    {
                        if (node == endVertex)
                        {
                            return true;
                        }
                        visited[node] = true;
                        queue.Enqueue(node);
                    }
                }
            }

            return false;
        }

        #region Helpers

        private void TopologicalSort(int vertex, bool[] visited, Stack<int> stack)
        {
            visited[vertex] = true;

            foreach (var node in _adj[vertex])
            {
                if (!visited[node])
                {
                    TopologicalSort(node, visited, stack);
                }
            }

            stack.Push(vertex);
        }

        private void Bfs(int v, bool[] visited, bool print = true)
        {
            var queue = new Queue<int>();
            visited[v] = true;
            queue.Enqueue(v);

            while (queue.Any())
            {
                v = queue.Dequeue();
                if (print)
                {
                    Console.WriteLine(v);
                }

                foreach (var node in _adj[v])
                {
                    if (!visited[node])
                    {
                        visited[node] = true;
                        queue.Enqueue(node);
                    }
                }
            }
        }

        private void Traverse(int v, bool[] visited, bool print = true)
        {
            if (print)
            {
                Console.WriteLine(v);
            }

            visited[v] = true;

            foreach (var node in _adj[v])
            {
                if (!visited[node])
                {
                    Traverse(node, visited);
                }
            }
        }

        private void Dfs(int v, bool[] visited, bool print = true)
        {
            var stack = new Stack<int>();
            visited[v] = true;
            stack.Push(v);

            while (stack.Any())
            {
                v = stack.Pop();
                if (print)
                {
                    Console.WriteLine(v);
                }

                foreach (var node in _adj[v])
                {
                    if (!visited[node])
                    {
                        visited[node] = true;
                        stack.Push(node);
                    }
                }
            }
        }

        public void BuildAdjMatrix()
        {
            for (var i = 0; i < _vertices; i++)
            {
                _adjMatrix[i] = new bool[_vertices];

                foreach (var node in _adj[i])
                {
                    _adjMatrix[i][node] = true;
                }
            }
        }

        public void PrintMatrix()
        {
            Console.Write("  | ");
            for (int i = 0; i < _vertices; i++)
            {
                Console.Write($" {i} ------ ");
            }

            for (int i = 0; i < _adjMatrix.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine("_________________________________________________________________________");

                Console.Write($"{i} | ");
                for (int j = 0; j < _adjMatrix[i].Length; j++)
                {
                    Console.Write($" {(_adjMatrix[i][j] ? 1 : 0)} ------ ");
                }
            }

            Console.WriteLine();
            Console.WriteLine("_________________________________________________________________________");
        }

        #endregion
    }
}
