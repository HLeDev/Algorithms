using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Nodes
    {
        //Binary Tree = Each node has no more than 2 child nodes
        //Binary Search Tree = adds contrains of orders, items on the left must be less than parent
        //items on the right must be greater than parent.

        //Best case search time is O(log(n)) - linear
        //Worse case is O(n) 

        //Instead of next node reference, we'll create nodes to left and right

        public Nodes Left { get; set; }
        public Nodes Right { get; set; }
        public int Data { get; set; }

        //Tree Traversal:

        //Inorder : Recursively visit left subtree, then root, then recursivley right : 9 7 10 6 8
        //9 is left of 7 and 10 is right of 7
        //7 is left of 6 (root)
        //8 is right of 6 (root)

        //Preorder : visit root, then left sub tree, then recursively right : 6 7 9 10 8
        //6 is root
        //7 is left sub of root
        //9 and 10 is sub of 7
        //8 is right of root

        //Postorder : V recurse the left subtree, then right, then root last : 9 10 7 8 6
        //9 and 10 is sub of 7,
        //7 is left of root, then 8 is right of root
        //then root of 6

        //Preorder = explores roots before leaves
        //Postorder = explores leaves before roots
        //Inorder = explores data sequentially

        
    }
    public class BinarySearchTree
    {
        public static Boolean Contains(Nodes root, int value)
        {
            if (root == null)
            {
                return false;
            }

            else if(value < root.Data)
            {
                return Contains(root.Left, value);

            }
            else if (value > root.Data)
            {
                return Contains(root.Right, value);
            }
            else
            {
                return true;
            }
        }


        public static Nodes Insert(Nodes root, int value)
        {
            if (root == null)
            {
                root = new Nodes();
                root.Data = value;
                return root;
            }
            else
            {
                if (value < root.Data)
                {
                    root.Left = Insert(root.Left, value);
                }
                else if (value > root.Data)
                {
                    root.Right = Insert(root.Right, value);
                }
            }
            return root;
        }
    }

    public class BinaryTrees
    {
        public static void preOrderTraversal(Nodes root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.Data + " - ");
            preOrderTraversal(root.Left);
            preOrderTraversal(root.Right);
        }

        public static void inOrderTraversal(Nodes root)
        {
            if (root == null)
            {
                return;
            }
            inOrderTraversal(root.Left);
            Console.WriteLine(root.Data + " - ");
            inOrderTraversal(root.Right);
        }

        public static void postOrderTraversal(Nodes root)
        {
            if (root == null)
            {
                return;
            }
            postOrderTraversal(root.Left);
            postOrderTraversal(root.Right);
            Console.WriteLine(root.Data + " - ");

        }
    }
}
