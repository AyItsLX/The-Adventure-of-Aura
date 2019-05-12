using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyImpact : MonoBehaviour {

    AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.Play();
    }

    void Update () {
        Destroy(gameObject, 1f);
	}
}
