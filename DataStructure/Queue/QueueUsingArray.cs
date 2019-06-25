using CS.DataStructure.ArrayList;

namespace CS.DataStructure.Queue
{
    public class QueueUsingArray
    {
        private readonly ArrayListForQueue<int?> _list;

        public QueueUsingArray()
        {
            _list = new ArrayListForQueue<int?>();
        }

        public void EnQueue(int data)
        {
            _list.Add(data);
        }

        public int? DeQueue()
        {
            return _list.Remove();
        }

        public int? Peek()
        {
            if (IsEmpty())
            {
                return null;
            }

            return _list[_list.StartIndex];
        }

        public bool IsEmpty()
        {
            return _list.Count == 0;
        }
    }
}
