using System;
using System.Collections.Generic;
using System.Text;

namespace Translation
{
    public class BgMorseCode
    {
        private const int SYMBOLS_COUNT = 38;
        private const int MAX_WORD_LEN = 200;

        private static char[] symbols = new char[SYMBOLS_COUNT];
        private static string[] code = new string[SYMBOLS_COUNT];

        private static string toTranslate = "101001010";
        private static int[] translationVector = new int[MAX_WORD_LEN]; //translation
        private static int translationIndex = 0; //pN
        private static int translationsCount = 0; //total

        private static void InitializeCodeMap()
        {
            symbols[0]  = 'А';    code[0]  = "01";
            symbols[1]  = 'Б';    code[1]  = "1000";
            symbols[2]  = 'В';    code[2]  = "011";
            symbols[3]  = 'Г';    code[3]  = "110";
            symbols[4]  = 'Д';    code[4]  = "100";
            symbols[5]  = 'Е';    code[5]  = "0";
            symbols[6]  = 'Ж';    code[6]  = "0001";
            symbols[7]  = 'З';    code[7]  = "1100";
            symbols[8]  = 'И';    code[8]  = "00";
            symbols[9]  = 'Й';    code[9]  = "0111";
            symbols[10] = 'К';   code[10] = "101";
            symbols[11] = 'Л';   code[11] = "0100";
            symbols[12] = 'М';   code[12] = "11";
            symbols[13] = 'Н';   code[13] = "10";
            symbols[14] = 'О';   code[14] = "111";
            symbols[15] = 'П';   code[15] = "0110";
            symbols[16] = 'Р';   code[16] = "010";
            symbols[17] = 'С';   code[17] = "000";
            symbols[18] = 'Т';   code[18] = "1";
            symbols[19] = 'У';   code[19] = "001";
            symbols[20] = 'Ф';   code[20] = "0010";
            symbols[21] = 'Х';   code[21] = "0000";
            symbols[22] = 'Ц';   code[22] = "1010";
            symbols[23] = 'Ч';   code[23] = "1110";
            symbols[24] = 'Ш';   code[24] = "1111";
            symbols[25] = 'Щ';   code[25] = "1101";
            symbols[26] = 'Ю';   code[26] = "0011";
            symbols[27] = 'Я';   code[27] = "0101";
            symbols[28] = '1';   code[28] = "01111";
            symbols[29] = '2';   code[29] = "00111";
            symbols[30] = '3';   code[30] = "00011";
            symbols[31] = '4';   code[31] = "00001";
            symbols[32] = '5';   code[32] = "00000";
            symbols[33] = '6';   code[33] = "10000";
            symbols[34] = '7';   code[34] = "11000";
            symbols[35] = '8';   code[35] = "11100";
            symbols[36] = '9';   code[36] = "11110";
            symbols[37] = '0';   code[37] = "11111";
        }

        private static void PrintTranslation()
        {
            translationsCount++;
            for (int i = 0; i < translationIndex; i++)
            {
                Console.Write(symbols[i]);
            }
            Console.WriteLine();
        }

        private static void Decode()
        {
            Console.WriteLine("Following a list of all possible translations:");
            InitializeCodeMap();
            translationIndex = 0;
            
            NextLetter(0);
            
            Console.WriteLine($"Total number of different translations is: {translationsCount}");
        }

        private static void NextLetter(int index)
        {
            if (index == toTranslate.Length)
            {
                PrintTranslation();
                return;
            }

            for (int symbolIndex = 0; symbolIndex < SYMBOLS_COUNT; symbolIndex++)
            {
                //TODO check corerctness
                int len = code[symbolIndex].Length;
            }
        }
    }
}
