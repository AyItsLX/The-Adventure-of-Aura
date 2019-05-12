using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    [Header("Spawn Point")]
    public Vector3 RespawnPoint;
    [Header("Spawn Triggers")]
    public bool[] RespawnTrigger;

    void Awake()
    {
        for (int i = 0; i < RespawnTrigger.Length; i++)
        {
            RespawnTrigger[i] = false;
        }
    }

    void Update()
    {
        if (RespawnTrigger[0])
        {
            RespawnPoint = GameObject.Find("Respawn1").transform.position;
        }
        if (RespawnTrigger[1])
        {
            RespawnPoint = GameObject.Find("Respawn2").transform.position;
        }
        if (RespawnTrigger[2])
        {
            RespawnPoint = GameObject.Find("Respawn3").transform.position;
        }
        if (RespawnTrigger[3])
        {
            RespawnPoint = GameObject.Find("Respawn4").transform.position;
        }
        if (RespawnTrigger[4])
        {
            RespawnPoint = GameObject.Find("Respawn5").transform.position;
        }
        if (RespawnTrigger[5])
        {
            RespawnPoint = GameObject.Find("Respawn6").transform.position;
        }
        if (RespawnTrigger[6])
        {
            RespawnPoint = GameObject.Find("Respawn7").transform.position;
        }
        if (RespawnTrigger[7])
        {
            RespawnPoint = GameObject.Find("Respawn8").transform.position;
        }
        if (RespawnTrigger[8])
        {
            RespawnPoint = GameObject.Find("Respawn9").transform.position;
        }
    }

}
