using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private InputField _playerName;

    [SerializeField]
    private GameObject _mainMenu;
    [SerializeField]
    private GameObject _startGame;

    private void Start()
    {
        _mainMenu.SetActive(true);
        _startGame.SetActive(false);
    }

    public void NewGame()
    {
        _mainMenu.SetActive(false);
        _startGame.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Выходи из игры");
    }

    public void StartGame()
    {
        PlayerPrefs.SetString("PlayerName", _playerName.text);
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        _mainMenu.SetActive(true);
        _startGame.SetActive(false);
    }
}
