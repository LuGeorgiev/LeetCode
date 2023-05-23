using System.Reflection.Metadata;

namespace _8._2._5.OptimalBinarySearchTree
{
    internal class Program
    {
        private const int Numbers = 7;
        private static readonly int[] occurencies = { 2, 7, 1, 3, 4, 6, 5 };
        private static readonly int[,] matrix = new int[Numbers + 2, Numbers + 2];

        static void Main(string[] args)
        {
            Solve();
            Console.WriteLine($"Max length of weighted inner path is: {matrix[1,Numbers]}");
            PrintMatrix();
            Console.WriteLine("The optimal tree is:");
            Getorder(1, Numbers, 0);
        }

        /* Build the optimal Binary sreach tree */
        private static void Solve()
        {
            //initialize
            for (int i = 1; i <= Numbers; i++)
            {
                matrix[i, i] = occurencies[i - 1];
                matrix[i, i - 1] = 0;
            }
            matrix[Numbers + 1, Numbers] = 0;

            //main cycle
            for (int j = 1; j <= Numbers - 1; j++)
            {
                for (int i = 1; i <= Numbers - j; i++)
                {
                    matrix[i, i + j] = int.MaxValue;
                    for (int k = i; k <= i + j; k++)
                    {
                        //inprove current scenario
                        var temp = matrix[i, k - 1] + matrix[k + 1, i + j];
                        if (temp < matrix[i, i + j])
                        {
                            matrix[i, i + j] = temp;
                            matrix[i + j + 1, i] = k;
                        }
                    }

                    for (int k = i - 1; k < i + j; k++)
                        matrix[i, i + j] += occurencies[k];                    
                }
            }
        }

        private static void PrintMatrix()
        {
            for(int i = 1; i <= Numbers + 1; i++) 
            {
                Console.WriteLine();
                for (int j = 1; j <= Numbers; j++)
                {
                    Console.Write("{0,5}", matrix[i,j]);
                }
            }
            Console.WriteLine();
        }

        private static void Getorder(int ll, int rr, int h)
        {
            if (ll > rr)
                return;
            if (ll == rr)
            {
                for (int i = 0; i < h ; i++)                 
                    Console.Write("   ");

                Console.WriteLine("d{0}", rr);
            }
            else
            {
                Getorder(ll, matrix[rr + 1, ll] - 1, h + 1);
                for (int i = 0;i < h ; i++)
                    Console.Write("   ");

                Console.WriteLine("d{0}", matrix[rr + 1, ll]);
                Getorder(matrix[rr + 1, ll] + 1, rr, h + 1);
            }
        }
    }
}