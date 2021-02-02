//给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

using System;

namespace LongestPalindromicSubstring
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Program().LongestPalindrome("babsdfhggsssbssaasd"));
        }

        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            //回文串标记矩阵，0：未检查  1：不是回文  2：是回文
            byte[][] cache = new byte[s.Length][];
            for (int i = 0; i < cache.Length; i++)
                cache[i] = new byte[s.Length];

            int start = 0, end = 0;

            for (int i = 0; i < s.Length - 1; ++i)
            {
                if (s.Length - i < end - start)
                    break;
                for (int j = i + 1; j < s.Length; ++j)
                {
                    if (j - i < end - start)
                        continue;
                    if (IsPalindrome(s, i, j, cache))
                    {
                        if (j - i > end - start)
                        {
                            start = i;
                            end = j;
                        }
                    }
                }
            }

            return s.Substring(start, end - start + 1);
        }

        public bool IsPalindrome(string s, int start, int end, byte[][] cache)
        {
            bool isPalindrome;
            if (start == end)
                isPalindrome = true;
            else if (start == end - 1 && s[start] == s[end])
                isPalindrome = true;
            else
            {
                var c = cache[start][end];
                if (c == 0)
                    isPalindrome = s[start] == s[end] && IsPalindrome(s, start + 1, end - 1, cache);
                else if (c == 1)
                    isPalindrome = true;
                else
                    isPalindrome = false;
            }

            cache[start][end] = (byte) (isPalindrome ? 1 : 2);

            return isPalindrome;
        }
    }
}