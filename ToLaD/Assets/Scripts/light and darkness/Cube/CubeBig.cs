using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBig : MonoBehaviour
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


    public static float distanceBig;

    private void Start()
    {
       
            _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       
        
            Vector2 A_pos = ObjA.position;
            Vector2 B_pos = ObjB.position;
            distanceBig = (A_pos - B_pos).magnitude;
            if (distanceBig <= n && Input.GetKey(KeyCode.Space))
                Go();
        
    }


   private void Go()
    {
        _rb.velocity = PlayerController._movementDirection * _speed;
    }
}
