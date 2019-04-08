using System;
using System.Collections.Generic;

namespace DA.Algorithms.PopularProblems
{
    class TowerOfHanoi
    {
        public static void TOHSorting (int number, char from, char to, char temp)
        {
            if (number < 1) return;
            TOHSorting (number - 1, from, temp, to);
            TOHSorting (number - 1, temp, to, from);
        }
    }
}
