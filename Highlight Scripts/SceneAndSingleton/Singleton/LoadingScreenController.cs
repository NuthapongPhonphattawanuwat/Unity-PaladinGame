using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LoadingScreenController : MonoBehaviour
    {
        private static LoadingScreenController instance;
        public static LoadingScreenController Instance => instance;

        [SerializeField] private GameObject loadingScreenObject;
        
        private void Awake()
        {
            instance = this;
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            //1) Set loading screen active
            loadingScreenObject.SetActive(true);
            
            //2) Unload old scene
            AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            while (!unloadOp.isDone)
            {
                yield return null;
            }
            
            //3) Load new scene
            AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!loadOp.isDone)
            {
                yield return null;
            }

            yield return new WaitForSeconds(2f);
            
            //4) Display new scene/Set loading screen inactive
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            loadingScreenObject.SetActive(false);
        }

        public void LoadNextScene(string sceneName)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }
    }
}
