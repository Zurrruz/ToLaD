using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    private Animator _anim;
    public bool black;


    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(SoulDestroy());            
        }       
    }

    IEnumerator SoulDestroy()
    {
        
        Teleport.countGhost++;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (!black)
        {
            _anim.Play("SoulDestroy");
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
        if (black)
        {
            _anim.Play("BlackSoulDestroy");
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }        
    }
}
