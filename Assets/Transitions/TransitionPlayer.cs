using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPlayer : MonoBehaviour {

    public GameManager gameManager;

    public void FadeOut()
    {
        gameManager.isCooldown = false;
        gameManager.FadeAnimator.SetBool("Fade", false);
    }
}
