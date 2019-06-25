using CS.DataStructure.LinkedList;

namespace CS.Problems.Leetcode.LinkedLists
{
    public class PalindromeLinkedList
    {
        public static bool Solve(SingleLinkedListNode head)
        {
            if (head == null)
            {
                return true;
            }

            var count = 0;
            var p = head;
            while (p != null)
            {
                ++count;
                p = p.Next;
            }

            p = head;
            var arr = new int[count];
            var i = 0;
            while (p != null)
            {
                arr[i++] = p.Data;
                p = p.Next;
            }

            int l = 0, r = arr.Length - 1;
            while (l < r)
            {
                if (arr[l++] != arr[r--])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
