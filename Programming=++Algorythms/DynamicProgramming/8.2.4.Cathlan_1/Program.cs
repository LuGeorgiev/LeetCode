namespace _8._2._4.Cathlan_1
{
    internal class Program
    {
        private struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }

            public int Y { get; set; }
        }

        private const int VerticesCount = 5;

        private static Point[] points = new Point[VerticesCount]
        { 
            new Point(1, 1), 
            new Point(5, -2), 
            new Point(10, 1), 
            new Point(7, 7), 
            new Point(1, 7), 
        };

        private static double[,] distances = new double[VerticesCount + 1, VerticesCount + 1];
        private static double[,] matrix = new double[VerticesCount + 1, VerticesCount + 1];


        static void Main(string[] args)
        {
            CalculateDistance();
            Solve();
            PrintResult();
            Console.Write($"Diagonals for the minimum cuts are: ");
            WriteCuts(1, VerticesCount - 1);
            Console.WriteLine();
        }

        //calculate all distances between verteces
        private static void CalculateDistance()
        {
            for (int i = 0; i < VerticesCount; i++)            
                for (int j = 0; j < VerticesCount; j++)
                    distances[i,j] = Math.Sqrt(
                        (points[i].X - points[j].X) * (points[i].X - points[j].X) +
                        (points[i].Y - points[j].Y) * (points[i].Y - points[j].Y));                
            
        }

        private static void Solve()
        {
            for (int j = 1; j < VerticesCount; j++)// basic cycle
            {
                for (int i = 1; i < VerticesCount - j; i++)
                {
                    matrix[i, i + j] = double.MaxValue;
                    for (int k = i; k < i + j; k++)
                    {
                        var temp = matrix[i, k] 
                            + matrix[k + 1, i + j] 
                            + distances[i - 1, k] 
                            + distances[k, i + j] 
                            + distances[i - 1, i + j];

                        if (temp < matrix[i, i + j]) // inprove current solve
                        {
                            matrix[i, i + j] = temp;
                            matrix[i + j, i] = k;
                        }
                    }
                }
            }
        }

        private static void PrintResult()
        {
            var perim = distances[0, VerticesCount - 1];
            for (int i = 0; i < VerticesCount; i++)
                perim += distances[i, i + 1];

            Console.WriteLine($"Distance with minimum distance is: {(matrix[1, VerticesCount - 1] - perim) / (float)2}");
        }

        private static void WriteCuts(int ll, int rr)
        {
            if (ll != rr)
            {
                WriteCuts(ll, (int)matrix[rr,ll]);
                WriteCuts((int)matrix[rr, ll] + 1, rr);
                if (ll != 1 || rr != VerticesCount - 1)
                {
                    Console.Write($"({ll}, {rr + 1})");
                }
            }
        }
    }
}