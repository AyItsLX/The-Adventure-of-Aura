using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerLava : MonoBehaviour {

    public GameObject Player;
    public PlayerController playerController;

    public void Update()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.GetComponentInChildren<Animator>().SetBool("Fall", false);
            Player.GetComponent<CurrentStats>().Health = 0;
            playerController.HealthBar.text = "Health : " + Player.GetComponent<CurrentStats>().Health;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.GetComponentInChildren<Animator>().SetBool("Fall", false);
            Player.GetComponent<CurrentStats>().Health = 0;
            playerController.HealthBar.text = "Health : " + Player.GetComponent<CurrentStats>().Health;
        }
    }
}
