//给你一个括号字符串 s ，它只包含字符 '(' 和 ')' 。一个括号字符串被称为平衡的当它满足：
//
//任何左括号 '(' 必须对应两个连续的右括号 '))' 。
//左括号 '(' 必须在对应的连续两个右括号 '))' 之前。
//
//比方说 "())"， "())(())))" 和 "(())())))" 都是平衡的， ")()"， "()))" 和 "(()))" 都是不平衡的。
//
//你可以在任意位置插入字符 '(' 和 ')' 使字符串平衡。
//
//请你返回让 s 平衡的最少插入次数。
//
//来源：力扣（LeetCode）
//链接：https://leetcode-cn.com/problems/minimum-insertions-to-balance-a-parentheses-string
//著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace 平衡括号字符串的最少插入次数
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s1 = ")))))))";
            var s2 = "))())(";
            var s3 = "(()))";
            var s4 = "())";
            var s5 = "(()))(()))()())))";
            Console.WriteLine(MinInsertions(s1));
            Console.WriteLine(MinInsertions(s2));
            Console.WriteLine(MinInsertions(s3));
            Console.WriteLine(MinInsertions(s4));
            Console.WriteLine(MinInsertions(s5));
        }

        public static int MinInsertions(string s)
        {
            int insertions = 0;
            int leftCount = 0;
            int length = s.Length;
            int index = 0;
            while (index < length) {
                char c = s[index];
                if (c == '(') {
                    leftCount++;
                    index++;
                } else {
                    if (leftCount > 0) {
                        leftCount--;
                    } else {
                        insertions++;
                    }
                    if (index < length - 1 && s[index + 1] == ')') {
                        index += 2;
                    } else {
                        insertions++;
                        index++;
                    }
                }
            }
            insertions += leftCount * 2;
            return insertions;
        }
    }
}