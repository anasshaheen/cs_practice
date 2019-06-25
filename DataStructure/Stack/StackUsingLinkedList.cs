namespace CS.DataStructure.Stack
{
    public class StackUsingLinkedList
    {
        private readonly LinkedList.SingleLinkedList _list;

        public StackUsingLinkedList()
        {
            _list = new LinkedList.SingleLinkedList();
        }

        public void Push(int data)
        {
            _list.AddAtHead(data);
        }

        public int? Pop()
        {
            return _list.RemoveFromHead();
        }

        public int? Peek()
        {
            return _list.Head?.Data;
        }

        public bool IsEmpty()
        {
            return _list.Head == null;
        }
    }
}