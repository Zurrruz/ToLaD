using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Rage());
    }

    IEnumerator Rage()
    {       
        yield return new WaitForSeconds(0.5f);
        GameManager._rage += 0.25f;
        Destroy(gameObject);
    }
}
