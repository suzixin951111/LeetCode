/**
 * 给定一个二叉树，检查它是否是镜像对称的。

 

例如，二叉树 [1,2,2,3,4,4,3] 是对称的。

    1
   / \
  2   2
 / \ / \
3  4 4  3

 

但是下面这个 [1,2,2,null,3,null,3] 则不是镜像对称的:

    1
   / \
  2   2
   \   \
   3    3
 */


namespace 对称二叉树
{
    internal class Program
    {
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


        public static void Main(string[] args)
        {
        }

        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            return IsSymmetric(root.left, root.right);
        }

        public static bool IsSymmetric(TreeNode node1, TreeNode node2)
        {
            if (node1 != null && node2 != null)
            {
                return node1.val == node2.val && IsSymmetric(node1.left, node2.right) &&
                       IsSymmetric(node1.right, node2.left);
            }
            else if (node1 == null && node2 == null)
            {
                return true;
            }

            return false;
        }
    }
}