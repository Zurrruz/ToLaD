using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> lawn = new List<GameObject>();
    [SerializeField]
    private GameObject _winStage;
    [SerializeField]
    private GameObject _losing;

    public static int _lawnCount;
    [SerializeField]
    private Text _count;

    [SerializeField]
    private float _maxRage = 1f;
    public static float _rage;
    [SerializeField]
    private Image _barRage;



    void Start()
    {
        _winStage.SetActive(false);
        _lawnCount = lawn.Count;
        _rage = 0f;
    }

    void Update()
    {
        Win();
        Count();
        BarRage();
        Losing();
    }

    private void Win()
    {
        if(_lawnCount <= 0)
        {
            Time.timeScale = 0f;
            _winStage.SetActive(true);
        }
    }

    private void Losing()
    {
        if (_rage >= _maxRage)
        {
            
            _losing.SetActive(true);
        }
    }

    private void Count()
    {
        _count.text = "Осталось подстрич " + _lawnCount;
    }

    private void BarRage()
    {
        _barRage.fillAmount = _rage;
    }
}
