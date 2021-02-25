using System;
using System.Collections;

namespace TestTask
{
    public class LinkedList<T> : IEnumerable
    {
        private class ListNode
        {
            public ListNode next;
            public ListNode prev;
            public T data;

            public ListNode(T elem)
            {
                next = null;
                prev = null;
                data = elem;
            }
        }

        private ListNode head;
        private ListNode tail;
        private uint size;

        public uint Size => size;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void Add(T elem)
        {
            ListNode node = new ListNode(elem);
            if (head == null)
            {
                head = node;
                tail = node;
                head.next = null;
                head.prev = null;
            }
            else
            {
                node.prev = tail;
                tail.next = node;
                tail = node;
                node.next = null;
            }

            size++;
        }
        
        public void Add(T elem, uint pos)
        {
            ListNode curr = FindByPos(pos);
            ListNode newNode = new ListNode(elem);

            if (pos == size)
            {
                Add(elem);
            }
            else
            {
                newNode.next = curr;
                newNode.prev = curr.prev;
                curr.prev.next = newNode;
                curr.prev = newNode;
            
                size++;
            }
        }
        
        private ListNode FindByPos(uint pos)
        {
            uint cnt = 0;
            ListNode curr = head;
            
            while (cnt != pos && curr != null)
            {
                curr = curr.next;
                cnt++;
            }

            return curr;
        }

        public T Get(uint pos)
        {
            ListNode elem = FindByPos(pos);
            if (elem == null)
            {
                throw new IndexOutOfRangeException();
            }
            return elem.data;
        }
        
        public void Delete(uint pos)
        {
            ListNode curr = FindByPos(pos);
            if (curr != null)
            {
                if (curr == head)
                {
                    head = head.next;
                    head.prev = null;
                }
                else if (curr == tail)
                {
                    tail = tail.prev;
                    tail.next = null;
                }
                else
                {
                    curr.prev.next = curr.next;
                    curr.next.prev = curr.prev;
                }

                size--;
            }
        }

        public void Reverse()
        {
            ListNode tmp = head;
            head = tail;
            tail = tmp;
            
            ListNode curr = head;
            while (curr != null)
            {
                tmp = curr.next;
                curr.next = curr.prev;
                curr.prev = tmp;
                curr = curr.next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            ListNode curr = head;

            while (curr != null)
            {
                yield return curr.data;
                curr = curr.next;
            }
        }
        
    }
}