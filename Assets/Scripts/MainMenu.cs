using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainManu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    public void Play()
    {
        SceneManager.LoadScene("Lvl - 1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Menu
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R)) // Restart
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
