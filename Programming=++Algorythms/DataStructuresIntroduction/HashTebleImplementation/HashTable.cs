using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTebleImplementation
{
    class HashTable<TKey, TValue> : IEnumerable<TKey>
        where TKey : IEqualityComparer<TKey>
    {
        private const string NO_SUCH_KEY = "No such key!";

        private readonly int[] capacity = new int[] { 3, 7, 17, 37, 67, 131, 269, 547, 1_301, 2_617, 5_227, 10_601, 21_013, 42_197, 85_439, 104_729 };
        private readonly float saturation = 0.8f;

        private int capacityIndex;
        private int hashBase;
        private SingleLinkList[] hashTable;

        public HashTable()
        {
            this.Count = 0;
            this.capacityIndex = 0;
            this.hashBase = this.capacity[this.capacityIndex];
            this.hashTable = new SingleLinkList[hashBase];
            for (int i = 0; i < this.hashTable.Length; i++)
            {
                this.hashTable[i] = new SingleLinkList();
            }
        }


        public int Count { get; private set; }

        public TValue this[TKey key]
        {
            get => this.GetValue(key);
            set => this.Add(key, value);
        }

        public TValue GetValue(TKey key)
            => this.GetCorrespondingList(key)[key];


        public bool ConatainsKey(TKey key)
            => this.GetCorrespondingList(key)
                     .HasKey(key);


        public void Add(TKey key, TValue value)
        {
            var linkList = GetCorrespondingList(key);
            var keyAlreadyExist = linkList.HasKey(key);

            if (! keyAlreadyExist)
            {
                linkList.AddFirst(new Node() { Key = key, Value = value });
                this.Count++;

                return;
            }

            var node = linkList.Find(key);
            node.Value = value;
        }

        private SingleLinkList GetCorrespondingList(TKey key)
        {
            int hashValue = key.GetHashCode();
            int index = hashValue % this.hashBase;
            var linkList = this.hashTable[index];

            return linkList;
        }

        public bool Remove(TKey key)
        {
            var linkedList = this.GetCorrespondingList(key);
            var exists = linkedList.HasKey(key);
            if (exists)
            {
                linkedList.Delete(key);
                this.Count--;
                return true;
            }
            return false;
        }


        IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

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

            public Node Find(TKey key)
            {
                if (key == null)
                {
                    throw new ArgumentNullException("Key cannot be null");
                }

                if (this.root == null)
                {
                    throw new ArgumentException(NO_SUCH_KEY);
                }

                var currentNode = this.root;
                while (currentNode != null)
                {
                    if (currentNode.Key.Equals(key))
                    {
                        return currentNode;
                    }

                    currentNode = currentNode.Next;
                }

                throw new ArgumentException(NO_SUCH_KEY);
            }

            public TValue this[TKey key]
                => this.Find(key).Value;
        }

        internal class Node
        {
            public TKey Key { get; set; }

            public TValue Value { get; set; }

            public Node Next { get; set; }
        }
    }
}
