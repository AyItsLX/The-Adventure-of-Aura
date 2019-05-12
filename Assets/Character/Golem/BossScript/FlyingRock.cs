using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class FlyingRock : MonoBehaviour {

    public Transform playerLastPos;
    public Vector3 LastPos;

    public GameObject RockPart;

    void Awake()
    {
        RockPart.SetActive(false);
        playerLastPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        LastPos = playerLastPos.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100f);
        Releaserock();

        float Dist = Vector3.Distance(transform.position, LastPos);
        if (Dist <= 0.10f)
        {
            Destroy(gameObject);
        }
    }

    void Releaserock()
    {
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        Vector3 a = transform.position - LastPos;
        a.Normalize();
        transform.position = transform.position - a * Time.deltaTime * 200f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHitbox"))
        {
            RockPart.transform.SetParent(null);
            RockPart.SetActive(true);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 temp = new Vector3(transform.forward.x, 0, transform.forward.z);
            temp.Normalize();
            player.GetComponent<Rigidbody>().AddForce(temp * 15, ForceMode.Impulse);
            GameObject.Find("HurtTransition").GetComponent<Animator>().SetBool("DmgFade", true);
            player.GetComponent<CurrentStats>().Health -= 20;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            RockPart.transform.SetParent(null);
            RockPart.SetActive(true);
            Destroy(gameObject);
        }
    }
}
