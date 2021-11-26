using UnityEngine;

namespace Global
{
    /*
     * attaches DontDestroyOnLoad to the gameObject this is attached to
     * thus persisting the code when the scene changes
     */
    public class Dnd : MonoBehaviour
    {
        private static Dnd dndInstance;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            if (dndInstance == null)
            {
                dndInstance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
