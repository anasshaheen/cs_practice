using System;

namespace CS.DataStructure.LinkedList
{
    public class DoublyLinkedList
    {
        private DoubleLinkedListNode _head;

        public DoublyLinkedList(DoubleLinkedListNode head = null)
        {
            _head = head;
        }

        public void Print()
        {
            var temp = _head;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }

        public void InsertAtHead(int data)
        {
            var temp = new DoubleLinkedListNode(data, _head);
            if (_head != null)
            {
                _head.Prev = temp;
            }

            _head = temp;
        }

        public void InsertLast(int data)
        {
            if (_head == null)
            {
                _head = new DoubleLinkedListNode(data);
                return;
            }

            var temp = _head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = new DoubleLinkedListNode(data, null, temp);
        }

        public void Reverse()
        {
            var current = _head;
            DoubleLinkedListNode temp = null;
            while (current != null)
            {
                temp = current.Prev;
                current.Prev = current.Next;
                current.Next = temp;
                current = current.Prev;
            }

            if (temp != null)
            {
                _head = temp.Prev;
            }
        }

        public bool Search(int data)
        {
            var temp = _head;
            while (temp != null)
            {
                if (temp.Data == data)
                {
                    return true;
                }

                temp = temp.Next;
            }

            return false;
        }

        public void DeleteFromHead()
        {
            if (_head == null)
            {
                return;
            }

            _head = _head.Next;
            if (_head != null)
            {
                _head.Prev = null;
            }
        }

        public void DeleteFromLast()
        {
            if (_head == null)
            {
                throw new NullReferenceException();
            }

            if (_head.Next == null)
            {
                _head = null;
                return;
            }

            var temp = _head;
            while (temp.Next.Next != null)
            {
                temp = temp?.Next;
            }

            temp.Next = null;
        }

        public void Delete(int data)
        {
            if (_head == null)
            {
                throw new NullReferenceException();
            }

            if (_head.Data == data)
            {
                _head = _head.Next;
                _head.Prev = null;
                return;
            }

            var temp = _head;
            while (temp.Next != null)
            {
                if (temp.Data == data)
                {
                    temp.Prev.Next = temp.Next;
                    temp.Next.Prev = temp.Prev;
                    break;
                }

                temp = temp.Next;
            }
        }
    }
}
