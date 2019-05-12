using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlayer : MonoBehaviour {

    public GameObject Player;
    public float number, timer;

    private void Update()
    {
        if (gameObject.name == "FireFairy")
        {
            transform.RotateAround(Player.transform.position, Vector3.up, Time.deltaTime * 100f);
        }
        if (gameObject.name == "IceFairy")
        {
            transform.RotateAround(Player.transform.position, -Vector3.up, Time.deltaTime * 100f);
        }



        timer += Time.deltaTime;
        if (timer >= 2)
        {
            timer = 0;
            number = Random.Range(0f, 2.5f);
        }
    }

    private void FixedUpdate()
    {
        Vector3 nextY = new Vector3(transform.position.x, Player.transform.position.y + number, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, nextY, Time.deltaTime * 1f);
    }
}
