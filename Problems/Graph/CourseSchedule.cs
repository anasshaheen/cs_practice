using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.Problems.Graph
{
    public class CourseSchedule
    {
        public static void Run()
        {
            var prerequisites = new[]
            {
                new[] {1, 0},
                new[] {0, 1},
            };
            var numOfCourses = 2;

            IsCycle(numOfCourses, prerequisites);
            FindOrder(numOfCourses, prerequisites);
        }

        // Course Schedule I
        static bool IsCycle(int numCourses, int[][] prerequisites)
        {
            int[] result;
            if (prerequisites.Length == 0)
            {
                result = new int[numCourses];
                for (var vertex = 0; vertex < numCourses; vertex++)
                {
                    result[vertex] = vertex;
                }
            }

            var adj = new Dictionary<int, LinkedList<int>>();
            for (var vertex = 0; vertex < numCourses; vertex++)
            {
                adj.Add(vertex, new LinkedList<int>());
            }

            foreach (var prerequisite in prerequisites)
            {
                var dependentPrerequisite = prerequisite[0];
                var inDependentPrerequisite = prerequisite[1];

                adj[inDependentPrerequisite].AddFirst(dependentPrerequisite);
            }

            var inDegree = new int[numCourses];
            for (var u = 0; u < numCourses; u++)
            {
                foreach (var node in adj[u])
                {
                    inDegree[node]++;
                }
            }

            var q = new Queue<int>();
            for (var vertex = 0; vertex < numCourses; vertex++)
            {
                if (inDegree[vertex] == 0)
                {
                    q.Enqueue(vertex);
                }
            }

            var counter = 0;
            result = new int[numCourses];
            while (q.Any())
            {
                var vertex = q.Dequeue();
                result[counter] = vertex;

                foreach (var node in adj[vertex])
                {
                    --inDegree[node];
                    if (inDegree[node] == 0)
                    {
                        q.Enqueue(node);
                    }
                }

                counter++;
            }

            if (counter != numCourses)
                return true;
            else
                return false;
        }

        // Course Schedule II
        static void FindOrder(int numCourses, int[][] prerequisites)
        {
            int[] result;
            if (prerequisites.Length == 0)
            {
                result = new int[numCourses];
                for (var i = 0; i < numCourses; i++)
                {
                    result[i] = i;
                }
            }

            var adjTable = new Dictionary<int, LinkedList<int>>();
            for (var i = 0; i < numCourses; i++)
            {
                adjTable.Add(i, new LinkedList<int>());
            }

            foreach (var prerequisite in prerequisites)
            {
                var dependentPrerequisite = prerequisite[0];
                var inDependentPrerequisite = prerequisite[1];

                adjTable[inDependentPrerequisite].AddFirst(dependentPrerequisite);
            }

            var visited = new bool[numCourses];
            var stack = new Stack<int>();

            for (int i = 0; i < numCourses; i++)
            {
                if (!visited[i])
                {
                    FindOrder(i, visited, adjTable, stack);
                }
            }

            result = new int[numCourses];
            var j = 0;
            foreach (var node in stack)
            {
                result[j++] = node;
            }

            Console.WriteLine(string.Join("-", result));
        }

        static void FindOrder(int vertex, bool[] visited, Dictionary<int, LinkedList<int>> adj, Stack<int> stack)
        {
            visited[vertex] = true;

            foreach (var node in adj[vertex])
            {
                if (!visited[node])
                {
                    FindOrder(node, visited, adj, stack);
                }
            }

            stack.Push(vertex);
        }
    }
}
