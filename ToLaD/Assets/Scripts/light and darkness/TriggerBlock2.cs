using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlock2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _rune;
    

    private void Start()
    {
        _rune.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {                
        if (collision.CompareTag("TriggerBlock"))
        {
            _rune.SetActive(true);
            Door.rightRunes = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {       
        if (collision.CompareTag("TriggerBlock"))
        {
            _rune.SetActive(false);
            Door.rightRunes = false;
        }
    }
}
