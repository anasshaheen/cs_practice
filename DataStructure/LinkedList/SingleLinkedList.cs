using System;

namespace CS.DataStructure.LinkedList
{
    public class SingleLinkedList
    {
        public SingleLinkedListNode Head;

        public SingleLinkedList(SingleLinkedListNode head = null)
        {
            Head = head;
        }

        public void AddAtHead(int data)
        {
            var temp = new SingleLinkedListNode(data, Head);
            Head = temp;
        }

        public virtual int? RemoveFromHead()
        {
            if (Head == null)
            {
                return null;
            }

            var data = Head.Data;
            Head = Head.Next;

            return data;
        }

        public void Reverse()
        {
            var current = Head;
            SingleLinkedListNode prev = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;

                current = next;
            }

            Head = prev;
        }

        public void Print()
        {
            var temp = Head;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }

        public void AddAtEnd(int data)
        {
            if (Head == null)
            {
                Head = new SingleLinkedListNode(data);
                return;
            }

            var temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = new SingleLinkedListNode(data);
        }

        public void Delete(int data)
        {
            if (Head == null)
            {
                return;
            }

            if (Head.Data == data)
            {
                Head = Head.Next;
            }

            var temp = Head;
            while (temp.Next != null)
            {
                if (temp.Next.Data == data)
                {
                    temp.Next = temp.Next.Next;
                    break;
                }

                temp = temp.Next;
            }
        }
    }
}