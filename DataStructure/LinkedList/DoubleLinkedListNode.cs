namespace CS.DataStructure.LinkedList
{
    public class DoubleLinkedListNode
    {
        public int Data { get; set; }
        public DoubleLinkedListNode Next { get; set; }
        public DoubleLinkedListNode Prev { get; set; }

        public DoubleLinkedListNode(int data, DoubleLinkedListNode next = null, DoubleLinkedListNode prev = null)
        {
            Data = data;
            Next = next;
            Prev = prev;
        }
    }
}