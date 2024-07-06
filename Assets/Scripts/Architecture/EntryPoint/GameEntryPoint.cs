using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Architecture.EntryPoint
{
    public sealed class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private UILoadingScreenView _uiLoadingScreen;
        private Coroutine coroutine;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStart()
        {
            Application.targetFrameRate = 60;

#if UNITY_IOS || UNITY_ANDROID || UNITY_WP_8_1
            //For mobile game
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint()
        {
            CreateCoroutineObj();
            CreateLoadingScreen();
        }

        //Chek current scene and load first
        private void RunGame()
        {
#if UNITY_EDITOR
            string currentSceneName = SceneManager.GetActiveScene().name;

            if (currentSceneName == Scenes.GAMEPLAY || currentSceneName == Scenes.MENU || currentSceneName == Scenes.BOOTSTRAP)
            { 
                coroutine.StartCoroutine(LoadAndStartFirstScreen());
                return;
            }
            else if (currentSceneName != Scenes.TRANSIT)
            {
                return;
            }
#endif
            coroutine.StartCoroutine(LoadAndStartFirstScreen());
        }

        private IEnumerator LoadAndStartFirstScreen()
        {

            yield return SceneLoader.LoadScene(Scenes.BOOTSTRAP);
            GameHandler GameHandler = GameObject.FindObjectOfType<GameHandler>();
            GameHandler.Init();
            //InitBootstrapScene();
            //_uiLoadingScreen.ShowLoadingScreen();
            //yield return SceneLoader.LoadScene(Scenes.GAMEPLAY);
            //InitGameplayScene();

            _uiLoadingScreen.HideLoadingScreen();
        }

        //Loading screen it's pre-first screen, usualy with logo or loading progress bar
        private void CreateLoadingScreen()
        {
            var prefabUIRoot = Resources.Load<GameObject>(PrefabPaths.LOADING_SCREEN);
            _uiLoadingScreen = GameObject.Instantiate(prefabUIRoot).GetComponent<UILoadingScreenView>();
            GameObject.DontDestroyOnLoad(_uiLoadingScreen.gameObject);
        }
        private void CreateCoroutineObj()
        {
            coroutine = new GameObject("[COROUTINE]").AddComponent<Coroutine>();
            GameObject.DontDestroyOnLoad(coroutine);
        }

    }
}
