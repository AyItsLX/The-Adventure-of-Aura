using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveSpot : MonoBehaviour {

    public float unabletoreach;
    public float unabletoreachtimer;
    public float waitTime;
    public float startWaitTime;
    public float minX, maxX, minY, maxY, minZ, maxZ;
    public Transform move_Spot;
    public Transform myself;
    public NavMeshAgent agent;
    public Vector3 movetwds;
    public GameObject Unit;

    void Start () {
        unabletoreachtimer = unabletoreach;
        waitTime = startWaitTime;
        move_Spot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        movetwds = move_Spot.position;
    }
	
	void Update () {
        //Vector3 movetwds = Vector3.MoveTowards(myself.position, move_Spot.position, speed * Time.deltaTime);
        unabletoreachtimer -= Time.deltaTime;
        if (unabletoreachtimer <= 0f)
        { 
            move_Spot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            movetwds = move_Spot.position;
            unabletoreachtimer = unabletoreach;
        }
        if (Vector3.Distance(Unit.transform.position, move_Spot.position) < 4f)
        {
            unabletoreachtimer = unabletoreach;
            if (waitTime <= 2f)
            {
                move_Spot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                movetwds = move_Spot.position;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            //print("Hit Tree");
            move_Spot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            movetwds = move_Spot.position;
        }
    }
}
