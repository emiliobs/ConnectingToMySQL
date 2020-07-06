using System;
using System.Collections.Generic;

namespace ConsoleAppVario
{
    //Tyhpe parameter T in angle brackets
    public class GenericList<T>
    {
       //The nested class is also generic on T
       private class Node
        {
            private Node _next;
            
            //T as private meber data type
            private T _data;

            //T used in non-generic contructor
            public Node(T t)
            {
                Next = null;
                Data = t;
            }

            
            public Node Next { get => _next; set => _next = value; }
           
            //T as return type of private:
            public T Data { get => _data; set => _data = value; }

        }

        private Node _head;

        public GenericList()
        {
            _head = null;
        }

        //T as method parameter type:
        public void AddHead(T t)
        {
            var node = new Node(t);
            node.Next = _head;
            _head = node;


        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentv = _head;

            while (currentv != null)
            {
                yield return currentv.Data;
                currentv = currentv.Next;
            }
        }
    }

    class Program
    {
      
       
        static void Main(string[] args)
        {
            //Int is the type argument:
            var list = new GenericList<int>();
            for (int i = 1; i <= 10; i++)
            {
                list.AddHead(i);
            }

            foreach (var i in list)
            {
                Console.WriteLine($"{i} ' ' ");
            }

            Console.WriteLine("\nDone");
        }
    }
}
