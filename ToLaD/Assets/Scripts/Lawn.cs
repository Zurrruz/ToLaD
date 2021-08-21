using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawn : MonoBehaviour
{
    [SerializeField]
    private Sprite _mowedLawn;
    [SerializeField]
    private Sprite _mowedLawnTwo;
    [SerializeField]
    private float _timeMowedLawn;
    private bool _oneLawn = true;
    private bool _one = true;
    private bool _twoLawn = true;

    private SpriteRenderer _sp;

    // Start is called before the first frame update
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("Player") && _one)
            StartCoroutine(MowedLawn());
        if (coll.transform.CompareTag("Player") && !_one)
            StartCoroutine(MowedLawnTwo());
    }
   
    IEnumerator MowedLawn()
    {
        yield return new WaitForSeconds(_timeMowedLawn);
        _sp.sprite = _mowedLawn;
        _one = false;

        if (_oneLawn)
        {
            GameManager._lawnCount--;
            _oneLawn = false;
        }
    }

    IEnumerator MowedLawnTwo()
    {
        yield return new WaitForSeconds(_timeMowedLawn);
        _sp.sprite = _mowedLawnTwo;

        if (_twoLawn)
        {
            GameManager._rage +=  0.1f;
            _twoLawn = false;
        }
    }
}
