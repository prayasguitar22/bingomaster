using System.Collections.Generic;
using System.Linq;
using Global;
using UnityEngine;

namespace Game
{
    /*
     * This is executed when GameScene starts-up
     * if the game started as offline, it creates bots and sets player index as 0 and first turn for the game
     * if the game started online, it sets up other players and sets player index as given by server and waits for this player turn
     */
    public class InitScript : MonoBehaviour
    {
        public void Awake()
        {
            // for now, in offline mode, number of players is calculated at random
            var num = Random.Range(2, 4);
            if (Constants.IsOfflineMode)
            {
                GameState.MyIndex = 0;
                GameState.IsOnline = false;
                GameState.NumberOfPlayers = num;
                GameState.Players = new Player[num];
                GameState.AllPositions = getAllPositions();
                CreatePlayers(num);
            }
            else
            {
                GameState.MyIndex = 0; // replace by server data
                GameState.IsOnline = true;
                GameState.NumberOfPlayers = 2; // replace by server data
                GameState.Players = new Player[num];
                CreatePlayers(num);
            }
            Debug.Log("InitScript runs now in online mode : " + !Constants.IsOfflineMode + " with " + num + " players");
        }

        /*
         * creates player objects as needed and assign them to GameState.Players
         */
        private void CreatePlayers(int num)
        {
            for (int i = 0; i < num; i++)
            {
                string myName = (i == 0) ? "me" : "bot" + i; // replace by server data
                List<int> myArrangement = getMyRandomNumbers(); // replace by server data or don't use
                Player player = new Player(i, myName, "avatar/0", myArrangement);
                GameState.Players[i] = player;
            }
        }
        
        /*
         * in offline mode, this provides the array of randomNumbers to fill-up the bingo board
         * in online mode, the randomNumbers are set-up using values from server
         */
        private List<int> getMyRandomNumbers()
        {
            int[] allInt = new int[25];
            for (int i = 0; i < 25; i++)
            {
                allInt[i] = i + 1;
            }

            for (int j = 0; j < 25; j++)
            {
                int val = Random.Range(0, 24);
                // swaps values in j and val
                (allInt[j], allInt[val]) = (allInt[val], allInt[j]);
            }
            return allInt.ToList();
        }

        private List<int> getAllPositions()
        {
            int[] allInt = new int[25];
            for (int i = 0; i < 25; i++)
            {
                allInt[i] = i;
            }

            return allInt.ToList();
        }
    }
}
