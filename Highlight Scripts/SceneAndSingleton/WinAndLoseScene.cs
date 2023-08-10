using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLoseScene : MonoBehaviour
{
    [SerializeField] private string nameOfSceneToLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(nameOfSceneToLoad);
    }
    
    public void LoadSceneWithLoadingScene()
    {
        LoadingScreenController.Instance.LoadNextScene(nameOfSceneToLoad);
    }
}
