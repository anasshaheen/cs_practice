using CS.DataStructure.LinkedList;

namespace CS.Problems.Leetcode.LinkedLists
{
    public class DeleteNodeInLinkedList
    {
        public static void Solve(SingleLinkedListNode node)
        {
            if (node == null)
            {
                return;
            }

            node.Data = node.Next.Data;
            node.Next = node.Next.Next;
        }
    }
}
