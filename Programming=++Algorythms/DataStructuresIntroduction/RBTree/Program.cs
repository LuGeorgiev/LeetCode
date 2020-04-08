using System;

namespace RBTreeImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new RBTree<int>();
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(-1);
            tree.Delete(2);
            tree.Insert(-10);
            tree.Delete(3);
            tree.Insert(2);

            tree.DisplayTree();
        }
    }
}
