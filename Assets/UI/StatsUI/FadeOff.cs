using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOff : MonoBehaviour {

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TurnOffSelf()
    {
        anim.SetBool("DmgFade", false);
    }
}
