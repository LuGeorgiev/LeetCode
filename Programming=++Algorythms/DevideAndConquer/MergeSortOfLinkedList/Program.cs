using System.CodeDom.Compiler;
using System.Net.NetworkInformation;

namespace MergeSortOfLinkedList
{
    internal class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public static Node Z { get; private set; }

        static Node()
        {
            Z = new Node { Value = int.MaxValue };
            Z.Next = Z;
        }
    }


    internal class Program
    {
        private const int NODES_COUNT = 69;

        static void Main(string[] args)
        {
            Node listHead = GeneratedLinkedList(NODES_COUNT);
            PrintLinkedList(listHead);

            listHead = MergeSort(listHead);
            Console.WriteLine("After Sorting");
            PrintLinkedList(listHead);
        }

        private static Node MergeSort(Node head)
        {
            if (head.Next == Node.Z)
                return head; //only on eelement

            Node a = head;
            Node b = head.Next.Next.Next;

            //slipt into two equal parts
            while (b != Node.Z)
            {
                b = b.Next.Next;
                head = head.Next;
            }

            b = head.Next;
            head.Next = Node.Z;

            //Sorting of bot parts and then merging

            return Merge(MergeSort(a), MergeSort(b));
        }

        private static Node Merge(Node a, Node b)
        {
            //Suppose both list contains at least one element
            Node tail = Node.Z;

            do
            {
                if (a.Value < b.Value)
                {
                    tail.Next = a;
                    tail = a;
                    a = a.Next;
                }
                else
                {
                    tail.Next = b;
                    tail = b;
                    b = b.Next;
                }
            } while (tail != Node.Z);

            tail = Node.Z.Next;
            Node.Z.Next = Node.Z;

            return tail;
        }

        private static void PrintLinkedList(Node list)
        {
            while (list != Node.Z)
            {
                Console.Write($"{list.Value} ");
                list = list.Next;
            }
            Console.WriteLine();
        }

        private static Node GeneratedLinkedList(int count)
        {
            var rnd = new Random();
            Node p = Node.Z;
            for (int i = 0; i < count; i++)
            {
                var q = new Node { Value = rnd.Next() % (2 * count + 1), Next = p };
                p = q;
            }

            return p;
        }
    }
}