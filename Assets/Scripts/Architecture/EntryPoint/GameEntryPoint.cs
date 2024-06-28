using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Architecture.EntryPoint
{
    public sealed class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private UILoadingScreenView _uiLoadingScreen;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStart()
        {
            Application.targetFrameRate = 60;
            //For mobile game
            //Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint() {
            CreateLoadingScreen();
        }

        //Chek current scene and load first
        private void RunGame()
        {
#if UNITY_EDITOR
            string currentSceneName = SceneManager.GetActiveScene().name;

            if (false) { //Replace false to cheking scene name. //currentSceneName == Scenes.GAMEPLAY || currentSceneName == Scenes.MENU || currentSceneName == Scenes.BOOTSTRAP) {
                _uiLoadingScreen.StartCoroutine(LoadAndStartFirstScreen());
                return;
            }
            else if (currentSceneName != Scenes.TRANSIT)
            {
                return;
            }
#endif
            _uiLoadingScreen.StartCoroutine(LoadAndStartFirstScreen());
        }

        private IEnumerator LoadAndStartFirstScreen()
        {
            _uiLoadingScreen.ShowLoadingScreen();

            // Replace null to loading first scene
            yield return null;
            //yield return SceneLoader.LoadBootstrapScene();
            //InitBootstrapScene();
            //yield return SceneLoader.LoadMenuScene();
            //InitMenuScene();

            _uiLoadingScreen.HideLoadingScreen();
        }

        //Loading screen it's pre-first screen, usualy with logo or loading progress bar
        private void CreateLoadingScreen()
        {
            var prefabUIRoot = Resources.Load<UILoadingScreenView>("UILoadingScreen.prefab");
            _uiLoadingScreen = GameObject.Instantiate(prefabUIRoot);
            GameObject.DontDestroyOnLoad(_uiLoadingScreen.gameObject);
        }

    }
}
