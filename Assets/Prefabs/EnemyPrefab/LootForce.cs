using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootForce : MonoBehaviour {

    public Rigidbody rb;
    public GameObject AIPos;
    Vector3 newPos;
    bool ReadyToTurn = false;

    public GameObject[] Orb;
    bool Up = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.parent = null;
        transform.position = AIPos.transform.position + new Vector3(0, 1.25f, 0);
        Vector3 temp = new Vector3(transform.forward.x + Random.Range(0, 2), Random.Range(0,3), transform.forward.z + Random.Range(0, 2));
        temp.Normalize();
        rb.AddForce(temp * 2, ForceMode.Impulse);
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 20f);

        transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.Sin(Time.time * 1.9f) * 0.005f), transform.position.z);

        //if (ReadyToTurn)
        //{

        //}


        /*
        if (ReadyToTurn)
        {
            if (Up)
            {
                transform.position = transform.position + new Vector3(0, Time.deltaTime, 0);
                if (transform.position.y >= 1)
                {
                    Up = false;
                }
            }
            else if (!Up)
            {
                transform.position = transform.position - new Vector3(0, Time.deltaTime, 0);
                if (transform.position.y <= 0.5f)
                {
                    Up = true;
                }
            }
        }
        */

        //if (ReadyToTurn)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y * Time.deltaTime, transform.position.z);
        //}

        /*
        bool startLerpTime = false;
        float lerpTime = 0;
        float lerpSpeed = 0.01f;

        if (startLerpTime) {
            lerpTime += lerpSpeed;

            if (lerpTime > 1) {
                startLerpTime = false;
                lerpTime = 0;
            }
        }

        float test = Mathf.Lerp(100, 50, lerpTime);
        */

    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "HealthOrb")
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<AudioSource>().Play();
                other.gameObject.GetComponent<CurrentStats>().Health += 10f;
                Destroy(gameObject);
            }
        }
        else if (gameObject.name == "StaminaOrb")
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<AudioSource>().Play();
                other.gameObject.GetComponent<IdleRegeneration>().StaRegen += 1f;
                Destroy(gameObject);
            }
        }
        else if (gameObject.name == "ManaOrb")
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<AudioSource>().Play();
                other.gameObject.GetComponent<IdleRegeneration>().ManaRegen += 1f;
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Ground"))
        {
            ReadyToTurn = true;
            rb.useGravity = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
