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
            var checkedMatrix = new byte[grid.Length][];
            var colCount = (int) Math.Ceiling(grid.Length / 8f);
            for (int i = 0; i < checkedMatrix.Length; ++i)
            {
                checkedMatrix[i] = new byte[colCount];
            }

            var IsChceked = new Func<int, int, bool>((row, col) =>
            {
                return ((1 << (col % 8)) & checkedMatrix[row][col / 8]) > 0;
            });

            var SetChceked = new Action<int, int>((row, col) =>
            {
                var realCol = col / 8;
                var idx = col % 8;
                checkedMatrix[row][realCol] |= (byte) (1 << idx);
            });


            var checkStack = new List<int>();
            for (int i = 0; i < grid.Length; i++)
            {
                var curRow = grid[i];
                for (int j = 0; j < curRow.Length; j++)
                {
                    if (IsChceked(i, j))
                        continue;

                    //用高16位表示行，低16位表示列
                    var pos = i << 16 | j;
                    checkStack.Add(pos);
                    while (checkStack.Count > 0)
                    {
                        var curPos = checkStack[checkStack.Count - 1];
                        var row = curPos >> 16;
                        var col = curPos & 0x0000ffff;
                        SetChceked(row, col);
                        //依次检查上 下 左 右
                        if (row > 0 && !IsChceked(row - 1, col) && grid[row - 1][col] == grid[row][col])
                        {
                            checkStack.Add(row - 1 << 16 | col);
                            break;
                        }

                        if (row < grid.Length - 1 && !IsChceked(row + 1, col) && grid[row + 1][col] == grid[row][col])
                        {
                            checkStack.Add(row + 1 << 16 | col);
                            break;
                        }

                        if (col > 0 && !IsChceked(row, col - 1) && grid[row][col - 1] == grid[row][col])
                        {
                            checkStack.Add(row << 16 | (col - 1));
                            break;
                        }

                        if (col < colCount - 1 && !IsChceked(row, col + 1) && grid[row][col + 1] == grid[row][col])
                        {
                            checkStack.Add(row << 16 | (col + 1));
                            break;
                        }
                        
                        // TODO
                    }
                }
            }

            return false;
        }
    }
}