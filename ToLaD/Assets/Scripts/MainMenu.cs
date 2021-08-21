using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _setting;
    [SerializeField]
    private GameObject _mainMenu;

    [SerializeField]
    private AudioMixerGroup _sound;

    [SerializeField]
    private PlayableDirector _director;

    void Start()
    {
        //Return();        
    }
        

    public void Setting()
    {
        _setting.SetActive(true);        
        _mainMenu.SetActive(false);
    }

    public void Back()
    {
        _setting.SetActive(false);  
        _mainMenu.SetActive(true);
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
       

    public void Stage1()
    {
        StartCoroutine(StartGame());
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
        Time.timeScale = 1f;
    }

    public void ChangeVolume(float volume)
    {
        _sound.audioMixer.SetFloat("Sound", Mathf.Lerp(-80, 0, volume));
    }

    IEnumerator StartGame()
    {
        _director.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Stage1");        
        Time.timeScale = 1f;
    }

}
