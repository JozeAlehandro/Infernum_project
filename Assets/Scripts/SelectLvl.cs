using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLvl : MonoBehaviour
{
    public void OnDropdownChanged(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 1:
                SceneManager.LoadScene("Lvl - 1");
                break;
            case 2:
                SceneManager.LoadScene("Lvl - 2");
                break;
            case 3:
                SceneManager.LoadScene("Lvl - 3");
                break;
            case 4:
                SceneManager.LoadScene("Lvl - 4");
                break;
            case 5:
                SceneManager.LoadScene("Lvl - 5");
                break;
            case 6:
                SceneManager.LoadScene("Meme");
                break;
            case 7:
                SceneManager.LoadScene("Subtile");
                break;
        }
    }
}
