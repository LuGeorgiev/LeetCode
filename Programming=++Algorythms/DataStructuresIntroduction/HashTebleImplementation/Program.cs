using System;

namespace HashTebleImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable<int, string>();
            hashTable.Add(1, "11");
            hashTable.Add(2, "22");
            hashTable.Add(3, "33");
            hashTable.Add(4, "44");
            hashTable.Add(5, "55");
            hashTable.Add(7, "77");
            hashTable.Add(8, "77");
            hashTable.Add(9, "77");
            hashTable.Add(10, "77");
            hashTable.Add(11, "77");
            hashTable.Add(12, "77");
            hashTable.Add(13, "77");
            hashTable.Add(14, "77");
            hashTable.Add(15, "77");
            hashTable.Add(16, "77");
            hashTable.Add(17, "77");
            hashTable.Add(18, "77");
            hashTable.Add(19, "77");
            hashTable.Add(155, "77");
            hashTable.Add(122, "77");
            hashTable.Add(134, "77");
            hashTable.Add(571, "77");
            hashTable.Add(164, "77");
            hashTable.Add(321, "77");
            hashTable.Remove(3);
            hashTable[6] = "66";
            hashTable[4] = "444";

            Console.WriteLine(hashTable[5]);
            foreach (var key in hashTable)
            {
                Console.WriteLine($"{key} -> {hashTable[key]}");
            }
        }
    }
}
