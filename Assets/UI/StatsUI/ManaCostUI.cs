using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaCostUI : MonoBehaviour {

    GameObject Player;
    Rigidbody rb;
    Vector3 RandomizeIntensity = new Vector3(1f, 0, 0);

    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        Destroy(gameObject, 3f);
        transform.localPosition += new Vector3(0, 1.5f, -1.5f);
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x), 
            Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
            Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));
	}
}
