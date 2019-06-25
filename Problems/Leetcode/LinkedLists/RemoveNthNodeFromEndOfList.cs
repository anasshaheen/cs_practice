using CS.DataStructure.LinkedList;

namespace CS.Problems.Leetcode.LinkedLists
{
    public class RemoveNthNodeFromEndOfList
    {
        public static SingleLinkedListNode Solve(SingleLinkedListNode head, int n)
        {
            if (head?.Next == null)
            {
                return head?.Next;
            }

            var length = 0;
            var temp = head;
            while (temp != null)
            {
                ++length;
                temp = temp.Next;
            }

            if (length - n == 0)
            {
                return head.Next;
            }

            temp = head;
            var count = 0;
            while (temp.Next != null)
            {
                if (count == length - n - 1)
                {
                    temp.Next = temp.Next.Next;
                    break;
                }

                temp = temp.Next;
                ++count;
            }

            return head;
        }
    }
}
