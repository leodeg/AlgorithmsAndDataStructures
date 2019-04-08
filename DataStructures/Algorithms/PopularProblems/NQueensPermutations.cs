using System;

namespace DA.Algorithms.PopularProblems
{
    public static class NQueensPermutations
    {
        public static void NQueens (int[] queens, int position, int chessBoardLength)
        {
            if (position == chessBoardLength)
            {
                return;
            }

            for (int i = 0; i < chessBoardLength; i++)
            {
                queens[position] = i;
                if (IsFeasible (queens, position))
                {
                    NQueens (queens, position + 1, chessBoardLength);
                }
            }
        }

        private static bool IsFeasible (int[] queens, int position)
        {
            for (int i = 0; i < position; i++)
            {
                if (queens[position] == queens[i] || Math.Abs (queens[position]) == Math.Abs (i - position))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
