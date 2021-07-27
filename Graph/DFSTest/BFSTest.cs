using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Graph;



namespace GraphTest
{
    [TestClass]
    public class BFSTest
    {
        [TestMethod]
        public void TestTraversal()
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
            Assert.IsTrue(T.Count == 11);
            Assert.IsTrue(T[0] == n1);
            Assert.IsTrue(T[1] == n2);
            Assert.IsTrue(T[2] == n4);
            Assert.IsTrue(T[3] == n5);
            Assert.IsTrue(T[4] == n3);
            Assert.IsTrue(T[5] == n6);
            Assert.IsTrue(T[6] == n11);
            Assert.IsTrue(T[7] == n8);
            Assert.IsTrue(T[8] == n9);
            Assert.IsTrue(T[9] == n7);
            Assert.IsTrue(T[10] == n10);
        }

        [TestMethod]
        public void TestLinkedListPath()
        {
            // n1 -> n2 -> n3 (One way)
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            n1.addAdjNode(n2); n2.addAdjNode(n3);

            // Test
            ArrayList path12 = GraphAPI.BFS_path(n1, n2);
            Assert.IsTrue(path12.Count == 2);
            Assert.IsTrue(path12[0] == n1);
            Assert.IsTrue(path12[1] == n2);

            ArrayList path13 = GraphAPI.BFS_path(n1, n3);
            Assert.IsTrue(path13.Count == 3);
            Assert.IsTrue(path13[0] == n1);
            Assert.IsTrue(path13[1] == n2);
            Assert.IsTrue(path13[2] == n3);
        }

        [TestMethod]
        public void TestLinkedListReverse()
        {
            // n1 -> n2 -> n3 (One way)
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            n1.addAdjNode(n2); n2.addAdjNode(n3);

            // n2 cannot go back to n1, empty path
            ArrayList path21 = GraphAPI.BFS_path(n2, n1);
            Assert.IsTrue(path21.Count == 0);
        }

        [TestMethod]
        public void TestGraph()
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

            // n1 -> n2 -> n3 -> n8
            ArrayList path18 = GraphAPI.BFS_path(n1, n8);
            Assert.IsTrue(path18.Count == 4);
            Assert.IsTrue(path18[0] == n1);
            Assert.IsTrue(path18[1] == n2);
            Assert.IsTrue(path18[2] == n3);
            Assert.IsTrue(path18[3] == n8);

            // n10 -> n9 -> n7 -> n6
            ArrayList path106 = GraphAPI.BFS_path(n10, n6);
            Assert.IsTrue(path106.Count == 4);
            Assert.IsTrue(path106[0] == n10);
            Assert.IsTrue(path106[1] == n9);
            Assert.IsTrue(path106[2] == n7);
            Assert.IsTrue(path106[3] == n6);
        }
    }
}
