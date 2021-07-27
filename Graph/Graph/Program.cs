using System;
using System.Collections;


namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);
            Node n8 = new Node(8);
            Node n9 = new Node(9);
            Node n10 = new Node(10);
            Node n11 = new Node(11);

            n1.addAdjNode(n2); n1.addAdjNode(n4); n1.addAdjNode(n5);
            n2.addAdjNode(n1); n2.addAdjNode(n5); n2.addAdjNode(n3);
            n3.addAdjNode(n2); n3.addAdjNode(n8); n3.addAdjNode(n9);
            n4.addAdjNode(n1); n4.addAdjNode(n6); n4.addAdjNode(n11);
            n5.addAdjNode(n2); n5.addAdjNode(n1);
            n6.addAdjNode(n4); n6.addAdjNode(n7);
            n7.addAdjNode(n6); n7.addAdjNode(n9);
            n8.addAdjNode(n3);
            n9.addAdjNode(n3); n9.addAdjNode(n7); n9.addAdjNode(n10);
            n10.addAdjNode(n9);
            n11.addAdjNode(n4);

            ArrayList T = BFS.traversal(n1);
            GraphAPI.printPath(T);

        }
    }
}
