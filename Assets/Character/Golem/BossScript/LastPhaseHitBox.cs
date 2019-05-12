using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class LastPhaseHitBox : MonoBehaviour {

    public Golem golem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireProjectile"))
        {
            CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, 2f);
            FindObjectOfType<MusicManager>().Play("BossPain");
            golem.GetComponent<CurrentStats>().Health -= 10;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
