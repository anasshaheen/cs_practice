using System.Collections.Generic;

namespace CS.Problems.Graph
{
    public class NameFrequency
    {
        public Dictionary<string, int> FindMostPopular(Dictionary<string, int> names, string[][] synonyms)
        {
            var nameGroups = ConstructGroups(names);

            MergeClasses(nameGroups, synonyms);

            return ConvertToMap(nameGroups);
        }

        #region Helpers

        private Dictionary<string, NameSet> ConstructGroups(Dictionary<string, int> names)
        {
            var nameGroups = new Dictionary<string, NameSet>();
            foreach (var pair in names)
            {
                var name = pair.Key;
                var frequency = pair.Value;
                var group = new NameSet(name, frequency);
                nameGroups.Add(name, group);
            }

            return nameGroups;
        }

        private void MergeClasses(Dictionary<string, NameSet> groups, string[][] synonyms)
        {
            foreach (var entry in synonyms)
            {
                var name1 = entry[0];
                var name2 = entry[1];

                var set1 = groups[name1];
                var set2 = groups[name2];

                if (set1 != set2)
                {
                    var smaller = set2.Names.Count < set1.Names.Count ? set2 : set1;
                    var bigger = set2.Names.Count > set1.Names.Count ? set1 : set2;

                    var smallerSetNames = smaller.Names;
                    var smallerFrequency = smaller.Frequency;

                    bigger.CopyNamesWithFrequency(smallerSetNames, smallerFrequency);

                    foreach (var name in smallerSetNames)
                    {
                        if (groups.ContainsKey(name))
                        {
                            groups[name] = bigger;
                        }
                        else
                        {
                            groups.Add(name, bigger);
                        }
                    }
                }
            }
        }

        private Dictionary<string, int> ConvertToMap(Dictionary<string, NameSet> groups)
        {
            var newGroups = new Dictionary<string, int>();
            foreach (var group in groups.Values)
            {
                if (!newGroups.ContainsKey(group.RootName))
                {
                    newGroups.Add(group.RootName, group.Frequency);
                }
            }

            return newGroups;
        }

        #endregion

        public class NameSet
        {
            public NameSet(string name, int freq)
            {
                Names = new HashSet<string>
                {
                    name
                };
                Frequency = freq;
                RootName = name;
            }

            public HashSet<string> Names { get; }
            public int Frequency { get; private set; }
            public string RootName { get; }

            public void CopyNamesWithFrequency(HashSet<string> names, int frequency)
            {
                foreach (var name in names)
                {
                    Names.Add(name);
                }

                Frequency += frequency;
            }
        }
    }
}