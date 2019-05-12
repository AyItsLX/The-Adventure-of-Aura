using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWind : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<MusicManager>().Play("Wind");
            gameObject.SetActive(false);
        }
    }
}
