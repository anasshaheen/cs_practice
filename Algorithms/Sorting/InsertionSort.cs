using CS.DataStructure.LinkedList;

namespace CS.Algorithms.Sorting
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            if (array.Length == 0)
            {
                return;
            }

            for (var i = 1; i < array.Length; ++i)
            {
                var item = array[i];

                var j = i - 1;
                while (j >= 0 && array[j] > item)
                {
                    array[j + 1] = array[j];
                    --j;
                }

                array[j + 1] = item;
            }
        }


        public static SingleLinkedListNode Sort(SingleLinkedListNode head)
        {
            SingleLinkedListNode sortedList = null;

            var currentNode = head;
            while (currentNode != null)
            {
                var nextNode = currentNode.Next;
                SortedInsert(currentNode, ref sortedList);
                currentNode = nextNode;
            }

            return sortedList;
        }

        #region Helpers

        private static void SortedInsert(SingleLinkedListNode node, ref SingleLinkedListNode sortedList)
        {
            if (sortedList == null || sortedList.Data >= node.Data)
            {
                node.Next = sortedList;
                sortedList = node;
            }
            else
            {
                var currentNode = sortedList;

                while (currentNode.Next != null &&
                       currentNode.Next.Data < node.Data)
                {
                    currentNode = currentNode.Next;
                }

                node.Next = currentNode.Next;
                currentNode.Next = node;
            }
        }

        #endregion
    }
}