using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public static class BingoCheck
    {
        private static readonly int[][] Cases =
                {
                    new []{0,1,2,3,4}, new []{5,6,7,8,9}, new []{10,11,12,13,14},
                    new []{15,16,17,18,19}, new []{20,21,22,23,24},
                    new []{0,5,10,15,20}, new []{1,6,11,16,21}, new []{2,7,12,17,22},
                    new []{3,8,13,18,23}, new []{4,9,14,19,24},
                    new []{0,6,12,18,24}, new []{4,8,12,16,20}
                };
        
        public static bool CheckForBingo(Player player)
        {
            int total = 0;
            for (int i = 0; i < 12; i++)
            {
                bool isSubset = !Cases[i].Except(player.claimedPositions).Any();
                if (isSubset)
                {
                    total++;
                }
            }
            return total >= 5;
        }

        public static int OptimalNumberForBingo(List<int> available)
        {
            return 0;
        }
    }
}
