using Questions.General;
using Questions.LeetCode.Arrays;
using Questions.LeetCode.Strings;
using System;

namespace Questions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrays.
            RemoveDuplicatesFromSortedArray.Test();
            BestTimeToBuyAndSellStock.Test();
            RotateArray.Test();
            ContainsDuplicate.Test();
            SingleNumber.Test();
            IntersectionOfTwoArrays.Test();
            PlusOne.Test();
            MoveZeroes.Test();
            TwoSum.Test();
            TopKFrequentElements.Test();
            ValidSudoku.Test();

            // Strings.
            ReverseString.Test();
            ReverseInteger.Test();
            FirstUniqueCharacterInString.Test();
            ValidAnagram.Test();
            ValidPalindrome.Test();

            // General
            DocumentManagementSystem.Test();

            Console.ReadKey();
        }
    }
}
