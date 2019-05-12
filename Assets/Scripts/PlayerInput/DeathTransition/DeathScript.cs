using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    public PlayerDie playerDie;

    void Update()
    {
        playerDie = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDie>();
    }

    void DeathTransition()
    {
        playerDie.Counter.SetActive(false);
        playerDie.Player.transform.GetChild(2).gameObject.SetActive(true);
        playerDie.GetComponent<PlayerAnimation>().death = false;
        playerDie.Cam.GetComponent<CameraController>().enabled = true;
        playerDie.GetComponent<PlayerController>().enabled = true;
        playerDie.GetComponent<Attack>().enabled = true;

        playerDie.GetComponent<CurrentStats>().Health = 100f;
        playerDie.Player.transform.position = playerDie.respawn.RespawnPoint;
        GameManager.StopTab = true;

        playerDie.isDead = false;
        playerDie.DeathTimer = playerDie.MaxDeathTimer;
        playerDie.DeathTransition.SetBool("Death", false);
    }
}
