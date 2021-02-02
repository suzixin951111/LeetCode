// 给定一个仅包含 0 和 1 的二维二进制矩阵，找出只包含 1 的最大矩形，并返回其面积。

namespace MaximalRectangle
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public class Vector2
        {
            public int x;
            public int y;

            public Vector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public Vector2()
            {
                x = -1;
                y = -1;
            }

            public static bool operator ==(Vector2 v1, Vector2 v2)
            {
                return v1.x == v2.x && v1.y == v2.y;
            }

            public static bool operator !=(Vector2 v1, Vector2 v2)
            {
                return !(v1 == v2);
            }
        }

        public int MaximalRectangle(char[][] matrix)
        {
            //矩形缓存，存储到该坐标能组成最大的矩形的终点坐标
            Vector2[][] cache = new Vector2[matrix.Length][];
            for (int i = 0; i < cache.Length; i++)
                cache[i] = new Vector2[matrix[i].Length];
            return 0;
        }

        public bool IsRect(char[][] matrix, Vector2 start, Vector2 end, Vector2[][] cache)
        {
            bool isRect;
            
            if (start == end && matrix[start.x][start.y] == '1')
                isRect = true;
            var v = cache[start.x][start.y];
            if (v != null)
            {
                if (v.x >= end.x && v.y >= end.y)
                    isRect = true;
            }
            else
            {
                v = new Vector2();
                cache[start.x][start.y] = v;
            }

            var lastEndX = end.x > start.x ? end.x - 1 : end.x;
            var lastEndY = end.y > start.y ? end.y - 1 : end.y;

            


            return false;
        }
    }
}