using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class TurnHandler : MonoBehaviour
    {
        private static TurnHandler _instance;
        private BotLogic _botLogic;
        public static TurnHandler GetInstance()
        {
            return (_instance == null) ? FindObjectOfType<TurnHandler>() : _instance;
        }

        private void Start()
        {
            _instance = this;
            _botLogic = new BotLogic();
        }

        void IncrementTurn()
        {
            GameState.CurrentTurn = (GameState.CurrentTurn + 1) % GameState.NumberOfPlayers;
        }

        public void TurnChanger()
        {
            if (GameState.IsOnline)
            {
                Console.Write("game is online, implement online game logic");
            }
            else
            {
                /*
                 * offline logic increases the turn and implements bots logic or enables board based if it's player's turn
                 */
                IncrementTurn();
                var isMyTurnNext = GameState.CurrentTurn == GameState.MyIndex;
                if (isMyTurnNext)
                {
                    BoardState.GetInstance().SetInteractable(!GameState.GameFinished);
                }
                else
                {
                    BoardState.GetInstance().SetInteractable(false);
                    if (!GameState.GameFinished)
                    {
                        TurnChangeRoutine();
                    }
                }

                if (GameState.GameFinished)
                {
                    StartCoroutine(RestartGame(3f));
                }
            }
        }
        
        

        void TurnChangeRoutine()
        {
            StartCoroutine(WaitAndDoWhatBotWouldDo(1f));
        }

        IEnumerator WaitAndDoWhatBotWouldDo(float time)
        {
            yield return new WaitForSeconds(time);
            _botLogic.TakeAction(GameState.Players[GameState.CurrentTurn]);
            TurnChanger();
        }
        
        IEnumerator RestartGame(float time)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}