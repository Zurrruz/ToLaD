using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCar : MonoBehaviour
{
    private float _start;
    public static bool startGame;
    bool _finishGame;

    [SerializeField]
    private Text _checkInTime;
    [SerializeField]
    private Text _checkInTimeFinish;
    
    private float _timerGame;
    private float _msec;
    private float _sec;
    private float _min;

    
    [SerializeField]
    private GameObject _finishMenu;
    [SerializeField]
    private GameObject _liderboard;

    // Start is called before the first frame update
    void Start()
    {
        _start = 0f;
        startGame = false;
        _finishGame = false;
        _timerGame = 0f;

        _finishMenu.SetActive(false);
        _liderboard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimerStartGame();
        CheckInTime();
        
        _checkInTimeFinish.text = string.Format("{0:00}:{1:00}:{2:00}", _min, _sec, _msec);

        Save();
    }

    void TimerStartGame()
    {
        _start += Time.deltaTime;

        if(_start >= 9f)
        {
            startGame = true;
        }
    }

    void CheckInTime()
    {
        if(startGame && !_finishGame)
        {
            _timerGame += Time.deltaTime;
        }

        _msec = (int)((_timerGame - (int)_timerGame) * 100);
        _sec = (int)(_timerGame % 60);
        _min = (int)(_timerGame / 60 % 60);

        _checkInTime.text = string.Format("{0:00}:{1:00}:{2:00}", _min, _sec, _msec);        
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Finish"))
        {
            _finishMenu.SetActive(true);
            _finishGame = true;            
        }
    }

    private void Save()
    {                
        PlayerPrefs.SetFloat("Time", _timerGame);
    }

    public void OK()
    {
        PlayerPrefs.Save();
        _finishMenu.SetActive(false);
        _liderboard.SetActive(true);
    }
}
