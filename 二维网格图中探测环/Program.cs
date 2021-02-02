/**
 * 1559. 二维网格图中探测环

给你一个二维字符网格数组 grid ，大小为 m x n ，你需要检查 grid 中是否存在 相同值 形成的环。

一个环是一条开始和结束于同一个格子的长度 大于等于 4 的路径。对于一个给定的格子，你可以移动到它上、下、左、右四个方向相邻的格子之一，可以移动的前提是这两个格子有 相同的值 。

同时，你也不能回到上一次移动时所在的格子。比方说，环  (1, 1) -> (1, 2) -> (1, 1) 是不合法的，因为从 (1, 2) 移动到 (1, 1) 回到了上一次移动时的格子。

如果 grid 中有相同值形成的环，请你返回 true ，否则返回 false 。

 

示例 1：

输入：grid = [["a","a","a","a"],["a","b","b","a"],["a","b","b","a"],["a","a","a","a"]]
输出：true
解释：如下图所示，有 2 个用不同颜色标出来的环：

示例 2：

输入：grid = [["c","c","c","a"],["c","d","c","c"],["c","c","e","c"],["f","c","c","c"]]
输出：true
解释：如下图所示，只有高亮所示的一个合法环：

示例 3：

输入：grid = [["a","b","b"],["b","z","b"],["b","b","a"]]
输出：false

 

提示：

    m == grid.length
    n == grid[i].length
    1 <= m <= 500
    1 <= n <= 500
    grid 只包含小写英文字母。

题目地址 https://leetcode-cn.com/problems/detect-cycles-in-2d-grid/
 */


using System;
using System.Collections.Generic;

namespace 二维网格图中探测环
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public static bool ContainsCycle(char[][] grid)
        {
            //用一个无符号32位Int来表示当前轮次检查过的矩阵的位置,1~9位表示列 10~18位表示行 19~22位表示当前轮次检查过的4个方向
            //每个轮次检索到的位置用一个队列存储
            var checkQueue = new List<uint>();

            uint allDir = 0x3c0000; //4个方向位全为1的数，用于后续检测方向
            uint up = 0x40000; //上为1的数，用于后续检测方向
            uint down = 0x80000; //下为1的数，用于后续检测方向
            uint left = 0x100000; //左为1的数，用于后续检测方向
            uint right = 0x200000; //右为1的数，用于后续检测方向

            //当前检索的字符 '0'表示未检索任何字符
            char curChar = '0';

            //用一个无符号16位的Int数组的二进制位来作为矩阵存储检查过的位置
            ushort[] checkedFlag = new ushort[grid.Length];

            for (int i = 0; i < grid.Length; ++i)
            {
                var row = grid[i];
                for (int j = 0; j < row.Length; ++j)
                {
                    if (((1 << j) & checkedFlag[i]) != 0)
                        continue; //该位置已经检索过了

                    while (true)
                    {
                        
                        //处理边界情况，直接把检索不到的边界方向设为1
                        uint pos = (uint) (i << 8 | j);
                        if (i == 0)
                            pos |= up;
                        else if (i == grid.Length - 1)
                            pos |= down;

                        if (j == 0)
                            pos |= left;
                        else if (j == row.Length - 1)
                            pos |= right;

                        checkQueue.Add(pos);
                        curChar = grid[i][j];
                        var curCheckPos = pos;
                        while (true)
                        {
                            //按照上下左右的顺序依次检测

                            if ((pos & up) == 0 && grid[i - 1][j] == curChar && (checkedFlag[i] & (1 << j)) == 0)
                            {
                                pos = (uint) ((i - 1) << 8 | j);
                            }
                        }
                    }
                    
                    //未完待续...
                }
            }

            return false;
        }
    }
}