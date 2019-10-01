using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BisectionAlgorithm
{
    public class Formulas
    {
        public static int startingPoint = 1; //starting point
        public static int highestValue = 100;
        public static int middle;
        public static List<int> PopulateList(int topValue)
        {
            List<int> numberRange = Enumerable.Range(startingPoint, topValue).ToList();
            return numberRange;
        }
        public static int FindMiddle(int startpoint, int endingpoint)
        {
            middle = (startpoint + endingpoint) / 2;
            return middle;
        }
        public static int ComputerPicksRandom(List<int> rangeOfNums)
        {
            int randomValue;
            Random r = new Random();
            randomValue = rangeOfNums[r.Next(startingPoint, highestValue)];
            return randomValue;
        }
        public static void PopulateUpperHalf(out List<int> rangeOfNums)
        {
            List<int> newRangeOfNums = new List<int>();
            for (int i = middle + 1; i <= highestValue; i++)
            {
                newRangeOfNums.Add(i);
            }
            rangeOfNums = newRangeOfNums;
        }
        public static void PopulateLowerHalf(out List<int> rangeOfNums)
        {
            List<int> newRangeOfNums = new List<int>();
            for (int i = startingPoint; i < middle; i++)
            {
                newRangeOfNums.Add(i);
            }
            rangeOfNums = newRangeOfNums;
        }
    }
}
