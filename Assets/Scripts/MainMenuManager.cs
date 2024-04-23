using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;

    public void StartGame() 
    {
        SceneManager.LoadScene("Ninja Bubbles");   
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

}
