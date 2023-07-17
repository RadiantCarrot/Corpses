using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Done by Jaine
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //Gameplay continues
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;    //Gameplay stops
        GameIsPaused = true;
        
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu"); //Calls MainMenu Scene
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game"); 
        Application.Quit(); // Quits the game
    }
}
