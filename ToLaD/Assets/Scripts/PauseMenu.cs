using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private GameObject _optionsMenu;

    [SerializeField]
    private AudioMixerGroup _sound;

    [SerializeField]
    private PlayableDirector _director;

    // Start is called before the first frame update
    void Start()
    {
        _pauseMenu.SetActive(false);
        _optionsMenu.SetActive(false);
    }    

    public void PauseMenuOn()
    {
        _pauseMenu.SetActive(true);
        _optionsMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void OptionMenu()
    {
        _pauseMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void BackMenu()
    {
        _pauseMenu.SetActive(true);
        _optionsMenu.SetActive(false);        
    }

    public void BackGame()
    {
        _pauseMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage1");
        Time.timeScale = 1f;
    }
    public void Restart2()
    {
        SceneManager.LoadScene("Stage2");
        Time.timeScale = 1f;
    }
    public void Restart3()
    {
        SceneManager.LoadScene("Stage3");
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void ChangeVolume(float volume)
    {
        _sound.audioMixer.SetFloat("Sound", Mathf.Lerp(-80, 0, volume));
    }

    public void TheAnd()
    {
        _director.Play();
        StartCoroutine(TheAndGame());
    }
    IEnumerator TheAndGame()
    {
        yield return new WaitForSeconds(14f);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
