using Game;
using Global;
using Socket;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    /*
     * class includes codes to be executed by menu buttons of mainScene
     */
    public class MainMenuActions : MonoBehaviour
    {
        /*
         * when player wants to play offline, ie with bots
         * this functions sets IsOfflineMode true so that the offline logic and bots will be implemented in gameScene
         */
        public void PlayWithBot()
        {
            Debug.Log("play with bots clicked");
            Constants.IsOfflineMode = true;
            SceneChanger.OpenGameScene();
        }

        /*
         * when player wants to play online, this function emits event to playPublic to server
         * follow-up actions are handled from SocketHandler's listeners
         * this functions sets IsOfflineMode false so that the offline logic and bots will be implemented in gameScene
         */
        public void PlayOnline()
        {
            SocketEmitter.GetInstance().PlayPublic();
            Debug.Log("online button clicked");
            Constants.IsOfflineMode = false;
            // SceneChanger.OpenGameScene();
        }

        /*
         * quit the application completely
         * todo: close socketManager
         */
        public void QuitGame()
        {
            if (GameState.IsOnline)
            {
                SceneChanger.QuitApplication();
            }
        }
    }
}
