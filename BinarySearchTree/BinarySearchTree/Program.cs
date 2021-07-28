using System;
using System.Collections;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST(10);
            Node n7 = tree.add(7); Node n19 = tree.add(19);
            Node n16 = tree.add(16); Node n20 = tree.add(20);
            Node n22 = tree.add(22);

            tree.print();
            Console.WriteLine("Size: " + tree.getSize());

            // Remove non-exist node
            tree.remove(4);
            tree.print();
            Console.WriteLine("Size: " + tree.getSize());

            // Remove leaf node
            tree.remove(7);
            tree.print();
            Console.WriteLine("Size: " + tree.getSize());

            // Remove one child node
            tree.remove(20);
            tree.print();
            Console.WriteLine("Size: " + tree.getSize());

            // Remove 2 children node
            tree.remove(19);
            tree.print();
            Console.WriteLine("Size: " + tree.getSize());

        }

    }
}
