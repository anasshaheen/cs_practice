using System;

namespace CS.DataStructure.HashTable.Exceptions
{
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException()
            : base("The specified key doesn't exists.")
        {
        }
    }
}