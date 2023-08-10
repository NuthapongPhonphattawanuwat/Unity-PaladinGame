using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneController : MonoBehaviour
    {
        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
        
        public void LoadScene1()
        {
            SceneManager.LoadScene("Scene1");
        }

        public void LoadScene2()
        {
            SceneManager.LoadScene("Scene2");
        }

        public void LoadScene3()
        {
            SceneManager.LoadScene("Scene3");
        }

        public void LoadCreditScene()
        {
            SceneManager.LoadScene("CreditScene");
        }
        
        public void LoadCreditScene2()
        {
            SceneManager.LoadScene("CreditScene2");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}