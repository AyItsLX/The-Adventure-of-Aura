using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBox : MonoBehaviour {

    public CannonBall cannonBall;
    public GameObject Boss;

    void Update()
    {
        //cannonBall = GameObject.FindGameObjectWithTag("CannonBall").GetComponent<CannonBall>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CannonBall"))
        {
            FindObjectOfType<MusicManager>().Play("BossPain");
            Boss.GetComponent<Golem>().Shield -= 25f;
            Destroy(other.gameObject);
        }
    }
}
