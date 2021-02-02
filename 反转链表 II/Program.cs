/**
 * 反转从位置 m 到 n 的链表。请使用一趟扫描完成反转。

说明:
1 ≤ m ≤ n ≤ 链表长度。

示例:

输入: 1->2->3->4->5->NULL, m = 2, n = 4
输出: 1->4->3->2->5->NULL

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/reverse-linked-list-ii
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */


namespace 反转链表_II
{
    internal class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }


        public static void Main(string[] args)
        {
        }

        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (m == n)
                return head;

            ListNode prev = null;
            ListNode curNode = head;
            ListNode prevStart = null;
            ListNode end = null;
            ListNode start = null;
            for (int i = 1; i <= n; ++i)
            {
                if (i == m - 1)
                    prevStart = curNode;

                if (i == m)
                    start = curNode;

                if (i == n) 
                {
                    start.next = curNode.next;
                    if (prevStart == null)
                    {
                        //从第一个节点开始反转
                        curNode.next = prev;
                        return curNode;
                    }

                    prevStart.next = curNode;
                    curNode.next = prev;
                    return head;
                }

                if (i > m)
                {
                    var next = curNode.next;
                    curNode.next = prev;
                    prev = curNode;
                    curNode = next;
                }
                else
                {
                    prev = curNode;
                    curNode = curNode.next;
                }
            }

            return head;
        }
    }
}