using System;
using System.Collections;


namespace BinarySearchTree
{
    public class BST
    {
        private Node root;
        public BST(int x){
            root = new Node(x);
        }


        // Add new node to BST
        public Node add(int x)
        {
            Node n = new Node(x);
            addUtil(root, n);
            return n;
        }

        private void addUtil(Node cur, Node n)
        {
            if (n.getX() >= cur.getX()){
                if (cur.getRight() == null)
                    cur.setRight(n);
                else
                    addUtil(cur.getRight(), n);
            }

            else if (cur.getLeft() == null) { cur.setLeft(n); }
            else { addUtil(cur.getLeft(), n); }
        }


        // Get first Node with value X
        public Node getNode(int x){
            return getNodeUtil(x, root);
        }

        private Node getNodeUtil(int x, Node curr)
        {
            if (curr == null) { return null; }
            if (curr.getX() == x) { return curr; }
            if (curr.getX() > x) { return getNodeUtil(x, curr.getLeft()); }
            return getNodeUtil(x, curr.getRight());
        }


        // Get all nodes of BST
        public ArrayList traversal()
        {
            ArrayList T = new ArrayList();
            visitAllNodes(T, root);
            return T;
        }
        private void visitAllNodes(ArrayList T, Node curr)
        {
            T.Add(curr);
            if (curr.getLeft() != null) { visitAllNodes(T, curr.getLeft()); }
            if(curr.getRight() != null) { visitAllNodes(T, curr.getRight()); }
        }

        // Print an Arraylist of nodes
        public void print(ArrayList T)
        {
            foreach (Node n in T)
                Console.Write(n.getX() + " ");

            Console.WriteLine("");
        }
    }
}
