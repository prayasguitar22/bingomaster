using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    /*
     * When scene starts, the player's board should be filled with his data
     * and current turn is set to player at index 0
     */
    public class InitBoard : MonoBehaviour
    {
        public GameObject board;
        private void Start()
        {
            FillMyBoard();
            GameState.CurrentTurn = 0;
            GameState.GameFinished = false;
        }

        private void FillMyBoard()
        {
            var myIndex = GameState.MyIndex;
            List<int> myNumbers = GameState.Players[myIndex].myBoard;
            for (int i = 0; i < 25; i++)
            {
                board.transform.GetChild(i).gameObject.GetComponentInChildren<Text>().text = myNumbers[i].ToString();
            }
            /*
             * todo : in online mode, disable the board if (myIndex != 0), player shouldn't be able to interact if it's not his turn
             */
        }
    }
    
}
