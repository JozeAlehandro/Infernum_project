using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManagerScript : MonoBehaviour
{
    public GameObject menu, settings, infoPlate;
    public Button bVolume, bMusic;
    public Slider volumeSlider, musicSlider;
    public AudioSource audioSource;
    public float getValueMusic, getValueVolume, getValueMusicSlider;
    private bool isPressedVolume = false, isPressedMusic = false, isPressedInfo = false;
    public AudioClip btnClickSound;

    void Start()
    {
        Cursor.visible = false;
        menu.SetActive(false);
        settings.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {

    }

    public void Play()
    {

        Cursor.visible = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Settings()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void SaveSettings()
    {
        settings.SetActive(false);
        Cursor.visible = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MuteMusic()
    {
        if (!isPressedMusic)
        {
            bMusic.GetComponent<Image>().color = Color.red;
            isPressedMusic = true;
            getValueMusic = audioSource.volume;
            getValueMusicSlider = musicSlider.value;
            musicSlider.value = 0;
            audioSource.volume = 0;
        }
        else
        {
            bMusic.GetComponent<Image>().color = Color.white;
            isPressedMusic = false;
            audioSource.volume = getValueMusic;
            musicSlider.value = getValueMusicSlider;
        }
    }
    public void MuteVolume()
    {
        if (!isPressedVolume)
        {
            bVolume.GetComponent<Image>().color = Color.red;
            isPressedVolume = true;
            getValueVolume = volumeSlider.value;
            volumeSlider.value = 0;
        }
        else
        {
            bVolume.GetComponent<Image>().color = Color.white;
            isPressedVolume = false;
            volumeSlider.value = getValueVolume;
        }
    }
    public void Info()
    {
        if(!isPressedInfo)
        {
            isPressedInfo = true;
            infoPlate.SetActive(true);
        }
        else
        {
            isPressedInfo = false;
            infoPlate.SetActive(false);
        }
    }
    
    public void BtnClickSound()
    {
        AudioSource.PlayClipAtPoint(btnClickSound, GameObject.Find("Player").transform.position, volumeSlider.value);
    }
}
