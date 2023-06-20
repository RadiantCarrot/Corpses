using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndscreenDisplayScript : MonoBehaviour
{
    public TMP_Text bulletsFired;
    public TMP_Text enemiesSlain;
    public TMP_Text highestLevel;
    public TMP_Text timeSurvived;

    // Start is called before the first frame update
    void Start()
    {
        bulletsFired.text = "insert bullets fired here";
        enemiesSlain.text = "insert enemies slain here";
        highestLevel.text = "insert highest level here";
        timeSurvived.text = "insert time survived here";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
