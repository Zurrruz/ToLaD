using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject _runes;
    [SerializeField]
    private GameObject _runes1;

    private void Start()
    {
        _runes.SetActive(false);
        _runes1.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("TriggerBlock"))
        {
            _runes.SetActive(true);
            _runes1.SetActive(true);
            Door.leftRunes = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerBlock"))
        {
            _runes.SetActive(false);
            _runes1.SetActive(false);
            Door.leftRunes = false;
        }        
    }
}
