namespace CS.DataStructure.LinkedList
{
    public class SingleLinkedListForQueue : SingleLinkedList
    {
        public SingleLinkedListNode Tail { get; set; }

        public SingleLinkedListForQueue(SingleLinkedListNode head = null, SingleLinkedListNode tail = null)
            : base(head)
        {
            Tail = tail;
        }

        public void AddAtTail(int data)
        {
            var temp = new SingleLinkedListNode(data);
            if (Head == null)
            {
                Head = Tail = temp;
                return;
            }

            Tail.Next = temp;
            Tail = Tail.Next;
        }

        public override int? RemoveFromHead()
        {
            if (Head == null)
            {
                return null;
            }

            var data = Head.Data;
            Head = Head.Next;

            if (Head == null)
            {
                Head = Tail = null;
            }
            return data;
        }
    }
}