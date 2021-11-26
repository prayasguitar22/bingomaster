using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    /*
     * this class is responsible for changing scenes and quitting app 
     */
    public static class SceneChanger
    {
        public static void OpenGameScene()
        {
            SceneChangeFunction("Game");
        }

        public static void OpenMainScene()
        {
            SceneChangeFunction("Main");
        }

        public static void QuitApplication()
        {
            Application.Quit(0);
        }

        private static void SceneChangeFunction(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}