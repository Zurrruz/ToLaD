using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3;
    private int _isWhiteWorld;  

    private Animator _anim;
    private Rigidbody2D _rb;
    [SerializeField]
    private float _teleportX;
      

    
    Vector2 _input;
   public static  Vector2 _movementDirection;

    // Start is called before the first frame update
    void Start()
    {        
        _isWhiteWorld = 1;
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        ChangeOfTheWorld();
       
    }

    private void PlayerMove()
    {
        if (Teleport.move == false)
        {
            _movementDirection.Set(0f, 0f);
            _movementDirection = Vector2.zero;
            _anim.SetBool("MoveN", false);
            _anim.SetBool("MoveS", false);
            _anim.SetBool("MoveE", false);
            _anim.SetBool("MoveW", false);
            _anim.SetBool("Idle", true);
        }
        if (Teleport.move)
        {           
            if (Input.GetKey(KeyCode.Space))
            {
                if (Cube1.distance1 <= 1f)
                {
                    _speed = 1;
                    if (Input.GetKey(KeyCode.W))
                    {
                        //_anim.Play("CharacterN");
                        _anim.SetBool("MoveN", false);
                        _anim.SetBool("MoveS", true);
                        _anim.SetBool("MoveE", false);
                        _anim.SetBool("MoveW", false);
                        _anim.SetBool("Idle", false);
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        _anim.SetBool("MoveN", true);
                        _anim.SetBool("MoveS", false);
                        _anim.SetBool("MoveE", false);
                        _anim.SetBool("MoveW", false);
                        _anim.SetBool("Idle", false);
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        _anim.SetBool("MoveN", false);
                        _anim.SetBool("MoveS", false);
                        _anim.SetBool("MoveE", true);
                        _anim.SetBool("MoveW", false);
                        _anim.SetBool("Idle", false);
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        _anim.SetBool("MoveN", false);
                        _anim.SetBool("MoveS", false);
                        _anim.SetBool("MoveE", false);
                        _anim.SetBool("MoveW", true);
                        _anim.SetBool("Idle", false);
                    }
                }
                if (Cube.distance <= 1f)
                {
                    _speed = 1;
                    if (Input.GetKey(KeyCode.W))
                    {
                        //_anim.Play("CharacterN");
                        _anim.SetBool("MoveN", false);
                        _anim.SetBool("MoveS", true);
                        _anim.SetBool("MoveE", false);
                        _anim.SetBool("MoveW", false);
                        _anim.SetBool("Idle", false);
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        _anim.SetBool("MoveN", true);
                        _anim.SetBool("MoveS", false);
                        _anim.SetBool("MoveE", false);
                        _anim.SetBool("MoveW", false);
                        _anim.SetBool("Idle", false);
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        _anim.SetBool("MoveN", false);
                        _anim.SetBool("MoveS", false);
                        _anim.SetBool("MoveE", true);
                        _anim.SetBool("MoveW", false);
                        _anim.SetBool("Idle", false);
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        _anim.SetBool("MoveN", false);
                        _anim.SetBool("MoveS", false);
                        _anim.SetBool("MoveE", false);
                        _anim.SetBool("MoveW", true);
                        _anim.SetBool("Idle", false);
                    }
                }
                if (CubeBig.distanceBig <= 1f)
                {
                    _speed = 1;
                    if (Input.GetKey(KeyCode.W))
                    {
                        //_anim.Play("CharacterN");
                        _anim.SetBool("MoveN", false);
                        _anim.SetBool("MoveS", true);
                        _anim.SetBool("MoveE", false);
                        _anim.SetBool("MoveW", false);
                        _anim.SetBool("Idle", false);
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        _anim.SetBool("MoveN", true);
                        _anim.SetBool("MoveS", false);
                        _anim.SetBool("MoveE", false);
                        _anim.SetBool("MoveW", false);
                        _anim.SetBool("Idle", false);
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        _anim.SetBool("MoveN", false);
                        _anim.SetBool("MoveS", false);
                        _anim.SetBool("MoveE", true);
                        _anim.SetBool("MoveW", false);
                        _anim.SetBool("Idle", false);
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        _anim.SetBool("MoveN", false);
                        _anim.SetBool("MoveS", false);
                        _anim.SetBool("MoveE", false);
                        _anim.SetBool("MoveW", true);
                        _anim.SetBool("Idle", false);
                    }
                }
            }            
            else
            {
                _speed = 3;
                if (Input.GetKey(KeyCode.W))
                {
                    //_anim.Play("CharacterN");
                    _anim.SetBool("MoveN", true);
                    _anim.SetBool("MoveS", false);
                    _anim.SetBool("MoveE", false);
                    _anim.SetBool("MoveW", false);
                    _anim.SetBool("Idle", false);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    _anim.SetBool("MoveN", false);
                    _anim.SetBool("MoveS", true);
                    _anim.SetBool("MoveE", false);
                    _anim.SetBool("MoveW", false);
                    _anim.SetBool("Idle", false);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    _anim.SetBool("MoveN", false);
                    _anim.SetBool("MoveS", false);
                    _anim.SetBool("MoveE", false);
                    _anim.SetBool("MoveW", true);
                    _anim.SetBool("Idle", false);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    _anim.SetBool("MoveN", false);
                    _anim.SetBool("MoveS", false);
                    _anim.SetBool("MoveE", true);
                    _anim.SetBool("MoveW", false);
                    _anim.SetBool("Idle", false);
                }
            }

            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (_input.x != 0)
            {
                _movementDirection.Set(_input.x, 0f);
            }
            else if (_input.y != 0)
            {
                _movementDirection.Set(0f, _input.y);
            }
            else
            {
                _movementDirection = Vector2.zero;
                _anim.SetBool("MoveN", false);
                _anim.SetBool("MoveS", false);
                _anim.SetBool("MoveE", false);
                _anim.SetBool("MoveW", false);
                _anim.SetBool("Idle", true);
            }
        }
        
            _rb.velocity = _movementDirection * _speed;
        
    }

    private void ChangeOfTheWorld()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _isWhiteWorld == 2)
        {
            StartCoroutine(TeleportClose());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _isWhiteWorld == 1)
        {
            StartCoroutine(TeleportOpen());
        }
    }

    IEnumerator TeleportOpen()
    {
        _anim.SetBool("Teleport", true);
        yield return new WaitForSeconds(0.3f);
        _anim.SetBool("Teleport", false);
        transform.Translate(+_teleportX, 0, 0);
        _isWhiteWorld = 2;
    }

    IEnumerator TeleportClose()
    {
        _anim.SetBool("Teleport", true);
        yield return new WaitForSeconds(0.3f);
        _anim.SetBool("Teleport", false);
        transform.Translate(-_teleportX, 0, 0);
        _isWhiteWorld = 1;
    }
}

