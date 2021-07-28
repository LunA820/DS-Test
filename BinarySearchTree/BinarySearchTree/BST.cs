using System;
using System.Collections;


namespace BinarySearchTree
{
    public class BST
    {
        private Node root;
        public BST(int x) {
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
            if (n.getX() >= cur.getX()) {
                if (cur.getRight() == null)
                    cur.setRight(n);
                else
                    addUtil(cur.getRight(), n);
            }

            else if (cur.getLeft() == null) { cur.setLeft(n); }
            else { addUtil(cur.getLeft(), n); }
        }

        // Remove node from BST
        public void remove(int x)
        {
            removeUtil(x, root);
        }

        private void removeUtil(int x, Node cur)
        {
            // Case 1: No node to be removed
            if (cur == null) { return; }

            // Case 2: Go left or right
            if (x > cur.getX()) {
                removeUtil(x, cur.getRight());
            }
            else if (x < cur.getX()) {
                removeUtil(x, cur.getLeft());
            }

            // Case 3: Remove node
            else{
                Node parent = getParent(cur);

                // Case 3.1: Leaf node
                if (cur.getLeft() == null && cur.getRight() == null)
                {
                    if (parent.getLeft() == cur) { parent.setLeft(null); }
                    else { parent.setRight(null); }
                }

                // Case 3.2: 2 children
                else if (cur.getLeft() != null && cur.getRight() != null)
                {
                    Node rightMin = getMinUtil(cur.getRight());
                    rightMin.setLeft(cur.getLeft());
                    cur.setLeft(null);

                    if (parent.getLeft() == cur)
                        parent.setLeft(cur.getRight());
                    else
                        parent.setRight(cur.getRight());
                 }

                // Case 3.3: 1 Child
                else if (cur.getLeft() != null)
                {
                    if (parent.getLeft() == cur)
                        parent.setLeft(cur.getLeft());
                    else
                        parent.setRight(cur.getLeft());
                }

                else
                {
                    if (parent.getLeft() == cur)
                        parent.setLeft(cur.getRight());
                    else
                        parent.setRight(cur.getRight());
                }
            }
        }



        // Get parent of a value
        public Node getParent(int x) { return getParentUtil(x, root); }

        private Node getParentUtil(int x, Node cur)
        {
            if (cur == null) { return null; }

            if (cur.getLeft() != null){
                if (cur.getLeft().getX() == x) { return cur; }
            }
            if (cur.getRight() != null){
                if (cur.getRight().getX() == x) { return cur; }
            }
            if (cur.getX() > x) { return getParentUtil(x, cur.getLeft()); }
            return getParentUtil(x, cur.getRight());
        }

        // Get parent of a node
        public Node getParent(Node n) { return getParentUtil(n, root); }

        private Node getParentUtil(Node n, Node cur)
        {
            if (cur == null) { return null; }

            if (cur.getLeft() == n || cur.getRight() == n) { return cur; }

            if (cur.getX() > n.getX()) { return getParentUtil(n, cur.getLeft()); }
            return getParentUtil(n, cur.getRight());
        }


        // Get first Node with value X
        public Node getNode(int x) {return getNodeUtil(x, root);}
        private Node getNodeUtil(int x, Node curr)
        {
            if (curr == null) { return null; }
            if (curr.getX() == x) { return curr; }
            if (curr.getX() > x) { return getNodeUtil(x, curr.getLeft()); }
            return getNodeUtil(x, curr.getRight());
        }

        // Get Node with min. value
        public Node getMin() { return getMinUtil(root); }
        private Node getMinUtil(Node cur)
        {
            if (cur.getLeft() != null) { return getMinUtil(cur.getLeft()); }
            return cur;
        }


        // Get Node with max. value
        public Node getMax() { return getMaxUtil(root); }
        private Node getMaxUtil(Node cur)
        {
            if (cur.getRight() != null) { return getMaxUtil(cur.getLeft()); }
            return cur;
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

        // Get size of BST
        public int getSize() { return getSizeUtil(root); }
        private int getSizeUtil(Node curr)
        {
            if (curr == null) { return 0; }
            return 1 + getSizeUtil(curr.getLeft()) + getSizeUtil(curr.getRight());
        }

        // Get root
        public Node getRoot() { return root; }

        // Print an Arraylist of nodes
        public void print()
        {
            ArrayList T = traversal();
            foreach (Node n in T)
                Console.Write(n.getX() + " ");

            Console.WriteLine("");
        }

    }
}
