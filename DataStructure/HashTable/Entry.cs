namespace CS.DataStructure.HashTable
{
    public class Entry<TValue>
    {
        public int Key { get; set; }
        public TValue Value { get; set; }
        public Entry<TValue> Next { get; set; }

        public Entry(int key, TValue value, Entry<TValue> next = null)
        {
            Key = key;
            Value = value;
            Next = next;
        }
    }
}