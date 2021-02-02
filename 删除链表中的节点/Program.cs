/**
 * 请编写一个函数，使其可以删除某个链表中给定的（非末尾）节点。传入函数的唯一参数为 要被删除的节点 。
 */

namespace 删除链表中的节点
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public class Solution
        {
            public void DeleteNode(ListNode node)
            {
                var tmp = node.next.val;
                node.next.val = tmp;
                node.val = tmp;
                node.next = node.next.next;
            }
        }
    }
}