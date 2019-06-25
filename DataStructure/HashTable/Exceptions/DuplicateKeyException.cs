using System;

namespace CS.DataStructure.HashTable.Exceptions
{
    public class DuplicateKeyException : Exception
    {
        public DuplicateKeyException()
            : base("The specified key is already exists.")
        {
        }
    }
}