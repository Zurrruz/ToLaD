using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOne : MonoBehaviour
{
    public static TeleportOne Instance;

    public TutorialManager TutorialManager;

    private Animator _anim;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private float _startMove;
    [SerializeField]
    private float _startGame;
    [SerializeField]
    private float _animTeleport;

    public AudioSource TeleportSound;

    // Start is called before the first frame update
    void Start()
    {
        
        Teleport.move = false;
        _anim = GetComponent<Animator>();
        _player.SetActive(false);
        StartCoroutine( StartGame());
        StartCoroutine(StartMove());
        StartCoroutine(AnimTeleport());
    }

    IEnumerator AnimTeleport()
    {
        yield return new WaitForSeconds(_animTeleport);
        _anim.SetBool("StartTeleportOne", true);
        TeleportSound.Play();
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(_startGame);
        _player.SetActive(true);
        TutorialManager.OnEvent(TutorialEvent.GameStart); 
    }

    IEnumerator StartMove()
    {
        yield return new WaitForSeconds(_startMove);
        Teleport.move = true;
    }
    
}
