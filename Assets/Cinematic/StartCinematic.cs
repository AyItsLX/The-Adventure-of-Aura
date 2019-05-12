using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class StartCinematic : MonoBehaviour {
    public StartMenu sMenu;

    public GameObject Entry;

    public Animator tree1;
    public Animator tree2;

    public GameObject W1;
    public GameObject W2;
    public GameObject W3;
    public GameObject W4;

    public StartMenu Menu;

    public GameObject StartText;

    public AudioSource campfireaudio;

    public static bool PlayThis;

    private void Awake()
    {
        W1.SetActive(false);
        W2.SetActive(false);
        W3.SetActive(false);
        W4.SetActive(false);
        Entry.SetActive(true);
        tree1.enabled = false;
        tree2.enabled = false;
        StartText.SetActive(false);
    }

    IEnumerator Word()
    {
        W1.SetActive(true);
        yield return new WaitForSeconds(2f);
        W1.SetActive(false);
        W2.SetActive(true);
        yield return new WaitForSeconds(4f);
        W2.SetActive(false);
        W3.SetActive(true);
        yield return new WaitForSeconds(4f);
        W3.SetActive(false);
        W4.SetActive(true);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Menu.RockSlide());
        PlayThis = true;
    }
    public void StartCutscene()
    {
        campfireaudio.Play();
        W4.SetActive(false);
        if (PlayThis)
        {
            StartText.SetActive(true);
            FindObjectOfType<MusicManager>().Play("TreeFall");
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 30f);
        }
        sMenu.PlayerUI.SetActive(true);
        Entry.SetActive(false);
        GameManager.isStarted = true;
        tree1.enabled = true;
        tree2.enabled = true;
        GameManager.MsgUITrigger = true;
        Destroy(gameObject, 1f);
    }
}
