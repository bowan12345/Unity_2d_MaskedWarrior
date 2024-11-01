using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string NowSceneName; 
    public string NextName;
    public string Level1;
    public GameObject PauseBtn;
    public GameObject ContinueBtn;

    public GameObject WeaponControl;


    public void Restart()
    {
        Time.timeScale = 1;
        WeaponControl.SetActive(true);
        SceneManager.LoadScene(NowSceneName);
    }

    public void RestartLevel1()
    {
        Time.timeScale = 1;
        WeaponControl.SetActive(true);
        SceneManager.LoadScene(Level1);
    }


    public void LoadStartGame()
    {
        Time.timeScale = 1;
        WeaponControl.SetActive(true);
        SceneManager.LoadScene(0);
    }

    public void LoadEndGame()
    {
        Time.timeScale = 1;
        WeaponControl.SetActive(true);
        SceneManager.LoadScene(NextName);
    }



    public void ClickPauseBtn()
    {
        PauseBtn.SetActive(false);
        ContinueBtn.SetActive(true);
        Time.timeScale = 0;
        WeaponControl.SetActive(false);
    }

    public void ClickContinueBtn()
    {
        PauseBtn.SetActive(true);
        ContinueBtn.SetActive(false);
        Time.timeScale = 1;
        WeaponControl.SetActive(true);
    }


    void Update()
    {
       

     }


        public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
