using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour {

    #region Variables
    [Header("Scripts")]
    public Respawn respawn;

    public Transform m_Left;
    public Transform m_Right;
    #endregion

    void Awake()
    {
        respawn = GetComponentInParent<Respawn>();
        if (respawn == null)
        {
            respawn = GameObject.Find("RespawnTrigger").GetComponent<Respawn>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Respawn1")
        {
            if (other.CompareTag("Player"))
            {
                respawn.RespawnTrigger[0] = true;
                GameObject.Find("Respawn1").GetComponent<BoxCollider>().enabled = false;
            }
        }
        if (gameObject.name == "Respawn2")
        {
            if (other.CompareTag("Player"))
            {
                respawn.RespawnTrigger[1] = true;
                GameObject.Find("Respawn2").GetComponent<BoxCollider>().enabled = false;
            }
        }
        if (gameObject.name == "Respawn3")
        {
            if (other.CompareTag("Player"))
            {
                respawn.RespawnTrigger[2] = true;
                respawn.RespawnTrigger[3] = false;
                respawn.RespawnTrigger[4] = false;
                respawn.RespawnTrigger[5] = false;
                respawn.RespawnTrigger[6] = false;
                respawn.RespawnTrigger[1] = false;
                GameObject.Find("Respawn3").GetComponent<BoxCollider>().enabled = false;
            }
        }
        if (gameObject.name == "Respawn4")
        {
            if (other.CompareTag("Player"))
            {
                respawn.RespawnTrigger[3] = true;
                respawn.RespawnTrigger[2] = false;
                respawn.RespawnTrigger[4] = false;
                respawn.RespawnTrigger[5] = false;
                respawn.RespawnTrigger[6] = false;
                respawn.RespawnTrigger[1] = false;
                GameObject.Find("Respawn4").GetComponent<BoxCollider>().enabled = false;
            }
        }
        if (gameObject.name == "Respawn5")
        {
            if (other.CompareTag("Player"))
            {
                respawn.RespawnTrigger[4] = true;
                respawn.RespawnTrigger[3] = false;
                respawn.RespawnTrigger[2] = false;
                respawn.RespawnTrigger[5] = false;
                respawn.RespawnTrigger[6] = false;
                respawn.RespawnTrigger[1] = false;
                GameObject.Find("Respawn5").GetComponent<BoxCollider>().enabled = false;
            }
        }
        if (gameObject.name == "Respawn6")
        {
            if (other.CompareTag("Player"))
            {
                respawn.RespawnTrigger[5] = true;
                respawn.RespawnTrigger[4] = false;
                respawn.RespawnTrigger[3] = false;
                respawn.RespawnTrigger[2] = false;
                respawn.RespawnTrigger[6] = false;
                respawn.RespawnTrigger[1] = false;
                GameObject.Find("Respawn6").GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (gameObject.name == "Respawn7")
        {
            if (other.CompareTag("Player"))
            {
                respawn.RespawnTrigger[6] = true;
                respawn.RespawnTrigger[5] = false;
                respawn.RespawnTrigger[4] = false;
                respawn.RespawnTrigger[3] = false;
                respawn.RespawnTrigger[2] = false;
                respawn.RespawnTrigger[1] = false;
                GameObject.Find("Respawn7").GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.name == "Respawn8")
        {
            if (other.CompareTag("Player"))
            {
                respawn.RespawnTrigger[7] = true;
                respawn.RespawnTrigger[0] = false;
                respawn.RespawnTrigger[1] = false;
                respawn.RespawnTrigger[2] = false;
                respawn.RespawnTrigger[3] = false;
                respawn.RespawnTrigger[4] = false;
                respawn.RespawnTrigger[5] = false;
                respawn.RespawnTrigger[6] = false;
                respawn.RespawnTrigger[8] = false;
            }
            else if (other.CompareTag("AssistPlayer") && respawn.RespawnTrigger[7] == true)
            {
                //print("Go Right");
                other.transform.position = new Vector3(m_Right.transform.position.x, m_Right.transform.position.y, m_Right.transform.position.z); 
            }
        }

        if (gameObject.name == "Respawn9")
        {
            if (other.CompareTag("Player"))
            {
                respawn.RespawnTrigger[8] = true;
                respawn.RespawnTrigger[0] = false;
                respawn.RespawnTrigger[1] = false;
                respawn.RespawnTrigger[2] = false;
                respawn.RespawnTrigger[3] = false;
                respawn.RespawnTrigger[4] = false;
                respawn.RespawnTrigger[5] = false;
                respawn.RespawnTrigger[6] = false;
                respawn.RespawnTrigger[7] = false;
            }
            else if(other.CompareTag("AssistPlayer") && respawn.RespawnTrigger[8] == true)
            {
                //print("Go Left");
                other.transform.position = new Vector3(m_Left.transform.position.x, m_Left.transform.position.y, m_Left.transform.position.z);
            }
        }
    }
}
