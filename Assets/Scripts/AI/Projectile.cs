using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    #region Var
    [Header("GameObjects/Prefabs")]
    public GameObject Enemy;
    public GameObject EnemyPrefab;
    [Header("Float Values")]
    public float CD;
    public float Damage;
    [Header("Vector3/Transfrom")]
    public Vector3 lastPos;
    [Header("Booleans")]
    public bool move = true;
    #endregion

    void Start ()
    {
        //Enemy = GameObject.FindGameObjectWithTag("Enemy");
        //EnemyPrefab = GameObject.FindGameObjectWithTag("Player");
        //transform.LookAt(EnemyPrefab.transform.position);
    }

    void Update ()
    {
        if (transform.position != lastPos)
        {
            Vector3 dir = transform.position - lastPos;
            transform.forward = dir;
        }
        lastPos = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHitbox"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 temp = new Vector3(transform.forward.x, 0, transform.forward.z);
            temp.Normalize();
            player.GetComponent<Rigidbody>().AddForce(temp * 13, ForceMode.Impulse);
            GameObject.Find("HurtTransition").GetComponent<Animator>().SetBool("DmgFade", true);
            player.GetComponent<CurrentStats>().Health -= Enemy.GetComponent<CurrentStats>().Damage;
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(WaitForEnable());
        }
        else if (other.CompareTag("Ground"))
        {
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(WaitForEnable());
        }
    }

    public IEnumerator WaitForEnable()
    {
        yield return new WaitForSeconds(CD / 1 / 2);
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(CD);
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
        gameObject.transform.position = new Vector3(0, -60, 0);
    }


    //if (Enemy == null) {
    //    print("1");
    //}

    //if (Enemy.GetComponent<CurrentStats>() == null)
    //{
    //    print("2");
    //}

}
