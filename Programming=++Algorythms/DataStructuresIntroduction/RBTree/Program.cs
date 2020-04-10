using System;

namespace RBTreeImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new RBTree<int>();
            tree.Insert(6);
            tree.Insert(10);
            tree.Insert(30);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(123);
            tree.Insert(23); 
            tree.Delete(17);

            tree.DisplayTree();
        }
    }
}
