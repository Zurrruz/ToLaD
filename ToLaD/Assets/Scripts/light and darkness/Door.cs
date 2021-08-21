using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject _doorClosed;
    [SerializeField]
    private GameObject _doorOpen;

    public static bool leftRunes;
    public static bool rightRunes;

    // Start is called before the first frame update
    void Start()
    {
        leftRunes = false;
        rightRunes = false;
        _doorClosed.SetActive(true);
        _doorOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(leftRunes && rightRunes)
        {
            _doorClosed.SetActive(false);
            _doorOpen.SetActive(true);
        }
        else
        {
            _doorClosed.SetActive(true);
            _doorOpen.SetActive(false);
        }
    }
}
