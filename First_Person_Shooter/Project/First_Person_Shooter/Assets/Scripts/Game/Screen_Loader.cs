using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen_Loader : MonoBehaviour
{
    public void Play_Again()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Quit_Game()
    {
        Application.Quit();
    }
}
