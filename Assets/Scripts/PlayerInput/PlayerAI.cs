using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour {

    public GameObject PlayerPos;

    public Animator PlayerAIAnimator;

    public float xPos, zPos, timer;

    public Vector3 AIPos;

    public NavMeshAgent PlayerAgent;

    void Awake()
    {
        xPos = Random.Range(-7, 7);
        zPos = Random.Range(-5, 5);
    }

    void Update()
    {
        PlayerAIAnimator = GetComponentInChildren<Animator>();
        PlayerAgent = GetComponent<NavMeshAgent>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player");

        timer += Time.deltaTime;
        if (timer >= 5)
        {
            timer = 0;
            xPos = Random.Range(-7, 7);
            zPos = Random.Range(-5, 5);
        }

        PlayerAgentOn();
    }

    public void PlayerAgentOn()
    {
        AIPos = new Vector3(PlayerPos.transform.position.x, 0, PlayerPos.transform.position.z);
        //print("AIPos :" + AIPos);
        PlayerAIAnimator.SetBool("Run", true);
        PlayerAgent.SetDestination(AIPos + new Vector3(xPos, 0, zPos));

        if (transform.position.x == PlayerAgent.destination.x)
        {
            PlayerAIAnimator.SetBool("Run", false);
        }
    }
}
