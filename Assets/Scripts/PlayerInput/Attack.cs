using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{

    public PlayerController playerController;
    public CurrentStats CS;
    public bool IsAttacking = true;
    public bool isReleased = false;
    public GameObject Fire;
    public Transform FireSpawn;
    public float Damage;
    public float AttackSpeed;
    public float CoolDown;

    public GameObject ManaCostPrefab;

    void Update()
    {
        playerController = GetComponent<PlayerController>();

        Damage = CS.Damage;
        AttackSpeed = CS.AttackSpeed;
        CoolDown = CS.CoolDown;

        if (playerController.Mana >= 20)
        {
            StartCoroutine(InitAttack());
        }
    }

    IEnumerator InitAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.Mana -= 20f;
            Instantiate(Fire, FireSpawn.transform.position, FireSpawn.rotation);
            Instantiate(ManaCostPrefab, gameObject.transform);
        }
        yield return null;
    }
}
