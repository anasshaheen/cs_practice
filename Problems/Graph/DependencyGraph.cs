using System.Collections.Generic;
using System.Linq;

namespace CS.Problems.Graph
{
    public class DependencyGraph
    {
        private readonly List<string> _projects;
        private readonly Dictionary<string, LinkedList<string>> _adj;
        private readonly Dictionary<string, int> _inDegree;

        public DependencyGraph()
        {
            _projects = new List<string>();
            _adj = new Dictionary<string, LinkedList<string>>();
            _inDegree = new Dictionary<string, int>();
        }

        public void BuildDependencyGraph(string[] projects, string[][] dependencies)
        {
            if (dependencies.Length == 0)
            {
                return;
            }

            foreach (var project in projects)
            {
                _adj.Add(project, new LinkedList<string>());
                _projects.Add(project);
                _inDegree.TryAdd(project, 0);
            }

            foreach (var dependency in dependencies)
            {
                var inDependentProject = dependency[0];
                var dependentProject = dependency[1];

                _adj[inDependentProject].AddFirst(dependentProject);
            }
        }

        public List<string> FindBuildOrder()
        {
            foreach (var project in _projects)
            {
                foreach (var node in _adj[project])
                {
                    _inDegree[node]++;
                }
            }

            var queue = new Queue<string>();
            foreach (var project in _projects)
            {
                if (_inDegree[project] == 0)
                {
                    queue.Enqueue(project);
                }
            }

            var result = new List<string>();
            while (queue.Any())
            {
                var project = queue.Dequeue();
                result.Add(project);

                foreach (var node in _adj[project])
                {
                    --_inDegree[node];
                    if (_inDegree[node] == 0)
                    {
                        queue.Enqueue(node);
                    }
                }
            }

            return result;
        }
    }
}
