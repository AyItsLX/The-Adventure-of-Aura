using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour {

    public GameObject GM;
    public int GoldCount;

    void Start()
    {
        GM = GameObject.Find("GameManager");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GM.GetComponent<GameManager>().GoldCount += GoldCount;
            Destroy(gameObject);
        }
    }
}
