using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void exitButton()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        //Debug.Log("Quiting game");
    }

    public void startTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void startGame()
    {
        SceneManager.LoadScene("Lvl_1");
    }
}
