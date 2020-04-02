using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListImplementation
{
    public class LinkedList<T>
    {
        private Node<T> first;
        private Node<T> last;

        public LinkedList()
        {
            this.first = null;
            this.last = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void InsertBegin(T element)
        {
            var node = new Node<T>(element);
            this.InsertBegin(node);
        }

        public void InsertBegin(Node<T> node)
        {
            this.Count++;
            if (this.first == null)
            {
                this.first = node;
                return;
            }

            var firstBeforeInsertion = this.first;
            this.first = node;
            node.Next = firstBeforeInsertion;
            firstBeforeInsertion.Previous = node;
            if (this.last == null)
            {
                this.last = firstBeforeInsertion;
            }
        }

        public void Add(T element)
        {
            var node = new Node<T>(element);
            this.Add(node);
        }

        public void Add(Node<T> node)
        {    
            if (this.first == null)
            {
                this.first = node;
            }
            else if (this.last == null)
            {
                this.last = node;
                node.Previous = this.first;
                this.first.Next = node;
            }
            else 
            {
                var lastBeforeAdding = this.last;

                this.last = node;
                node.Previous = lastBeforeAdding;
                lastBeforeAdding.Next = node;
            }

            this.Count++;
        }

        public void InsertAfter(Node<T> node, T value)
        {
            var nodeToInsertAfter = this.Find(node.Value);

            if (nodeToInsertAfter == null)
            {
                throw new ArgumentException();
            }
            var newNode = new Node<T>(value);
            if (nodeToInsertAfter == this.last)
            {
                this.last = newNode;
                newNode.Previous = nodeToInsertAfter;
                nodeToInsertAfter.Next = newNode;               
            }
            else
            {
                var nextNode = nodeToInsertAfter.Next;

                nodeToInsertAfter.Next = newNode;
                newNode.Previous = nodeToInsertAfter;
                newNode.Next = nextNode;
                nextNode.Previous = newNode;              
            }                       

            this.Count++;
        }

        public void InsertBefore(Node<T> node, T value)
        {
            var nodeToInsertBefore = this.Find(node.Value);

            if (nodeToInsertBefore == null)
            {
                throw new ArgumentException();
            }

            var newNode = new Node<T>(value);
            if (nodeToInsertBefore == this.first)
            {
                this.first = newNode;
                newNode.Next = nodeToInsertBefore;
                nodeToInsertBefore.Previous = newNode;
                if (this.last == null)
                {
                    this.last = nodeToInsertBefore;
                }
            }

            var beforeToInsertNode = nodeToInsertBefore.Previous;
            if (beforeToInsertNode != null)
            {
                beforeToInsertNode.Next = newNode;
                newNode.Previous = beforeToInsertNode;
                newNode.Next = nodeToInsertBefore;
                nodeToInsertBefore.Previous = newNode;
            }

            this.Count++;
        }

        public void DeleteNode(Node<T> node)
        {
            if (node == null || this.Count == 0)
            {
                throw new ArgumentException();
            }

            if (this.Count == 1)
            {
                if (this.first == node)
                {
                    this.Clear();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else if (this.first == node)
            {
                //New furst element
                this.first = this.first.Next;
                this.first.Previous = null;
            }
            else if (this.last == node)
            {
                this.last = this.last.Previous;
                this.last.Next = null;
            }
            else
            {
                var previousNode = node.Previous;
                var nextNode = node.Next;

                previousNode.Next = nextNode;
                nextNode.Previous = previousNode;
            }
            this.Count--;
        }

        public void DeleteNode(T value)
        {
            var nodeTodelete = this.Find(value);
            this.DeleteNode(nodeTodelete);
        }

        public void Print()
        {
            var currentNode = this.first;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public Node<T> Find(T element)
        {
            if (this.Count == 0)
            {
                return null;
            }
            var currentNode = this.first;

            while (currentNode != null)
            {
                if (Object.Equals(currentNode.Value, element))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        public void Clear()
        {
            this.first = null;
            this.last = null;
            this.Count = 0;
        }
    }
}
