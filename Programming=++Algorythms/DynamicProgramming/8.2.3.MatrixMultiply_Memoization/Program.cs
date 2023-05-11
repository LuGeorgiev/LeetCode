namespace _8._2._3.MatrixMultiply_Memoization
{
    internal class Program
    {
        private class Order
        {
            public int Left { get; set; }

            public int Right { get; set; }
        }

        private const int MatrixCount = 9;
        private static int[] matrixDimentions = { 12, 13, 35, 3, 34, 2, 21, 10, 21, 6 };
        private static long[,] matrix = new long[MatrixCount + 1, MatrixCount + 1];
        private static Order[] order = new Order[(MatrixCount + 1) * (MatrixCount + 1)]; // order of matrix multiplications
        private static int count; 

        static void Main(string[] args)
        {
            Solve();
            count = 0;
            BuildOrder(1, MatrixCount);
            Console.WriteLine($"Minimum Multiplication number is {matrix[1,MatrixCount]}");
            PrintMatrix();
            Console.WriteLine();
            PrintMultiplicxationPlan();
            Console.WriteLine("\nOrder of multiplication of the matrixes:");
            GetOrder(1, MatrixCount);
            Console.WriteLine();
        }

        private static void GetOrder(int ll, int rr)
        {
            if (ll == rr)
            {
                Console.Write($"M{ll}");
            }
            else 
            {
                Console.Write("(");
                GetOrder(ll, (int)matrix[rr, ll]);
                Console.Write("*");
                GetOrder((int)matrix[rr, ll] + 1, rr);
                Console.Write(")");
            }
        }

        private static void PrintMultiplicxationPlan()
        {
            Console.WriteLine("Plan for matrix multiplication:");
            for (int i = 0; i < count; i++)
            {
                if (order[i]?.Left == order[i]?.Right)
                    Console.WriteLine($"L[{i}] = M{order[i].Left}");
                else
                    Console.WriteLine($"L[{i}] = L[{order[i].Left}] * L[{order[i].Right}]");
            }
        }

        private static int BuildOrder(int ll, int rr)//forms algorith for matrix multiplication
        {
            int ret = count++;
            if (ll < rr) 
            {
                order[ret].Left = BuildOrder(ll, (int)matrix[rr,ll]);
                order[ret].Right = BuildOrder((int)matrix[rr,ll] + 1, rr);
            }
            else
            {
                order[ret].Left = ll;
                order[ret].Right = rr;
            }

            return ret;
        }

        private static void Solve()
        {
            //initialization
            for (int i = 0; i < order.Length; ++i)
                order[i] = new Order();
            for (int i = 1; i <= MatrixCount; i++)
                matrix[i,i] = 0;

            for (int j = 1; j <= MatrixCount; j++)
            {
                for (int i = 1; i <= MatrixCount - j; i++)
                {
                    matrix[i, i + j] = long.MaxValue;
                    for (int k = i; k < i + j; k++)
                    {
                        var temp = matrix[i, k] 
                            + matrix[k + 1, i + j] 
                            + matrixDimentions[i - 1] * matrixDimentions[k] * matrixDimentions[i + j];

                        //improve current decision
                        if (temp < matrix[i, i + j])
                        {
                            matrix[i, i+j] = temp;
                            matrix[i + j, i] = k;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix() //Displays matrix of teh minimus
        {
            Console.WriteLine("Matrix of the minimus:");
            for (int i = 1; i <= MatrixCount; i++)
            {
                for (int j = 1; j <= MatrixCount; j++)
                {
                    Console.Write("{0,8}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}