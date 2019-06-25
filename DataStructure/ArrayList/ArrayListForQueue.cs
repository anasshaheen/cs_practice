using System;

namespace CS.DataStructure.ArrayList
{
    public class ArrayListForQueue<T> : ArrayList<T>
    {
        private int _tail;
        private int _head;

        public ArrayListForQueue()
        {
            _tail = 0;
            _head = 0;
        }

        public override void Add(T data)
        {
            var shouldResize = Array.Length - 1 == count;
            if (shouldResize)
            {
                Resize();
            }

            if (!shouldResize && _tail == Array.Length)
            {
                _tail = 0;
            }

            Array[_tail] = data;
            ++_tail;
            ++count;
        }

        public override T Remove()
        {
            if (_tail == _head)
            {
                throw new NullReferenceException();
            }

            var data = Array[_head];
            Array[_head] = default(T);
            ++_head;
            --count;

            if (_head == Array.Length)
            {
                _head = 0;
            }

            return data;
        }

        #region Helpers

        private void Resize()
        {
            var tempArr = new T[Array.Length * Factor];
            var index = 0;
            if (_tail > _head)
            {
                CopyIfHeadFirst(tempArr, ref index);
            }
            else
            {
                CopyIfTailFirst(tempArr, ref index);
            }

            Array = tempArr;
            _tail = index;
            _head = 0;
        }

        private void CopyIfHeadFirst(T[] tempArr, ref int index)
        {
            for (var i = _head; i <= _tail; ++i)
            {
                if (Array[i] != null)
                {
                    tempArr[index] = Array[i];
                    ++index;
                }
            }
        }

        private void CopyIfTailFirst(T[] tempArr, ref int index)
        {
            for (var i = _head; i < Array.Length; ++i)
            {
                if (Array[i] != null)
                {
                    tempArr[index] = Array[i];
                    ++index;
                }
            }

            for (var i = 0; i < _head; ++i)
            {
                if (Array[i] != null)
                {
                    tempArr[index] = Array[i];
                    ++index;
                }
            }
        }

        #endregion

        public int StartIndex => _head;
    }
}
