using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootaArrow : MonoBehaviour {

    [Header("Scripts")]
    public AI aiScripts;
    public AudioSource ShootArrowSound;

    void ShootArrow()
    {
        ShootArrowSound.Play();
        StartCoroutine(aiScripts.Attack());
    }
}
