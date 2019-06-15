using System;
using System.Collections.Generic;

namespace Questions.LeetCode.Arrays
{
    public class TopKFrequentElements
    {
        public static void Run()
        {
            var numbers = new[] { 1 };
            var k = 1;
            var result = Solve(numbers, k);

            Console.WriteLine("Result from TopKFrequentElements: " + string.Join(",", result));

        }

        public static List<int> Solve(int[] numbers, int k)
        {
            var maxFreq = 0;
            var dict = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (dict.ContainsKey(number))
                {
                    ++dict[number];
                    maxFreq = Math.Max(dict[number], maxFreq);
                }
                else
                {
                    dict.Add(number, 1);
                }
            }

            var buckets = new List<int>[maxFreq + 1];
            for (var i = 0; i <= maxFreq; ++i)
            {
                buckets[i] = new List<int>();
            }

            foreach (var pair in dict)
            {
                buckets[pair.Value - 1].Add(pair.Key);
            }

            var counter = 0;
            var result = new List<int>();
            for (var i = maxFreq; i >= 0; --i)
            {
                if (buckets[i] != null)
                {
                    foreach (var node in buckets[i])
                    {
                        if (counter < k)
                        {
                            result.Add(node);
                            ++counter;
                        }
                        else
                        {
                            return result;
                        }
                    }
                }
            }

            return result;
        }
    }
}
