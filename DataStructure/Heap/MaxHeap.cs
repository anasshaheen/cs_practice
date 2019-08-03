using System;

namespace CS.DataStructure.Heap
{
    public class MaxHeap
    {
        private readonly int _maxSize;
        private readonly int[] _heap;
        private int _size;

        public MaxHeap(int maxSize = 8)
        {
            _maxSize = maxSize;
            _size = 0;
            _heap = new int[maxSize];
        }
        
        public MaxHeap(int[] array, int? maxSize = null)
        {
            _maxSize = maxSize ?? array.Length;
            _size = 0;
            _heap = new int[array.Length];
            Array.Copy(array, _heap, array.Length);

            BuildHeap(_heap);
        }

        public void Insert(int item)
        {
            if (IsFull())
            {
                throw new ArgumentException("Heap is full!");
            }

            _heap[_size] = item;
            ++_size;

            SiftUp(_size - 1);
        }

        public int GetMax()
        {
            return _heap[0];
        }

        public int GetSize()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public bool IsFull()
        {
            return _size == _maxSize;
        }

        public int Remove(int index)
        {
            _heap[index] = int.MaxValue;
            SiftUp(index);

            return ExtractMax();
        }

        public int ExtractMax()
        {
            var item = _heap[0];
            Swap(0, _size - 1);
            --_size;
            _heap[_size] = 0;

            SiftDown(0);

            return item;
        }

        public int[] HeapSort(bool overrideHeap = false, int[] array = null)
        {
            if (array != null)
            {
                BuildHeap(array);
                Sort(array);

                return array;
            }

            if (overrideHeap)
            {
                Sort(_heap);
                return _heap;
            }

            var heapCopy = new int[_size];
            Array.Copy(_heap, heapCopy, _size);
            Sort(heapCopy);

            return heapCopy;
        }
        
        #region Helpers

        private void Heapify(int[] array, int size, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var largestIndex = index;
            var leftChildIndex = GetLeftChildIndex(index);
            if (leftChildIndex < size && array[leftChildIndex] > array[largestIndex])
            {
                largestIndex = leftChildIndex;
            }
            
            var rightChildIndex = GetRightChildIndex(index);
            if (rightChildIndex < size && array[rightChildIndex] > array[largestIndex])
            {
                largestIndex = rightChildIndex;
            }

            if (largestIndex != index)
            {
                Swap(index, largestIndex, array);
                Heapify(array, size, largestIndex);
            }
        }
        
        private void Sort(int[] array)
        {
            for (var i = _size - 1; i >= 0; --i)
            {
                Swap(0, i);
                Heapify(array, i, 0);
            }
        }
        
        private void BuildHeap(int[] array)
        {
            for (var i = array.Length / 2 - 1; i >= 0; --i)
            {
                Heapify(array, array.Length, i);
            }
        }
        
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < _size;
        }

        private bool HasLeftChild(int index)
        {
            return IsValidIndex(GetLeftChildIndex(index));
        }

        private bool HasRightChild(int index)
        {
            return IsValidIndex(GetLeftChildIndex(index));
        }

        private int GetLeftChild(int index)
        {
            return _heap[GetLeftChildIndex(index)];
        }

        private int GetRightChild(int index)
        {
            return _heap[GetRightChildIndex(index)];
        }

        private int GetParent(int index)
        {
            return _heap[GetParentIndex(index)];
        }

        private void Swap(int fIndex, int sIndex, int[] array = null)
        {
            if (array == null)
            {
                var temp = _heap[fIndex];
                _heap[fIndex] = _heap[sIndex];
                _heap[sIndex] = temp;
            }
            else
            {
                var temp = array[fIndex];
                array[fIndex] = array[sIndex];
                array[sIndex] = temp;
            }
        }

        private void SiftUp(int index)
        {
            if (IsValidIndex(index) && _heap[index] > GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                
                SiftUp(parentIndex);
            }
        }

        private void SiftDown(int index)
        {
            if (HasLeftChild(index))
            {
                var largestIndex = index;
                var leftChildIndex = GetLeftChildIndex(index);

                if (GetLeftChild(index) > _heap[largestIndex])
                {
                    largestIndex = leftChildIndex;
                }

                if (HasRightChild(index) && GetRightChild(index) > _heap[largestIndex])
                {
                    largestIndex = GetRightChildIndex(index);
                }

                if (largestIndex != index)
                {
                    Swap(largestIndex, index);
                    SiftDown(largestIndex);
                }
            }
        }

        #endregion
    }
}