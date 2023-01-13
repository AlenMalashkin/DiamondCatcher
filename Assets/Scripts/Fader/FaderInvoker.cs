using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fader
{
    public class FaderInvoker : MonoBehaviour
    {
        private bool _isLoading;

        public static FaderInvoker instance;

        private void Awake()
        {
            PlayerPrefs.SetString("WoodLocation", "Bought");

            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(string sceneName)
        {
            if (_isLoading)
                return;

            var currentSceneName = SceneManager.GetActiveScene().name;
            
            if (currentSceneName == sceneName)
                throw new Exception("You are trying to load actually loaded scene");

            StartCoroutine(LoadSceneRoutine(sceneName));
        }
        
        private IEnumerator LoadSceneRoutine(string sceneName)
        {
            _isLoading = true;

            var waitFading = true;
            Fader.instance.FadeIn(() => waitFading = false);

            while (waitFading)
                yield return null;

            var async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)
                yield return null;

            async.allowSceneActivation = true;

            waitFading = true;
            Fader.instance.FadeOut(() => waitFading = false);

            while (waitFading)
                yield return null;

            _isLoading = false;
        }
    }
}
