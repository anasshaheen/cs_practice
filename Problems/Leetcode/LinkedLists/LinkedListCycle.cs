using CS.DataStructure.LinkedList;

namespace CS.Problems.Leetcode.LinkedLists
{
    public class LinkedListCycle
    {
        public static bool Solve(SingleLinkedListNode head)
        {
            if (head == null)
            {
                return false;
            }

            var slow = head.Next;
            var fast = head.Next?.Next;
            while (fast?.Next != null && slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return fast?.Next != null;
        }
    }
}
