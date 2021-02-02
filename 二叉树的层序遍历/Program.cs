/**
 * 给你一个二叉树，请你返回其按 层序遍历 得到的节点值。 （即逐层地，从左到右访问所有节点）。

 

示例：
二叉树：[3,9,20,null,null,15,7],

    3
   / \
  9  20
    /  \
   15   7

返回其层序遍历结果：

[
  [3],
  [9,20],
  [15,7]
]

 */


using System;
using System.Collections.Generic;

namespace 二叉树的层序遍历
{
    internal class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }


        public static void Main(string[] args)
        {
        }
        
        //该问题还可以使用BFS求解

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var ret = new List<IList<int>>();
            LevelOrder(root, ret, 0);
            return ret;
        }

        public static void LevelOrder(TreeNode node, IList<IList<int>> ret, int layer)
        {
            if (node == null)
                return;
            while (ret.Count <= layer)
            {
                ret.Add(new List<int>());
            }

            ret[layer].Add(node.val);
            LevelOrder(node.left, ret, layer + 1);
            LevelOrder(node.right, ret, layer + 1);
        }
    }
}