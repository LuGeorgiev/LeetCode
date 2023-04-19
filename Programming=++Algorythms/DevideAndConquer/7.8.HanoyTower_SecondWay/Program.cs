using System.Threading.Channels;

namespace _7._8.HanoyTower_SecondWay
{
    internal class Program
    {
        private const int DISCS_COUNT = 6;

        private static Stack<int> a = new Stack<int>();
        private static Stack<int> b = new Stack<int>();
        private static Stack<int> c = new Stack<int>();
        private static int lastMovedDisc = -1;

        static void Main(string[] args)
        {
            LoadUpTower();
            HanoyTower();
        }

        private static void HanoyTower()
        {
            var towers = new[] { 'a', 'b', 'c' };
            var taskSolved = false;
            var areDisksEven = DISCS_COUNT % 2 == 0;

            while (true)
            {
                foreach (var tower in towers)
                {

                    for (int i = 0; i < 2; i++) 
                    {
                        var currentTowerDisk = GetDiskSize(tower);
                        if (currentTowerDisk == 0)
                            break;
                        if (currentTowerDisk == lastMovedDisc)
                            break;

                        var isPeekOdd = currentTowerDisk % 2 == 1;

                        if (areDisksEven)
                        {
                            if (isPeekOdd)
                            {
                                MoveDiskRight(tower);
                            }
                            else
                            {
                                MoveDiskLeft(tower);
                            }

                        }
                        else
                        {
                            if (isPeekOdd)
                            {
                                MoveDiskLeft(tower);
                            }
                            else
                            {
                                MoveDiskRight(tower);
                            }
                        }
                    }


                    if (c.Count == DISCS_COUNT)
                    {
                        taskSolved = true;
                        break;
                    }
                }

                if (taskSolved)
                    break;

            }
        }

        private static void LoadUpTower()
        {
            for (int i = DISCS_COUNT; i > 0; i--)
                a.Push(i);
        }

        private static void MoveDiskRight(char fromTowewr)
        {
            if (fromTowewr == 'a')
            {
                if (CanMove('a', 'b'))
                {
                    b.Push(a.Pop());
                    lastMovedDisc = b.Peek();
                    PrintMovement('A', 'B', b.Peek());
                }
            }
            else if (fromTowewr == 'b')
            {

                if (CanMove('b', 'c'))
                {
                    c.Push(b.Pop());
                    lastMovedDisc = c.Peek();
                    PrintMovement('B', 'C', c.Peek());
                }
            }
            else if (fromTowewr == 'c')
            {
                if (CanMove('c', 'a'))
                {
                    a.Push(c.Pop());
                    lastMovedDisc = a.Peek();
                    PrintMovement('C', 'A', a.Peek());
                }
            }
        }


        private static void MoveDiskLeft(char fromTower)
        {
            if (fromTower == 'a')
            {
                if (CanMove('a', 'c'))
                {
                    c.Push(a.Pop());
                    lastMovedDisc = c.Peek();
                    PrintMovement('A', 'C', c.Peek());
                }
            }
            else if (fromTower == 'b')
            {
                if (CanMove('b', 'a'))
                {
                    a.Push(b.Pop());
                    lastMovedDisc = a.Peek();
                    PrintMovement('B', 'A', a.Peek());
                }
            }
            else if (fromTower == 'c')
            {
                if (CanMove('c', 'b'))
                {
                    b.Push(c.Pop());
                    lastMovedDisc = b.Peek();
                    PrintMovement('C', 'B', b.Peek());
                }
            }
        }

        private static void PrintMovement(char from, char to, int diskSize) =>
            Console.WriteLine($"Dist moved from {from} to tower {to} with size: {diskSize}");

        private static bool CanMove(char fromTower, char toTower)
        {
            var diskFrom = GetDiskSize(fromTower);
            var disckTo = GetDiskSize(toTower);

            return diskFrom != 0 && (disckTo == 0 || diskFrom < disckTo); // can put disck on toTower
        }

        private static int GetDiskSize(char fromPylon) => fromPylon switch
        {
            'a' => a.Count == 0 ? 0 : a.Peek(),
            'b' => b.Count == 0 ? 0 : b.Peek(),
            'c' => c.Count == 0 ? 0 : c.Peek(),
            _ => throw new NotSupportedException()
        };
    }
}