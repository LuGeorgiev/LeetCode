using System.CodeDom.Compiler;

namespace _7._3.MergeSortedLinkedList
{
    internal class Node
    {
        public int Value { get; set; }

        public Node? Next { get; set; }
    }

    internal class MergeLinkedList
    {
        static void Main(string[] args)
        {
            var nodesCount = 19;
            //NB Note that LinkedList is NOT sorted but become sorted
            Node linkedListNode = Generae(nodesCount);
            Console.WriteLine( "Before sorting");
            PrintList(linkedListNode);

            linkedListNode = MergeSort(linkedListNode, nodesCount);

            Console.WriteLine( "After Sorting");
            PrintList(linkedListNode);
        }

        private static Node MergeSort(Node linkedListNode, int nodesCount)
        {
            //If ther is only one element return
            if(nodesCount <= 1)
                return linkedListNode;

            Node leftNode = linkedListNode;
            var halfCount = nodesCount / 2;

            //split the list into two equal parts
            for (int i = 2; i <= halfCount; i++)
                linkedListNode = linkedListNode.Next!;

            var rightNode = linkedListNode.Next;
            linkedListNode.Next = null;

            //Sorting the two tarts separetly then merging
            return Merge(MergeSort(leftNode, halfCount ), MergeSort(rightNode!, nodesCount - halfCount));
        }

        private static Node Merge(Node a, Node b)
        {
            //Suppose both lists contains at least one element
            var tail = new Node();
            var head = tail;

            while (true)
            {
                if (a.Value < b.Value)
                {
                    tail.Next = a;
                    a = a.Next;
                    tail = tail.Next;
                    if (a is null)
                    {
                        tail.Next = b;
                        break;
                    }
                }
                else 
                {
                    tail.Next = b;
                    b = b.Next;
                    tail = tail.Next;
                    if (b is null)
                    {
                        tail.Next = a;
                        break;
                    }
                }
            }

            return head.Next!;
        }

        private static void PrintList(Node linkedListNode)
        {
            if (linkedListNode == null) { throw new ArgumentNullException(); }

            while (linkedListNode != null)
            {
                Console.Write($"{linkedListNode.Value} ");
                linkedListNode = linkedListNode.Next!;
            }
            Console.WriteLine();
        }

        private static Node Generae(int nodesCount)
        {
            var rnd = new Random();
            Node node = null;
            for (int i = 0; i < nodesCount; i++)
            {
                var tempNode = new Node { Value = rnd.Next() % (2 * nodesCount + 1), Next = node };
                node = tempNode;
            }
            return node!;
        }
    }
}