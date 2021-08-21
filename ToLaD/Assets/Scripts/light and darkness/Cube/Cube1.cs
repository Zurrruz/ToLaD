using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube1 : MonoBehaviour
{
    [SerializeField]
    private Transform ObjA;
    [SerializeField]
    private Transform ObjB;
    [SerializeField]
    [Tooltip("Расстояние для начала следования")]
    private float n = 1f;
    [SerializeField]
    private float _speed = 1.2f;
    private Rigidbody2D _rb;


    public static float distance1;

    private void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        
    }    
    void Update()
    {
        
            Vector2 A_pos = ObjA.position;
            Vector2 B_pos = ObjB.position;
            distance1 = (A_pos - B_pos).magnitude;
            if (distance1 <= n && Input.GetKey(KeyCode.Space))
                Go();
    }


    private void Go()
    {
        _rb.velocity = PlayerController._movementDirection * _speed;
    }
}
