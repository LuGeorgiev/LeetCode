namespace SchoolProgram
{
    internal class Program
    {
        private const int TEACHER_COUNT = 3;
        private const int CLASSES_COUNT = 4;

        private static uint[,] classInfo = new uint[4, 3]
        {
            { 5, 5, 5 }, // class 1
            { 5, 5, 5 },
            { 5, 0, 0 },
            { 0, 0, 5 }, // class C
        };

        private static uint maxValue = uint.MaxValue;
        private static uint minimal = uint.MaxValue;//check this
        private static bool[,] usedClass = new bool[100, CLASSES_COUNT];
        
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < CLASSES_COUNT; j++)
                {
                    usedClass[i, j] = false;
                }
            }

            minimal = maxValue;
            Generate(TEACHER_COUNT, 0, 5, 0);// Error in source mX should be 5 (duration)
            Console.WriteLine($"Minimal program duration is: {minimal} hours.");
        }

        private static void Generate(uint teacher, uint level, uint mX, uint totalHours)
        {
            int i;
            if (totalHours >= minimal)
                return;

            if (teacher == TEACHER_COUNT) 
            {
                uint min = maxValue;
                for (i = 0; i < CLASSES_COUNT; i++)                
                    for (int j = 0; j < TEACHER_COUNT; j++)
                        if (classInfo[i,j] < min && classInfo[i,j] != 0)                        
                            min = classInfo[i, j];
                        
                if (min == maxValue)
                {
                    if (totalHours < minimal)
                    {
                        minimal = totalHours;
                    }
                }
                else
                {
                    Generate(0, level + 1, min, totalHours + min);
                }

                return;
            }

            /* определя клас за учителя teacher, с който той да проведе min часа */
            for (i = 0; i < CLASSES_COUNT; i++)
            {
                if (classInfo[i, teacher] > 0 && !usedClass[level,i])
                {
                    classInfo[i, teacher] -= mX;
                    usedClass[level, i] = true;
                    Generate(teacher + 1, level, mX, totalHours);
                    usedClass[level, i] = false;//backtracking
                    classInfo[i, teacher] += mX;
                }
            }

            /*Ако не е намерено присвояване за учителя, 
             * то не са му останали часове за преподаване */
            if (i == CLASSES_COUNT)
            {
                Generate(teacher + 1, level, mX, totalHours);
            }
        }
    }
}