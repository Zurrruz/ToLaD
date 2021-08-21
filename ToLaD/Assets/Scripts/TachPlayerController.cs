using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TachPlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField]
    private GameObject _player;
    private float speed;
    [SerializeField]
    private float _maxSpeed = 3;

    Vector2 _movementDirection;

    Vector3 _destinetion;

    RaycastHit2D _hitInfoRight;
    RaycastHit2D _hitInfoLeft;
    RaycastHit2D _hitInfoTop;
    RaycastHit2D _hitInfoDown;

    void Start()
    {
        speed = _maxSpeed;
        _destinetion = _player.transform.position;
        _movementDirection.Set(0f, 1f);
    }

    void Update()
    {

        RaycastWall();

        if (_destinetion == _player.transform.position)
        {
            _destinetion =_player.transform.position + (Vector3)_movementDirection;
        }

        _player.transform.position = Vector3.MoveTowards(_player.transform.position, _destinetion, speed * Time.deltaTime);

        Move();
    }

    private void RaycastWall()
    {
        _hitInfoRight = Physics2D.Raycast(_player.transform.position, _movementDirection, 0.5f, LayerMask.GetMask("WallRight"));
        _hitInfoLeft = Physics2D.Raycast(_player.transform.position, _movementDirection, 0.5f, LayerMask.GetMask("WallLeft"));
        _hitInfoTop = Physics2D.Raycast(_player.transform.position, _movementDirection, 0.5f, LayerMask.GetMask("WallTop"));
        _hitInfoDown = Physics2D.Raycast(_player.transform.position, _movementDirection, 0.5f, LayerMask.GetMask("WallDown"));

        if (_hitInfoLeft)
        {
            _movementDirection.Set(1f, 0f);
            _destinetion = _player.transform.position + (Vector3)_movementDirection;
        }

        if (_hitInfoRight)
        {
            _movementDirection.Set(-1f, 0f);
            _destinetion = _player.transform.position + (Vector3)_movementDirection;
        }

        if (_hitInfoTop)
        {
            _movementDirection.Set(0f, -1f);
            _destinetion = _player.transform.position + (Vector3)_movementDirection;
        }

        if (_hitInfoDown)
        {
            _movementDirection.Set(0f, 1f);
            _destinetion = _player.transform.position + (Vector3)_movementDirection;
        }
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _movementDirection.Set(0f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _movementDirection.Set(0f, -1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _movementDirection.Set(1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _movementDirection.Set(-1f, 0f);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                _movementDirection.Set(1f, 0f);
            }
            else
            {
                _movementDirection.Set(-1f, 0f);
            }
        }
        else
        {
            if (eventData.delta.y > 0)
            {
                _movementDirection.Set(0f, 1f);
            }
            else
            {
                _movementDirection.Set(0f, -1f);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
