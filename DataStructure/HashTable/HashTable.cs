using System;
using CS.DataStructure.HashTable.Exceptions;

namespace CS.DataStructure.HashTable
{
    public class HashTable<TValue>
    {
        private int _capacity;
        private int _count;
        private Entry<TValue>[] _entries;
        private readonly float _loadFactor;
        private readonly int _resizeFactor;

        public HashTable(float loadFactor = 0.75f, int capacity = 8)
        {
            _count = 0;
            _capacity = capacity;
            _loadFactor = loadFactor;
            _resizeFactor = 2;
            _entries = new Entry<TValue>[_capacity];
        }

        #region Operations

        public TValue this[int key]
        {
            get => Get(key);
            set => Put(key, value);
        }

        public TValue Get(int key)
        {
            var hashCode = ComputeHash(key);
            if (_entries[hashCode] == null)
            {
                throw new KeyNotFoundException();
            }

            if (_entries[hashCode].Key.Equals(key))
            {
                return _entries[hashCode].Value;
            }

            var temp = _entries[hashCode].Next;
            while (temp != null)
            {
                if (temp.Key.Equals(key))
                {
                    return temp.Value;
                }

                temp = temp.Next;
            }

            throw new KeyNotFoundException();
        }

        public void Put(int key, TValue value)
        {
            if (ReachedResizingLimit())
            {
                Resize();
            }

            var hashCode = ComputeHash(key);
            if (_entries[hashCode] != null)
            {
                var temp = _entries[hashCode];
                EnsureKeyIsUnique(temp, key);
                var node = new Entry<TValue>(key, value, temp);
                _entries[hashCode] = node;
            }
            else
            {
                _entries[hashCode] = new Entry<TValue>(key, value);
            }

            ++_count;
        }

        public TValue Delete(int key)
        {
            var hashCode = ComputeHash(key);
            if (_entries[hashCode] == null)
            {
                throw new KeyNotFoundException();
            }

            TValue tempValue;
            if (_entries[hashCode].Key.Equals(key))
            {
                tempValue = _entries[hashCode].Value;
                _entries[hashCode] = _entries[hashCode].Next;
                return tempValue;
            }

            var temp = _entries[hashCode];
            while (temp.Next != null)
            {
                if (temp.Next.Key.Equals(key))
                {
                    tempValue = temp.Next.Value;
                    temp.Next = temp.Next.Next;
                    return tempValue;
                }

                temp = temp.Next;
            }

            throw new KeyNotFoundException();
        }

        #endregion

        #region Helpers

        private int ComputeHash(int key)
        {
            return key % _capacity;
        }

        private void Resize()
        {
            _capacity *= _resizeFactor;
            var resizedArr = new Entry<TValue>[_capacity];

            ReHash(resizedArr);

            _entries = resizedArr;
        }

        private void ReHash(Entry<TValue>[] newArray)
        {
            for (var i = 0; i < _entries.Length; ++i)
            {
                if (_entries[i] != null)
                {
                    var key = _entries[i].Key;
                    var newHashCode = ComputeHash(key);
                    newArray[newHashCode] = _entries[i];
                }
            }
        }

        private bool ReachedResizingLimit()
        {
            return _count > Math.Floor(_capacity * _loadFactor);
        }

        private void EnsureKeyIsUnique(Entry<TValue> entry, int key)
        {
            if (entry != null && entry.Key.Equals(key))
            {
                throw new DuplicateKeyException();
            }

            if (entry?.Next == null)
            {
                return;
            }

            var temp = entry;
            while (temp != null)
            {
                if (temp.Key.Equals(key))
                {
                    throw new DuplicateKeyException();
                }

                temp = temp.Next;
            }
        }

        #endregion

        public int Count => _count;
    }
}
