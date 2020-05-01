namespace InterpolationSerachAlgorithm
{
    public static class InterpolationSerach
    {
        public static int Search(this int[] orderedArray, int valueTosearch)

        {
            return InterplSearch(orderedArray, valueTosearch, 0, orderedArray.Length - 1);
        }

        private static int InterplSearch(int[] orderedArray, int valueTosearch, int startIndex, int endIndex)
        {
            if (orderedArray[startIndex].Equals(orderedArray[endIndex]))
            {
                if (orderedArray[startIndex].Equals(valueTosearch))
                {
                    return startIndex;
                }
                else
                {
                    return -1;
                }

            }
            var coef = (float)(valueTosearch - orderedArray[startIndex]) / (orderedArray[endIndex] - orderedArray[startIndex]);

            if (coef < 0 || coef > 1)
            {
                return -1;
            }

            var midIndex = (int)(startIndex + coef * (endIndex - startIndex) + 0.5);

            if (valueTosearch < orderedArray[midIndex])
            {
                InterplSearch(orderedArray, valueTosearch, startIndex, midIndex - 1);
            }
            else if (valueTosearch < orderedArray[midIndex])
            { 
                InterplSearch(orderedArray, valueTosearch, midIndex + 1, endIndex);
            }
            else
            {
                return midIndex;
            }

            return -1;
        }
    }
}
