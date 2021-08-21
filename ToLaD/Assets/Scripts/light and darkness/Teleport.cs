using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    private float _countGhost;
    public static float countGhost;
    [SerializeField]
    private List<GameObject> _ghost = new List<GameObject>();
    [SerializeField]
    private Text _text;

    [SerializeField]
    private GameObject _ghostNotCollected;
    [SerializeField]
    private GameObject _ghostCollected;

    [SerializeField]
    private GameObject _player;

    private Animator _anim;

    public static bool move = true;

    public AudioSource TeleportSound;

    private void Start()
    {
        countGhost = 0;
        _ghostNotCollected.SetActive(false);
        _ghostCollected.SetActive(false);
        _countGhost = _ghost.Count;
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _text.text = " " + countGhost + " / " + _countGhost;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            move = false;
            if (countGhost != _countGhost)
            {
                _ghostNotCollected.SetActive(true);
            }
            if(countGhost >= _countGhost)
            {
                _ghostCollected.SetActive(true);
            }
        }       
    }

    public void Ok()
    {
        _ghostNotCollected.SetActive(false);
        _ghostCollected.SetActive(false);
        move = true;
    }

    public void NextLevel()
    {
        _ghostNotCollected.SetActive(false);
        _ghostCollected.SetActive(false);
        TeleportSound.Play();
        StartCoroutine(Next());
        StartCoroutine(Destroy());
    }

    IEnumerator Next()
    {
        _anim.SetBool("Next", true);
        yield return new WaitForSeconds(4.2f);
        SceneManager.LoadScene("Stage2");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        _player.SetActive(false);
    }
}
