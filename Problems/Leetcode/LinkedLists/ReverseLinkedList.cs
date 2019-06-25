using CS.DataStructure.LinkedList;

namespace CS.Problems.Leetcode.LinkedLists
{
    public class ReverseLinkedList
    {
        public static SingleLinkedListNode Solve(SingleLinkedListNode head)
        {

            if (head?.Next == null)
            {
                return head;
            }

            var current = head;
            SingleLinkedListNode prev = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;

                current = next;
            }

            return prev;
        }
    }
}
