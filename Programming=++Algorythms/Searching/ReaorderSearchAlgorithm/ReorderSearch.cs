using System;

namespace ReaorderSearchAlgorithm
{
    public class ReorderSearch<K>
    {
        private Node<K> head; 

        public void Insert(int key, K value)
        {
            var newNode = new Node<K>(key, value);
            if (this.head == null)
            {
                this.head = newNode;
                return;
            }

            //newely inserted is put in first place alaways;
            MakeNodeFirst(newNode);
        }

        public void Print()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                Console.Write($"{currentNode.ToString()}, ");

                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }

        private void MakeNodeFirst(Node<K> newNode)
        {
            var seconNode = this.head;
            this.head = newNode;
            newNode.Next = seconNode;
            seconNode.Previous = this.head;
        }

        public K Search(int key)
        {
            Node<K> nodeToSearch = this.head;
            bool wasFound = false;

            while (nodeToSearch != null)
            {
                if (nodeToSearch.Key == key)
                {
                    wasFound = true;
                    break;
                }
                nodeToSearch = nodeToSearch.Next;
            }

            if (wasFound)
            {
                if (nodeToSearch == this.head)
                {
                    return nodeToSearch.Value;
                }

                // Connect previous and next Nodes
                nodeToSearch.Previous.Next = nodeToSearch.Next;
                nodeToSearch.Next.Previous = nodeToSearch.Previous;

                MakeNodeFirst(nodeToSearch);

                return nodeToSearch.Value;
            }
            else
            {
                throw new ArgumentException($"No such key: {key}");
            }
        }

        public class Node<T>
        {
            public Node(int key, T value)
            {
                this.Key = key;
                this.Value = value;
            }

            public int Key { get; set; }

            public T Value { get; set; }

            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }

            public override string ToString()
                => $"{this.Key} -> {this.Value}";
        }
    }
}
