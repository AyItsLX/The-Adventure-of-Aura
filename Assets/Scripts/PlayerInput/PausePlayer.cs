using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayer : MonoBehaviour {

    public static GameObject p_Player;
    public static Golem gol;

    void Update()
    {
        gol = GameObject.FindGameObjectWithTag("Boss").GetComponent<Golem>();
        p_Player = GameObject.FindGameObjectWithTag("Player");
    }

    public static IEnumerator PauseCharacterMovement()
    {
        p_Player.GetComponentInChildren<Animator>().SetBool("Run", false);
        p_Player.GetComponentInChildren<Animator>().SetFloat("H", 0);
        p_Player.GetComponentInChildren<Animator>().SetFloat("V", 0);
        p_Player.GetComponent<PlayerAnimation>().enabled = false;
        p_Player.GetComponent<PlayerController>().enabled = false;
        p_Player.GetComponent<Attack>().enabled = false;
        yield return new WaitForSeconds(8f);
        p_Player.GetComponent<PlayerAnimation>().enabled = true;
        p_Player.GetComponent<PlayerController>().enabled = true;
        p_Player.GetComponent<Attack>().enabled = true;
        gol.golemReady = true;
    }
}
