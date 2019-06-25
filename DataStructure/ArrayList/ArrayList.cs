using System;

namespace CS.DataStructure.ArrayList
{
    public class ArrayList<T>
    {
        protected readonly int Factor;
        protected T[] Array;
        protected int count;

        public ArrayList()
        {
            Factor = 2;
            count = 0;
            Array = new T[Factor];
        }

        public T this[int index]
        {
            get
            {
                if (index > Array.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return Array[index];
            }
            set
            {
                if (index > Array.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Array[index] = value;
            }
        }

        public virtual void Add(T data)
        {
            if (count == Array.Length - 1)
            {
                Resize();
            }

            Array[count] = data;
            ++count;
        }

        public virtual T Remove()
        {
            if (count == 0)
            {
                throw new NullReferenceException();
            }

            --count;
            var data = Array[count];
            Array[count] = default(T);

            return data;
        }

        #region Helpers

        private void Resize()
        {
            var tempArr = new T[Array.Length * Factor];
            for (var i = 0; i < Array.Length; ++i)
            {
                tempArr[i] = Array[i];
            }

            Array = tempArr;
        }

        #endregion

        public int Count => count;
    }
}
