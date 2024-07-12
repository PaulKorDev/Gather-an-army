using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Architecture.EntryPoint
{
    public static class SceneLoader
    {
        public static IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(Scenes.TRANSIT);
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return new WaitForEndOfFrame();
        }
        public static IEnumerator LoadSceneWithoutTransit(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return new WaitForEndOfFrame();
        }
    }
}
