using System;

namespace L6Trees
{
    class Node
    {
        private Node left;
        private Node right;
        private int item;
        private Node parent;

        public Node(int item)
        {
            this.item = item;
        }
        public void addNode(int item)
        {
            if (parent == null)
                parent = new Node(item);
            else
                recInsert(item);
        }
        private void recInsert(int item)
        {
            if (item < parent.item)
            {
                if (parent.left == null)
                    parent.left = new Node(item);
                else
                {
                    parent = parent.left;
                    recInsert(item);
                }
            }
            else if (item > parent.item)
            {
                if (parent.right == null)
                    parent.right = new Node(item);
                else
                {
                    parent = parent.right;
                    recInsert(item);
                }
            }
        }
        private int recFind(int item)
        {
            if (parent == null)
                return -1;
            if (item == parent.item)
                return item;

            else if (item < parent.item)
            {
                parent = parent.left;
                if (recFind(item) == item)
                    return item;
                else
                    return -1;
            }
            else if (item > parent.item)
            {
                parent = parent.right;
                if (recFind(item) == item)
                    return item;
                else
                    return -1;
            }
            else
                return -1;
        }
        private void delNode(int item)
        {
            if (item == parent.item)
                parent.item = -1;
            else if (item < parent.item)
            {
                parent = parent.left;
                delNode(item);
            }
            else if (item > parent.item)
            {
                parent = parent.right;
                delNode(item);
            }
        }

        public Boolean findNode(int item)
        {
            if (recFind(item) == item)
                return true;
            else
                return false;
        }
        public Boolean deleteNode(int item)
        {
            if (recFind(item) == item)
            {
                delNode(item);
                return true;
            }
            else
                return false;
        }
        public void printTree(string order)
        {
            switch (order)
            {
                case "1":
                    preOrder();
                    break;
                case "2":
                    inOrder();
                    break;
                case "3":
                    postOrder();
                    break;
                default:
                    break;
            }
        }
        
        void preOrder()
        {
            while (parent != null)
            {
                Console.WriteLine(parent.item);
                if (parent.left != null)
                {
                    parent = parent.left;
                    preOrder();
                    if (parent.right != null)
                    {
                        parent = parent.right;
                        preOrder();
                    }
                }
                else if (parent.right != null)
                {
                    parent = parent.right;
                    preOrder();
                }
            }
        }
        void inOrder()
        {
            while (parent != null)
            {
                if (parent.left != null)
                {
                    parent = parent.left;
                    inOrder();
                    Console.WriteLine(parent.item);
                    if (parent.right != null)
                    {
                        parent = parent.right;
                        inOrder();
                    }
                }
                else
                    Console.WriteLine(parent.item);
                if (parent.right != null)
                {
                    parent = parent.right;
                    inOrder();
                }
            }
        }
        void postOrder()
        {
            while (parent != null)
            {
                if (parent.left != null)
                {
                    parent = parent.left;
                    postOrder();
                    if (parent.right != null)
                    {
                        parent = parent.right;
                        postOrder();
                    }
                }
                else
                    Console.WriteLine(parent.item);
                if (parent.right != null)
                {
                    parent = parent.right;
                    postOrder();
                }
                Console.WriteLine(parent.item);
            }
        }
    }
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;

            //string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            int[] months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            foreach (var mon in months)
            {
                if (root == null)
                    root = new Node(mon);
                else
                    root.addNode(mon);
            }

            Console.WriteLine("choose display order");
            Console.WriteLine("1. pre 2. in 3. post");
            string choice = Console.ReadLine();
            root.printTree(choice);

            Console.WriteLine("type month number to find");
            int monNum1 = Int16.Parse(Console.ReadLine());
            root.findNode(monNum1);

            Console.WriteLine("type month number to delete");
            int monNum2 = Int16.Parse(Console.ReadLine());
            root.deleteNode(monNum2);

            Console.ReadLine();
        }
    }
}
