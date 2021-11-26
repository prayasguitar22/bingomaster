using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PlayerActions : MonoBehaviour
    {
        /*
         * when player interacts with the game's button, the functions gets executed
         * in offline mode, it updates the board of each player (disables the clicked value for all) then changes turn
         * todo : in online mode, own board's UI must be updated and value sent to server, turnChange is also initiated by server
         */
        public void OnButtonClicked()
        {
            var val = Int32.Parse(gameObject.GetComponentInChildren<Text>().text);
            // BoardState.GetInstance().ChangeButtonState(gameObject);
            Logic.UpdateBoardOfEachPlayer(val);

            TurnHandler.GetInstance().TurnChanger();
        }
    }
}
