using Global;
using UnityEngine;

namespace Menu
{
    /*
     * class includes codes to be executed by menu buttons of gameScene
     */
    public class GameMenuActions : MonoBehaviour
    {
        
        /*
        * while on game scene, this function leaves the gameScene and return to mainScene
        * todo : if online game, this function must emit event to leave room
        * the follow-up actions should be handled from SocketHandler's listeners
        */
        public void LeaveCurrentGame()
        {
            // todo : reset gameState to default
            SceneChanger.OpenMainScene();
        }
    }
}
