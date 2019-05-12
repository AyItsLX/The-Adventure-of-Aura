using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCine : MonoBehaviour {

    public Transform FollowPlayer;

    public GameObject EndScreenUI;
    public GameObject EndScreenAnimation;

    Transform LookAtTarget;

    public GameObject Win;
    bool RotateRight = true;
    bool activeOnce;
    void Awake()
    {
        activeOnce = false;
        EndScreenAnimation.SetActive(false);
        EndScreenUI.SetActive(false);
        Win.SetActive(false);
        FollowPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        LookAtTarget = GameObject.FindGameObjectWithTag("Boss").transform;
        transform.position = new Vector3(FollowPlayer.position.x, FollowPlayer.position.y, FollowPlayer.position.z);
    }

    void Update()
    {
        transform.LookAt(LookAtTarget);
        if (transform.localPosition.y < 100f)
        {
            transform.localPosition = transform.localPosition + new Vector3(Time.deltaTime * 5f, Time.deltaTime * 15f, Time.deltaTime * 15f);
        }
        else if (transform.localPosition.y > 100f && !activeOnce)
        {
            RotateRight = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartCoroutine(Wait2Sec());
        }
    }

    IEnumerator Wait2Sec()
    {
        activeOnce = true;
        yield return new WaitForSeconds(1f);
        Win.SetActive(true);
        yield return new WaitForSeconds(3f);
        FindObjectOfType<MusicManager>().Play("Victory");
        EndScreenAnimation.SetActive(true);
        Win.SetActive(false);
        yield return new WaitForSeconds(1f);
        EndScreenUI.SetActive(true);
    }
}
