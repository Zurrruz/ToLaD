using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{ 

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.CompareTag("Water"))
        {
            GameManager._rage = 1f;
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
   

    
}
