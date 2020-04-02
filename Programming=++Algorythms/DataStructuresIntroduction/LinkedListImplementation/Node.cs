using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListImplementation
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get;  set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }
}
