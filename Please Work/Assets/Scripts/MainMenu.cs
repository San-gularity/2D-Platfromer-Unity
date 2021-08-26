using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public new AudioManager audio;
    public void PlayIt()
    {
        audio.Play("ClickSound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void TutorialScreen()
    {
        audio.Play("ClickSound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsScreen()
    {
        audio.Play("ClickSound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void QuitGame()
    {
        audio.Play("ClickSound");
        Application.Quit();
    }

    public void PlayClick()
    {
        audio.Play("ClickSound");
    }
}
