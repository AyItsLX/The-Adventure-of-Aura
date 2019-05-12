using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAnimation : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInChildren<Animator>().SetBool("Fall", true);
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            other.gameObject.GetComponent<Attack>().enabled = false;
        }
    }
}
