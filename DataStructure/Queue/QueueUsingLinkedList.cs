using CS.DataStructure.LinkedList;

namespace CS.DataStructure.Queue
{
    public class QueueUsingLinkedList
    {
        private readonly SingleLinkedListForQueue _list;

        public QueueUsingLinkedList()
        {
            _list = new SingleLinkedListForQueue();
        }

        public void EnQueue(int data)
        {
            _list.AddAtTail(data);
        }

        public int? DeQueue()
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

