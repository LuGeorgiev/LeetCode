using System.Xml.Serialization;

namespace ExpressionAssignability
{
    internal class Program
    {
        // Expression (X1 || X4) && (!X1 || X2) && (X1 || !X3) && (!X2 || X3 || !X4) && (!X1 || !X2 || !X3)

        private const int BOOL_COUNT = 4;
        private const int DISJUNCT_COUNT = 5;

        private static List<int>[] expression = new List<int>[DISJUNCT_COUNT]
        {
            new List<int>(){  1,  4 },
            new List<int>(){ -1,  2 },
            new List<int>(){  1, -3 },
            new List<int>(){ -2,  3, -4 },
            new List<int>(){ -1, -2, -3 },
        };
        private static List<bool> currentValues = Enumerable.Repeat(false, 100).ToList();


        // NOT WORKING N.B.!!!!
        static void Main(string[] args)
        {
            Assign(0);
        }

        private static void PrintAssignemnt()
        {
            Console.Write("Exptression is assignable for values: ");
            for (int i = 0; i < BOOL_COUNT; i++)
            {
                Console.Write($"X{i + 1} = {currentValues[i]}");
            }
            Console.WriteLine();
        }

        private static void Assign(int index)
        {
            if (index == BOOL_COUNT )
            {
                if (IsAssignable())
                {
                    PrintAssignemnt();
                    return;
                }
            }

            //Out of range
            currentValues[index] = true;
            Assign(index + 1);

            currentValues[index] = false;
            Assign(index + 1);

        }

        //At least one literal has to be TRUE in each DISJUNCT
        private static bool IsAssignable()
        {
            for (int i = 0; i < DISJUNCT_COUNT; i++)
            {
                var ok = false;

                for (int j = 0; j < expression[i].Count; j++)
                {
                    var value = expression[i][j];

                    if ((value > 0) && (true == currentValues[value - 1]))
                    {
                        ok = true;
                        break;
                    }
                    if ((value < 0) && (false == currentValues[-value  - 1]))
                    {
                        ok = true;
                        break;
                    }
                }

                if (!ok)
                    return false;
            }

            return true;
        }
    }
}