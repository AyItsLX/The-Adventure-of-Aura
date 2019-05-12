using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class AI : MonoBehaviour {
    #region Var
    [Header("AutoFill in Runtime")]
    public EnemySpawner enemySpawner;
    public Animator EnemyAnimator; // Enemy's Animator
    public GameObject ArrowBundle;
    public GameObject Projectile_GO;
    public GameObject Player;
    public GameObject EnemyHealthUI; // Rotate Enemy's Health base on Player Location.
    [Header("NavMeshAgent")]
    public NavMeshAgent agent;
    public GameObject rallyPoint;
    [Header("Scripts")]
    public CurrentStats CS;
    [Header("Arrow")]
    public GameObject ProjectilePrefab;
    public GameObject ProjectileFirePoint;
    [Header("Vector3")]
    public Vector3 LookAtPlayer;
    public Vector3 LookAtMoveSpot;
    [Header("Float Values")]
    public float Damage;
    public float Health;
    public float AttackSpeed;
    public float MovementSpeed;
    public float OriginalMovementSpeed;
    public float Range;
    public float CoolDown;
    [Header("Booleans")]
    public bool TargetInRange;
    public bool IsAttacking;
    public bool IsRanged;
    public bool foundPlayer;
    public bool Dying;

    public int Randomizer;
    public GameObject[] Loots;
    public AudioSource DeathSound;
    #endregion

    //public static int TestStaticInt = 0;

    void Awake()
    {
        Loots[0].SetActive(false);
        Loots[1].SetActive(false);
        Loots[2].SetActive(false);
        Dying = false;
        EnemyAnimator = transform.Find("AI_Body").GetComponent<Animator>();
        EnemyHealthUI = transform.Find("Canvas").transform.Find("EnemyHealth").gameObject;
        enemySpawner = GameObject.Find("SpawnerHut").GetComponentInChildren<EnemySpawner>();
        ArrowBundle = GameObject.Find("Arrows");
        Projectile_GO = Instantiate(ProjectilePrefab, ArrowBundle.transform) as GameObject;
        Projectile_GO.GetComponent<Projectile>().Enemy = gameObject;
        Projectile_GO.GetComponent<Projectile>().CD = gameObject.GetComponent<AI>().CoolDown;

        EnemyHealthUI.SetActive(false);
    }

    void Start ()
    {
        Randomizer = Random.Range(0, 3);
        CS = transform.GetComponent<CurrentStats>();
        Projectile_GO.SetActive(false);
        TargetInRange = false;
    }

    void Update ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Range = CS.Range;
        Damage = CS.Damage;
        Health = CS.Health;
        AttackSpeed = CS.AttackSpeed;
        MovementSpeed = CS.MovementSpeed;
        CoolDown = CS.CoolDown;

        EnemyHealthUI.transform.LookAt(Camera.main.transform.position);
        LookAtPlayer = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
        LookAtMoveSpot = new Vector3(rallyPoint.transform.position.x, 0, rallyPoint.transform.position.x);

        if (Health <= 0 && !Dying)
        {
            DeathSound.Play();
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            SpawnLootable();
            EnemyAnimator.SetBool("Death", true);
            Dying = true;

            enemySpawner.SpawnNum += 1;
            Destroy(Projectile_GO);
            Destroy(transform.parent.gameObject, 2f);
        }
        if (!TargetInRange && !foundPlayer && !Dying) // Check if Player is in AI's range of view.
        {
            rallyPoint.SetActive(true);
            transform.LookAt(rallyPoint.transform);
            if (agent.isActiveAndEnabled) // Debug Check
            {
                agent.SetDestination(rallyPoint.transform.position);
            }
        }
        if (TargetInRange && foundPlayer && !Dying) // When AI finds the Player.
        {
            rallyPoint.SetActive(false);
            transform.LookAt(LookAtPlayer);
            if (agent.isActiveAndEnabled) // Debug Check
            {
                agent.SetDestination(Player.transform.position + new Vector3(0, 0, 10));
            }
            EnemyAnimator.SetBool("Aim", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TargetInRange = true;
            foundPlayer = true;
            IsRanged = true;
        }
        else if (other.CompareTag("FireProjectile"))
        {
            EnemyHealthUI.SetActive(true);
        }
    } 

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TargetInRange = false;
        }
    }

    public IEnumerator Attack()
    {
        if (IsAttacking == false && IsRanged == true)
        {
            EnemyAnimator.SetBool("Aim", true);
            agent.isStopped = true; // Stop the AI from moving when shooting.
            IsAttacking = true; // Reset IsAttacking Condition.
            Projectile_GO.SetActive(true);
            Projectile_GO.transform.position = ProjectileFirePoint.transform.position;
            float ArcHeight = 5;
            float InitTime = Time.time;
            Vector3 LastPos = Player.transform.position - new Vector3(0,1,0);
            while (true)
            {
                if (Projectile_GO.transform.position == LastPos)
                {
                    yield return new WaitForSeconds(CoolDown);
                    EnemyAnimator.SetBool("Aim", false);
                    IsAttacking = false; // Reset IsAttacking Condition.
                    break;
                }
                Vector3 CurrentPos = Vector3.Lerp(ProjectileFirePoint.transform.position, LastPos, (Time.time - InitTime) / AttackSpeed);
                CurrentPos.y += ArcHeight * Mathf.Sin(Mathf.Clamp01((Time.time - InitTime) / AttackSpeed) * Mathf.PI);
                Projectile_GO.transform.position = CurrentPos;
                yield return new WaitForFixedUpdate();
            }
            agent.isStopped = false; // Resume AI's walking.
        }
    }

    void SpawnLootable()
    {
        GameObject Drop = Loots[Randomizer];
        Drop.SetActive(true);
    }

    //void OnDestroy()
    //{
    //    Destroy(Projectile_GO);
    //}
}
