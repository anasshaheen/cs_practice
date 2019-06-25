namespace CS.DataStructure.LinkedList
{
    public class SingleLinkedListNode
    {
        public int Data { get; set; }
        public SingleLinkedListNode Next { get; set; }

        public SingleLinkedListNode(int data, SingleLinkedListNode next = null)
        {
            Data = data;
            Next = next;
        }
    }
}