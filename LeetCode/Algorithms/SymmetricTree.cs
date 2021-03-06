﻿using LeetCode.Utils;
using System;

namespace LeetCode.Algorithms
{
    public class SymmetricTree
    {
        /* LeetCode #101. Symmetric Tree
         * Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).*/
        public static void RunCode()
        {
            TreeNode node = Populate.TreeNode(new int?[] { 1, 2, 2, 3, 4, 4, 3 });
            Console.WriteLine($"    SymmetricTree 1: {IsSymmetricTree(node)}");
            node = Populate.TreeNode(new int?[] { 1, 2, 2, null, 3, null, 3 });
            Console.WriteLine($"    SymmetricTree 2: {IsSymmetricTree(node)}");
        }

        static bool IsSymmetricTree(TreeNode node)
        {
            if (node == null)
            {
                return true;
            }

            return IsSymmetricTree(node.left, node.right);
        }

        static bool IsSymmetricTree(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
            {
                return left == right;
            }

            if (left.val != right.val)
            {
                return false;
            }

            return IsSymmetricTree(left.left, right.right) && IsSymmetricTree(left.right, right.left);
        }
    }
}
