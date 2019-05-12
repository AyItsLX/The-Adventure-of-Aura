using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BossSound : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<MusicManager>().Play("BossGroan");
            CameraShaker.Instance.ShakeOnce(8f, 8f, .1f, 5f);
            gameObject.SetActive(false);
        }
    }
}
