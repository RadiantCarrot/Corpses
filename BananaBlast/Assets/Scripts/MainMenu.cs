using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Done by Jaina
public class MainMenu : MonoBehaviour
{
    //Done by Jaina
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //Loads the next scene in the build settings
    }
    public void QuitGame()
    {
        Application.Quit();  //Quits game
    }
    
    
}

