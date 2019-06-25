using CS.DataStructure.LinkedList;

namespace CS.Problems.Leetcode.LinkedLists
{
    public class MergeTwoSortedLists
    {
        public static SingleLinkedListNode Solve(SingleLinkedListNode l1, SingleLinkedListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            var newHead = new SingleLinkedListNode(0);
            SingleLinkedListNode p1 = l1, p2 = l2, pResult = newHead;
            while (p1 != null || p2 != null)
            {
                if (p1 == null)
                {
                    pResult.Next = new SingleLinkedListNode(p2.Data);
                    p2 = p2.Next;
                    goto END;
                }

                if (p2 == null)
                {
                    pResult.Next = new SingleLinkedListNode(p1.Data);
                    p1 = p1.Next;
                    goto END;
                }

                if (p1.Data == p2.Data)
                {
                    var newNode = new SingleLinkedListNode(p1.Data);
                    newNode.Next = new SingleLinkedListNode(p2.Data);
                    pResult.Next = newNode;
                    p1 = p1.Next;
                    p2 = p2.Next;
                    pResult = pResult.Next;
                }
                else if (p1.Data > p2.Data)
                {
                    pResult.Next = new SingleLinkedListNode(p2.Data);
                    p2 = p2.Next;
                }
                else
                {
                    pResult.Next = new SingleLinkedListNode(p1.Data);
                    p1 = p1.Next;
                }

            END: pResult = pResult.Next;
            }

            return newHead.Next;
        }
    }
}
