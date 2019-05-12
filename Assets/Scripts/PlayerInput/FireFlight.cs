using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlight : MonoBehaviour {

    public AI ai;
    public GameObject Player;
    public Rigidbody Target;
    public GameObject ImpactPrefab;
    AudioSource audiosource;

    public void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Timer());
        audiosource.Play();
    }

    public void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 30);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(ImpactPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitBox"))
        {
            Target = other.gameObject.GetComponentInParent(typeof(Rigidbody)) as Rigidbody;
            Target.GetComponent<CurrentStats>().Health -= Player.GetComponent<CurrentStats>().Damage;
            Vector3 temp = new Vector3(transform.forward.x, 0, transform.forward.z);
            temp.Normalize();
            Target.GetComponent<Rigidbody>().AddForce(temp * 12, ForceMode.Impulse);
            Instantiate(ImpactPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Instantiate(ImpactPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
