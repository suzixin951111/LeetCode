using System;
using System.Collections.Generic;


//给定一个整数 n，生成所有由 1 ... n 为节点所组成的 二叉搜索树 。

namespace UniqueBinarySearchTreesII
{
//Definition for a binary tree node.
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


    internal class Program
    {
        public static void Main(string[] args)
        {
            new Program().GenerateTrees(3);
        }

        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
            {
                return new List<TreeNode>();
            }

            List<TreeNode>[][] cache = new List<TreeNode>[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                cache[i] = new List<TreeNode>[n + 1];
            }

            return GenerateTrees(1, n, cache);
        }

        public IList<TreeNode> GenerateTrees(int start, int end, IList<TreeNode>[][] cache)
        {
            IList<TreeNode> list = new List<TreeNode>();
            if (start > end)
            {
                list.Add(null);
            }
            else if (start == end)
            {
                list.Add(new TreeNode(start));
            }
            else if (cache[start][end] != null)
            {
                return cache[start][end];
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    foreach (var left in GenerateTrees(start, i - 1, cache))
                    {
                        foreach (var right in GenerateTrees(i + 1, end, cache))
                        {
                            var node = new TreeNode(i);
                            node.left = left;
                            node.right = right;
                            list.Add(node);
                        }
                    }
                }
            }
            
            if(start<=end)
                cache[start][end] = list;
            return list;
        }
    }
}