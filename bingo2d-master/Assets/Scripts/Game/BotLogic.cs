using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Game
{
    public class BotLogic
    {
        public void TakeAction(Player me)
        {
            List<int> available = GameState.AllPositions.Except(me.claimedPositions).ToList();
            var randomPosition = SelectRandomPosition(available);
            var selectedPosition = available.ElementAt(randomPosition);
            var selectedValue = me.myBoard.ElementAt(selectedPosition);
            Logic.UpdateBoardOfEachPlayer(selectedValue);
        }

        int SelectRandomPosition(List<int> available)
        {
            return Random.Range(0, available.Count() - 1);
        }

        int SelectOptimalPosition(List<int> available)
        {
            return 0;
        }
    }
}