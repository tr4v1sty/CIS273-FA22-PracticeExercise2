﻿using System;


namespace PracticeExercise2
{
    //using this to test commit

    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data = default(T), LinkedListNode<T> next =null)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }

    public class LinkedList<T> : IList<T>
    {
        public LinkedListNode<T>? Head { get; set; }
        public LinkedListNode<T>? Tail { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        public T? First => IsEmpty ? default(T) : Head.Data;

        public T? Last => IsEmpty ? default(T)  : Tail.Data;

        public bool IsEmpty => Head == null || Tail == null;
        //this was auto fill done but it says true or false bool so it works
    


        private int length = 0;
        public int Length => length;

        public void Append(T value)
        {

            var newNode = new LinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            length++;

        }

        public void Clear()
        {
            Head = null;
            Tail = null;

            length = 0;   
        }

        public bool Contains(T value)
        {
            var curNode = Head;
            while (curNode != null) 
            {
                if (curNode.Data.Equals(value))
                {
                    return true;
                }
                curNode = curNode.Next;
               
            }
            return false;
        }

        public int FirstIndexOf(T value)
        {
            int index = 0;

            var currentNode = Head;

            while(currentNode!=null)
            {
                if( currentNode.Data.Equals(value) )
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;

            }

            return -1;
        }

        public T Get(int index)
        {
            

            var curIndex = 0;
            var curNode = Head;
            while (curNode != null)
            {
                if(curIndex == index)
                {
                    return curNode.Data;
                }
                curNode = curNode.Next;
                curIndex++;

            }
            throw new IndexOutOfRangeException();


        }


        public void InsertAfter(T newValue, T existingValue)
        {
            var newNode = new LinkedListNode<T>(newValue);
            var curNode = Head;
            while (curNode != null)
            {
                if (IsEmpty)
                {
                    Head = newNode;
                    Tail = newNode;
                    length++;
                }
                if (curNode.Data.Equals(existingValue))
                {
                    if (curNode == Tail)
                    {
                        curNode.Next = newNode;
                        Tail = newNode;
                        length++;
                        return;
                    }
                    else
                    {
                        newNode.Next = curNode.Next;
                        curNode.Next = newNode;
                        length++;
                        return;
                    }
                }
                curNode = curNode.Next;
            }
            Append(newValue);
            length++; 
        }

        public void InsertAt(T value, int index)
        {
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }
            if(index == 0)
            {
                Prepend(value);
            }
            
            var curIndex = 0;
            var curNode = Head;

            while (curNode != null)
            {
                // find the node at index - 1
                if (curIndex == index - 1)
                {
                   var newNode = new LinkedListNode<T>(value);
                    newNode.Next = curNode.Next;
                    curNode.Next = newNode;
                    length++;
                    if(curNode == Tail)
                    {
                        Tail = newNode;
                    }
                }
                curNode = curNode.Next;
                curIndex++;

            }
        }

        public void Prepend(T value)
        {
            var newNode = new LinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            length++;

            
        }

        public void Remove(T value)
        {
            // If list is empty, we're done, son. 
            if( IsEmpty )
            {
                return;
            }

            // Remove head
            if( Head.Data.Equals(value) )
            {
                // 1-element list
                if (Head == Tail)
                {
                    Tail = null;
                    Head = null;
                }
                else
                {
                    Head = Head.Next;
                }
                length--;

                return;
            }

            // Remove non-head node
            var currentNode = Head;
            while( currentNode != null)
            {
                if ( currentNode.Next != null && currentNode.Next.Data.Equals(value))
                {
                    var nodeToDelete = currentNode.Next;
                    length--;

                    if( nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }else
                    {
                        currentNode.Next = currentNode.Next.Next;
                        nodeToDelete.Next = null;
                    }

                    return;
                }

                currentNode = currentNode.Next;
            }

        }

        public void RemoveAt(int index)
        {
            Remove(Get(index));

            
        }

        

        public IList<T> Reverse()
        {
            IList<T> reverseList = new LinkedList<T>();
            var curNode = Head;
            while (curNode != null)
            {
                reverseList.Prepend(curNode.Data);
                curNode = curNode.Next;
            }
            return reverseList;
        }

        public override string ToString()
        {
            string result = "[";

            for(var currentNode = Head; currentNode !=null; currentNode = currentNode.Next )
            {
                result += currentNode.ToString();
                if(currentNode != Tail)
                {
                    result += ", ";
                }

            }
            result += "]";

            return result;

        }
    }
}

