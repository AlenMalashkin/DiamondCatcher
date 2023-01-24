using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader instance;

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
            SceneManager.LoadScene(sceneName);
        }
    }
}
