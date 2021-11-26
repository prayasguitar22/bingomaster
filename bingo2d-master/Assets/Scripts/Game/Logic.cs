using UnityEngine;

namespace Game
{
    public class Logic
    {
        public static void UpdateBoardOfEachPlayer(int value)
        {
            var players = GameState.Players;
            var currentTurn = GameState.CurrentTurn;
            var numOfPlayers = players.Length;
            for (int i = currentTurn; i < (currentTurn + numOfPlayers); i++)
            {
                var index = i % numOfPlayers;
                bool bingo = players[index].UpdateDataInBoard(value);
                if (bingo)
                {
                    Debug.Log("bingo : " + players[index].name);
                    BoardState.GetInstance().SetInteractable(false);
                    GameState.GameFinished = true;
                    if (!GameState.GameFinished)
                    {
                        GameState.Winner = players[index];
                    }
                    /*
                     * todo: display game over panel
                     * panel should consist of option to restart game or goto home
                     * if offline, reloading the scene restarts the match :
                     * SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                     * if online, reloading the scene with server obtained value for rematch
                     */
                }
            }
        }
        
    }
}