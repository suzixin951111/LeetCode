/**
 * 请根据每日 气温 列表，重新生成一个列表。对应位置的输出为：要想观测到更高的气温，至少需要等待的天数。如果气温在这之后都不会升高，请在该位置用 0 来代替。

例如，给定一个列表 temperatures = [73, 74, 75, 71, 69, 72, 76, 73]，你的输出应该是 [1, 1, 4, 2, 1, 1, 0, 0]。

提示：气温 列表长度的范围是 [1, 30000]。每个气温的值的均为华氏度，都是在 [30, 100] 范围内的整数。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/daily-temperatures
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */

using System;

namespace Daily_Temperatures
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var temperatures = new int[] {73, 74, 75, 71, 69, 72, 76, 73};
            var ret = DailyTemperatures(temperatures);
            foreach (var r in ret)
            {
                Console.Write(r + "  ");
            }
        }

        //本题除了该思路还可以使用递减栈
        public static int[] DailyTemperatures(int[] T)
        {
            var ret = new int[T.Length];

            for (int i = T.Length - 1; i >= 0; --i)
            {
                if (i == T.Length - 1)
                {
                    ret[i] = 0;
                }
                else
                {
                    var j = i + 1;
                    while (ret[j] > 0 && T[j] <= T[i])
                    {
                        j = j + ret[j];
                    }

                    if (T[j] <= T[i])
                        ret[i] = 0;
                    else
                        ret[i] = j - i;
                }
            }

            return ret;
        }
    }
}