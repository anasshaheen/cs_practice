using System;

namespace CS.Problems.Leetcode.Design
{
    public class ShuffleAnArray
    {
        private readonly int[] _numbers;
        private readonly Random _random;

        public ShuffleAnArray(int[] numbers)
        {
            _numbers = numbers;
            _random = new Random();
        }

        public int[] Reset()
        {
            var copiedArr = new int[_numbers.Length];
            _numbers.CopyTo(copiedArr, 0);

            return copiedArr;
        }

        public int[] Shuffle()
        {
            var copiedArr = new int[_numbers.Length];
            _numbers.CopyTo(copiedArr, 0);

            for (var i = 0; i < copiedArr.Length; i++)
            {
                var randomIndex = _random.Next(i + 1);

                var temp = copiedArr[randomIndex];
                copiedArr[randomIndex] = copiedArr[i];
                copiedArr[i] = temp;
            }

            return copiedArr;
        }
    }
}
