using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Liderboard : MonoBehaviour
{
    [SerializeField]
    private Text _name;
    [SerializeField]
    private Text _result_1;
    [SerializeField]
    private Text _result_2;
    [SerializeField]
    private Text _result_3;
    [SerializeField]
    private Text _result_4;
    [SerializeField]
    private Text _result_5;
    
    private float _checkInTime;

    float result_1;
    float result_2;
    float result_3;
    float result_4;
    float result_5;
    
    private List<float> f = new List<float>();
    
    private float _msec;
    private float _sec;
    private float _min;

   
    public void OK()
    {
        _checkInTime = PlayerPrefs.GetFloat("Time");

        WriteNewResult(_checkInTime);        
        Sort();

        _name.text = PlayerPrefs.GetString("PlayerName");

        _result_1.text = MinSecMsec(result_1);        
        if (result_2 > 0)
        {
            _result_2.text = MinSecMsec(result_2);
            if (result_3 > 0)
            {
                _result_3.text = MinSecMsec(result_3);
                if (result_4 > 0)
                {
                    _result_4.text = MinSecMsec(result_4);
                    if (result_5 > 0)
                    {
                        _result_5.text = MinSecMsec(result_5);
                    }
                }
            }
        }      
    }

    void WriteNewResult(float _newRes)
    {      
        PlayerPrefs.SetFloat("result_5", PlayerPrefs.GetFloat("result_4"));
        PlayerPrefs.SetFloat("result_4", PlayerPrefs.GetFloat("result_3"));
        PlayerPrefs.SetFloat("result_3", PlayerPrefs.GetFloat("result_2"));
        PlayerPrefs.SetFloat("result_2", PlayerPrefs.GetFloat("result_1"));
        PlayerPrefs.SetFloat("result_1", _newRes);
        PlayerPrefs.Save();
    }  
    
    private void Sort()
    {
        float one = PlayerPrefs.GetFloat("result_1");
        float two = PlayerPrefs.GetFloat("result_2");
        float three = PlayerPrefs.GetFloat("result_3");
        float four = PlayerPrefs.GetFloat("result_4");
        float five = PlayerPrefs.GetFloat("result_5");

        
        f.Add(one);
        if (two > 0)
            f.Add(two);
        if (three > 0)
            f.Add(three);
        if (four > 0)
            f.Add(four);
        if (five > 0)
            f.Add(five);

        f.Sort();

        result_1 = f[0];
        if(two > 0)
        { 
            result_2 = f[1];
            if (three > 0)
            {
                result_3 = f[2];
                if (four > 0)
                {
                    result_4 = f[3];
                    if (five > 0)
                    {
                        result_5 = f[4];
                    }
                }
            }
        }    
    }

    private string MinSecMsec( float a)
    {       
        _msec = (int)((a - (int)a) * 100);
        _sec = (int)(a % 60);
        _min = (int)(a / 60 % 60);

       return string.Format("{0:00}:{1:00}:{2:00}", _min, _sec, _msec);
    }

    public void Clear()
    {
        PlayerPrefs.SetFloat("result_5", 0);
        PlayerPrefs.SetFloat("result_4", 0);
        PlayerPrefs.SetFloat("result_3", 0);
        PlayerPrefs.SetFloat("result_2", 0);
        PlayerPrefs.SetFloat("result_1", 0);
        PlayerPrefs.Save();

        _result_1.text = "00:00:00";
        _result_2.text = "00:00:00";
        _result_3.text = "00:00:00";
        _result_4.text = "00:00:00";
        _result_5.text = "00:00:00";

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
}
