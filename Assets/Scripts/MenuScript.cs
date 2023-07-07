using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        //DontDestroyOnLoad((SaveScript.jsonRef));
        //SceneManager.GetActiveScene().buildIndex + 1q
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        UnityEngine.Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }
    public void loadInstructions()
    {
        SceneManager.LoadScene(5);
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void loadCredits()
    {
        SceneManager.LoadScene(6);
    }

    public void QuitGame()
    {
        UnityEngine.Debug.Log("Did I quit the game?");
        UnityEngine.Application.Quit();
    }

}
