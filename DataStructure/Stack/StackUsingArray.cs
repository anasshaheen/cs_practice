using CS.DataStructure.ArrayList;

namespace CS.DataStructure.Stack
{
    public class StackUsingArray
    {
        private readonly ArrayList<int?> _list;

        public StackUsingArray()
        {
            _list = new ArrayList<int?>();
        }

        public void Push(int data)
        {
            _list.Add(data);
        }

        public int? Pop()
        {
            return _list.Remove();
        }

        public int? Peek()
        {
            if (_list.Count == 0)
            {
                return null;
            }

            return _list[_list.Count - 1];
        }

        public bool IsEmpty()
        {
            return _list.Count == 0;
        }
    }
}
