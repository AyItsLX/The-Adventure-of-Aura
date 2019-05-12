using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCheck : MonoBehaviour {

    public GameObject Unit;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Rigidbody rb = gameObject.GetComponentInParent(typeof(Rigidbody)) as Rigidbody;
            //Unit = GameObject.FindGameObjectWithTag("Enemy");
            Vector3 temp = new Vector3(2, 5, 0);
            rb.GetComponent<Rigidbody>().AddForce(temp, ForceMode.Impulse);
        }
    }
}
