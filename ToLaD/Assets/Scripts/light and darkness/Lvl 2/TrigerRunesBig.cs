using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerRunesBig : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _runesLeft = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _runesMiddle = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _runesRight = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _runesAll = new List<GameObject>();

    [SerializeField]
    private List<GameObject> _openDoor = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _closeDoor = new List<GameObject>();

    [SerializeField]
    private bool _big;

    private void Start()
    {
        foreach (var r in _runesLeft)
        {
            r.SetActive(false);
        }
        foreach (var r in _runesMiddle)
        {
            r.SetActive(false);
        }
        foreach (var r in _runesRight)
        {
            r.SetActive(false);
        }
        foreach (var r in _runesAll)
        {
            r.SetActive(false);
        }

        CloseDoor();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BigTriggerBlock") && _big)
        {
            LeftRunesActivation();
        }

        if(collision.CompareTag("TriggerBlock") && !_big)
        {
            MiddleRunesActivation();
        }

        if (collision.CompareTag("TriggerBlock") && !_big)
        {
            RightRunnesActivation();
        }

        if (collision.CompareTag("TriggerBlock") && !_big)
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BigTriggerBlock") && _big)
        {
            RunesDeactivation();
        }

        if(collision.CompareTag("TriggerBlock") && !_big)
        {
            MiddleRunesDeactivation();
        }

        if (collision.CompareTag("TriggerBlock") && !_big)
        {
            RightRunesDeactivation();
        }

        if (collision.CompareTag("TriggerBlock") && !_big)
        {
            CloseDoor();
        }
    }

    private void LeftRunesActivation()
    {
        foreach (var r in _runesLeft)
        {
            r.SetActive(true);
        }
    }

    private void MiddleRunesActivation()
    {
        foreach (var r in _runesMiddle)
        {
            r.SetActive(true);
        }
    }
    private void MiddleRunesDeactivation()
    {
        foreach (var r in _runesMiddle)
        {
            r.SetActive(false);
        }
    }

    private void RightRunnesActivation()
    {
        foreach (var r in _runesRight)
        {
            r.SetActive(true);
        }
    }
    private void RightRunesDeactivation()
    {
        foreach (var r in _runesRight)
        {
            r.SetActive(false);
        }
    }

    private void RunesDeactivation()
    {
        foreach (var r in _runesAll)
        {
            r.SetActive(false);
        }
    }

    private void OpenDoor()
    {
        foreach (var d in _openDoor)
        {
            d.SetActive(true);
        }
        foreach (var d in _closeDoor)
        {
            d.SetActive(false);
        }
    }
    private void CloseDoor()
    {
        foreach (var d in _openDoor)
        {
            d.SetActive(false);
        }
        foreach (var d in _closeDoor)
        {
            d.SetActive(true);
        }
    }
}
