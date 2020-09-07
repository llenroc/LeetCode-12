﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Utils
{
    public class Populate
    {
        public static TreeNode Tree(int?[] nums)
        {
            return Tree(nums, new TreeNode(nums[0].Value), 0);
        }

        static TreeNode Tree(int?[] nums, TreeNode root, int i)
        {
            if (i < nums.Length && nums[i].HasValue)
            {
                TreeNode temp = new TreeNode(nums[i].Value);
                root = temp;
                root.left = Tree(nums, root.left, 2 * i + 1);
                root.right = Tree(nums, root.right, 2 * i + 2);
            }
            return root;
        }

        public static ListNode Node(int[] nums)
        {
            return Node(nums, new ListNode(nums[0]), 0);
        }

        static ListNode Node(int[] nums, ListNode root, int i)
        {
            if (i < nums.Length)
            {
                ListNode temp = new ListNode(nums[i]);
                root = temp;
                root.next = Node(nums, root.next, i + 1);
            }
            return root;
        }

        public static char[][] CharCharArray(char[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.Length / array.GetLength(0);
            char[][] charArray = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                charArray[i] = new char[columns];
                for (int j = 0; j < columns; j++)
                {
                    charArray[i][j] = array[i, j];
                }
            }

            return charArray;
        }

        public static int[][] IntIntArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.Length / array.GetLength(0);
            int[][] intArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                intArray[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    intArray[i][j] = array[i, j];
                }
            }

            return intArray;
        }

        public static RandomNode RdmNode(int?[,] array)
        {
            RandomNode root = GetNextNode(array, new RandomNode(array[0, 0].Value), 0);
            Dictionary<int, RandomNode> map = new Dictionary<int, RandomNode>();
            RandomNode node = root;
            while (node != null)
            {
                map.Add(node.val, node);
                node = node.next;
            }
            return GetRandomNode(root, array, map, 0);
        }

        static RandomNode GetNextNode(int?[,] array, RandomNode root, int i)
        {
            if (i < array.Length / 2)
            {
                RandomNode temp = new RandomNode(array[i, 0].Value);
                root = temp;
                root.next = GetNextNode(array, root.next, i + 1);
            }
            return root;
        }

        static RandomNode GetRandomNode(RandomNode root, int?[,] array, Dictionary<int, RandomNode> map, int i)
        {
            if (i < array.Length / 2)
            {
                RandomNode node = array[i, 1].HasValue && array[array[i, 1].Value, 0].HasValue && map.ContainsKey(array[array[i, 1].Value, 0].Value) ? map[array[array[i, 1].Value, 0].Value] : null;
                root.random = node;
                root.next = GetRandomNode(root.next, array, map, i + 1);
            }

            return root;
        }
    }
}
