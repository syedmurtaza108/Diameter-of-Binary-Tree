using System;
using System.Collections.Generic;

namespace Diameter_of_Binary_Tree
{
    class Program
    {
        static List<int> maxRoutes = new List<int>();
        static void Main(string[] args)
        {



            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(-7);
            root.right = new TreeNode(-3);
            root.right.left = new TreeNode(-9);
            root.right.right = new TreeNode(-3);
            root.right.right.left = new TreeNode(-4);
            root.right.left.right = new TreeNode(-7);
            root.right.left.right.left = new TreeNode(-6);
            root.right.left.right.left.left = new TreeNode(5);
            root.right.left.right.right = new TreeNode(-6);
            root.right.left.right.right.left = new TreeNode(9);
            root.right.left.right.right.left.right = new TreeNode(-2);
            root.right.left.left = new TreeNode(9);
            root.right.left.left.left = new TreeNode(6);
            root.right.left.left.left.right = new TreeNode(6);
            root.right.left.left.left.right.left = new TreeNode(-4);
            root.right.left.left.left.left = new TreeNode(0);
            root.right.left.left.left.left.right = new TreeNode(-1);
            Rec(root);
            maxRoutes.Sort();
            Console.WriteLine(maxRoutes[maxRoutes.Count - 1]);
        }

        static void Rec(TreeNode root)
        {
            if (root == null) return;
            maxRoutes.Add(DiameterOfBinaryTree(root));

            if (root.left != null) Rec(root.left);
            if (root.right != null) Rec(root.right);
        }

        static int DiameterOfBinaryTree(TreeNode root)
        {
            return MostLeftLeaf(root, true) + MostRightLeaf(root, true);
        }

        static int MostLeftLeaf(TreeNode root, Boolean isRoot)
        {
            if (root == null) return 0;

            if (root.right != null && !isRoot)
                return 1 + Math.Max(MostLeftLeaf(root.right!, false), MostRightLeaf(root.right!, false));

            if (root.left == null)
            {
                return 0;
            }


            return 1 + Math.Max(MostLeftLeaf(root.left!, false), MostRightLeaf(root.left!, false));
        }

        static int MostRightLeaf(TreeNode root, Boolean isRoot)
        {
            if (root == null) return 0;
            if (root.left != null && !isRoot)
                return 1 + Math.Max(MostLeftLeaf(root.left!, false), MostRightLeaf(root.left!, false));

            if (root.right == null)
            {
                return 0;
            }

            return 1 + Math.Max(MostLeftLeaf(root.right!, false), MostRightLeaf(root.right!, false));
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
