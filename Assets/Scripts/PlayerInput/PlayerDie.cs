using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDie : MonoBehaviour {
    [Header("Death Timer")]
    public float DeathTimer;
    public float MaxDeathTimer = 5f;
    [Header("isDead")]
    public bool isDead;
    [Header("Scripts")]
    public Respawn respawn;
    [Header("Timer UI")]
    public GameObject Counter;
    public Text DeathCounter;
    [Header("GameObject")]
    public GameObject Player;
    public GameObject Cam;
    [Header("Animator")]
    public Animator DeathTransition;

    void Awake()
    {
        DeathTimer = MaxDeathTimer;
        Counter.SetActive(false);
    }

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        UpdateUI();

        if (GetComponent<CurrentStats>().Health <= 0)
        {
            GameManager.StopTab = false;
            Counter.SetActive(true);
            Player.transform.GetChild(2).gameObject.SetActive(false);
            GetComponent<PlayerAnimation>().death = true;
            Cam.GetComponent<CameraController>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            GetComponent<Attack>().enabled = false;
            isDead = true;

            if (isDead)
            {
                DeathTimer -= Time.deltaTime;
                if (DeathTimer <= 0)
                {
                    DeathTransition.SetBool("Death", true);
                }
            }
        }

        //if (Input.GetKeyDown(KeyCode.Q)) // Debug Use Only.
        //{
        //    GameObject.Find("HurtTransition").GetComponent<Animator>().SetBool("DmgFade", true);
        //    GetComponent<CurrentStats>().Health -= 50;
        //}
    }

    void UpdateUI()
    {
        DeathCounter.text = "You've Died !\nRespawnin in " + (int)DeathTimer + " ...";
    }
}
