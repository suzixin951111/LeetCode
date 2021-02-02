//给定一个整数 n，求以 1 ... n 为节点组成的二叉搜索树有多少种？

using System;

namespace UniqueBinarySearchTrees
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Program().NumTrees(3));
        }

        public int NumTrees(int n)
        {
            //这个缓存还可以优化，缓存只和长度有关和内容无关，可以优化成一个一维数组
            
            int[][] cache = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                cache[i] = new int[n + 1];
            }

            return NumTrees(1, n, cache);
        }

        public int NumTrees(int start, int end, int[][] cache)
        {
            if (start > end)
                return 1;
            if (cache[start][end] > 0)
                return cache[start][end];

            var num = 0;
            if (start == end)
                num = 1;
            else if (start == end - 1)
                num = 2;
            else
            {
                for (int i = start; i <= end; i++)
                {
                    num += (NumTrees(start, i - 1, cache) * NumTrees(i + 1, end, cache));
                }
            }

            cache[start][end] = num;
            return num;
        }
    }
}