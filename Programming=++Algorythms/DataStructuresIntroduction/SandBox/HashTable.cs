using System;
using System.Collections.Generic;
using System.Text;

namespace SandBox
{
    public class HashTable<TKey, TValue>
        where TKey:IEqualityComparer<TKey>
    {


        internal class SingleLinkList
        {
            private Node root;

            public SingleLinkList()
            {
                this.root = null;
            }

            public void AddFirst(Node element)
            {
                if (this.root == null)
                {
                    this.root = element;
                    return;
                }

                var currentRoot = this.root;
                this.root = element;
                element.Next = currentRoot;
            }

            public bool HasKey(TKey key)
            {
                if (this.root == null)
                {
                    return false;
                }

                var wasFound = false;
                var currentNode = this.root;
                while (currentNode != null)
                {
                    if (currentNode.Key.Equals(key))
                    {
                        wasFound = true;
                    }

                    if (wasFound)
                    {
                        break;
                    }
                    currentNode = currentNode.Next;
                }
                

                return wasFound;
            }

            public bool Delete(TKey key)
            {
                if (this.root == null)
                {
                    return false;
                }

                Node previousNode = null;
                Node currentNode = this.root;

                while (currentNode != null)
                {
                    if (currentNode.Key.Equals(key))
                    {
                        //this is the node that has to be deleted
                        if (previousNode == null)
                        {
                            //to be deleted node is currently root
                            this.root = currentNode.Next;
                            return true;
                        }

                        previousNode.Next = currentNode.Next;
                        return true;
                    }

                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }

                return false;
            }

            private TValue Find(TKey key)
            {

                return default(TValue);
            }

            public TValue this[TKey key]
                =>this.Find(key);
        }

        internal class Node
        {
            public TKey Key { get; set; }

            public TValue Value { get; set; }

            public Node Next { get; set; }
        }
    }   
}
