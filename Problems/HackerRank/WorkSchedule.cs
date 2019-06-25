using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.Problems.HackerRank
{
    public class WorkSchedule
    {
        public static List<string> Solve(int workHours, int dayHours, string pattern)
        {
            var tokens = pattern.ToCharArray()
                .Select(e => e + "")
                .ToArray();

            var finishedHours = 0;
            var fieldIndices = new List<int>();
            for (var i = 0; i < tokens.Length; i++)
            {
                var isDigit = int.TryParse(tokens[i], out var token);
                if (isDigit)
                {
                    finishedHours += token;
                }
                else
                {
                    fieldIndices.Add(i);
                }
            }

            var remainingHours = workHours - finishedHours;
            if (remainingHours / dayHours == fieldIndices.Count)
            {
                return new List<string>
                {
                    "8888888"
                };
            }

            var results = new List<string>();
            var permutations = Permutations(remainingHours, fieldIndices.Count, dayHours);
            foreach (var permutation in permutations)
            {
                var result = new string[tokens.Length];
                Array.Copy(tokens, 0, result, 0, tokens.Length);

                var i = 0;
                foreach (var fieldIndex in fieldIndices)
                {
                    result[fieldIndex] = permutation[i] + "";
                    ++i;
                }

                results.Add(string.Join("", result));
            }

            return results.OrderBy(e => e).ToList();
        }

        private static List<List<int>> Permutations(int target, int days, int dayHours)
        {
            var results = new List<List<int>>();
            var permutations = PermutationsHelper(GenerateSteps(dayHours), days);

            foreach (var permutation in permutations)
            {
                if (permutation.Sum() == target)
                {
                    results.Add(permutation.ToList());
                }
            }

            return results;
        }

        private static IEnumerable<int[]> PermutationsHelper(List<int> numbers, int size)
        {
            var result = new List<int[]>();

            for (var i = 0; i < Math.Pow(numbers.Count, size); i++)
            {
                var array = new int[size];
                for (var j = 0; j < size; j++)
                {
                    var index = (int)(i / Math.Pow(numbers.Count, j)) % numbers.Count;
                    array[j] = numbers[index];
                }

                result.Add(array);
            }

            return result;
        }

        private static List<int> GenerateSteps(int limit)
        {
            var numbers = new List<int>();
            for (var i = 0; i <= limit; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }
    }
}
