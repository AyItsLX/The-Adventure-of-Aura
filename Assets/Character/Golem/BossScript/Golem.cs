using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Golem : MonoBehaviour {

    #region Var
    [Header("Phase")]
    public bool SecondPhase;
    public bool FirstPhase;
    [Header("PhaseChecker")]
    public GameObject BossUI;
    public GameObject PhaseOneTrig;
    public GameObject PeaceArea;
    public GameObject Spawner;
    //public GameObject SpawnTree;
    public GameObject Cannons;
    public int HitBoxChange = 0;
    public bool GolemLookAtPlayer;
    public bool ReadyToThrow;
    public float ThrowMaxTimer = 10f;
    public float ThrowTimer = 0f;
    [Header("Health")]
    public float Health;
    [Header("Shield")]
    public float Shield;
    [Header("Scripts")]
    public CurrentStats CS;
    [Header("GameObjects")]
    public GameObject StaticRock;
    public GameObject MovableRock;
    public GameObject RockBundle;
    public GameObject GolemHead;
    GameObject SpawnedRock;
    [Header("Positions")]
    public Transform PlayerPos;
    public Transform RockSpawn;
    [Header("Phase2HitBox")]
    public GameObject Phase2GameObject;
    public GameObject Numbers;
    public GameObject[] HitBoxPos;
    [Header("Animator")]
    public Animator GolemAnimator;
    public Animator TransitionAnimator;
    [Header("Boss Sliders")]
    public Slider BossHP1;
    public Slider BossHP2;
    public Slider BossShield1;
    public Slider BossShield2;
    public Slider NextHitBoxSlider;
    [Header("Boss Counters")]
    public Text NextHitBox;
    public GameObject hpGB1;
    public GameObject hpGB2;
    public Text hpText1;
    public Text hpText2;
    public Text ShieldText1;
    public Text ShieldText2;
    public GameObject Phase1Cam;
    public static bool RunOnce;
    float groanTimer = 5f;
    public bool golemReady;
    public GameObject DeathCam;
    public GameObject[] Respawns;

    public GameObject Aure;
    public GameObject Aura;
    public CameraController Cam;
    public static bool BossDead = false;
    bool playOnce = false;
    bool playOnce2 = false;

    public GameObject Player1;
    public GameObject Player2;
    public GameManager Manager;
    public Transform Phase1AssistPlayerSpawn;
    #endregion

    #region Awake Function
    void Awake()
    {
        DeathCam.SetActive(false);
        Phase1Cam.SetActive(false);
        BossUI.SetActive(false);
        PhaseOneTrig.SetActive(true);
        Cannons.SetActive(false);
        //SpawnTree.SetActive(false);
        for (int i = 0; i < HitBoxPos.Length; i++)
        {
            HitBoxPos[i].SetActive(false);
        }
        Numbers.SetActive(false);
        Phase2GameObject.SetActive(false);
        SecondPhase = false;
        HitBoxChange = Random.Range(0, 8);
        HitBoxPos[HitBoxChange].SetActive(true);
    }
    #endregion

    #region Start Function
    private void Start()
    {
        CS = GetComponent<CurrentStats>();
        GolemLookAtPlayer = true;
        Shield = 100f;
    }
    #endregion

    void Update()
    {
        GameObject AssistPlayer = GameObject.FindGameObjectWithTag("AssistPlayer");
        if (!playOnce2 && FirstPhase && !SecondPhase && !playOnce)
        {
            playOnce2 = true;
            FindObjectOfType<MusicManager>().Stop("Wind");
            FindObjectOfType<MusicManager>().Play("Battle");
        }
        if (RunOnce)
        {
            RunOnce = false;
            if (Phase1Cam != null)
            {
                Phase1Cam.SetActive(true);
                Destroy(Phase1Cam, 8f);
            }
            AssistPlayer.transform.position = new Vector3(Phase1AssistPlayerSpawn.position.x, Phase1AssistPlayerSpawn.position.y, Phase1AssistPlayerSpawn.position.z);
            PhaseOneTrig.SetActive(false);
            //SpawnTree.SetActive(true);
            PeaceArea.SetActive(false);
            Destroy(Spawner);
            GolemAnimator.SetBool("Taunt", true);
            FindObjectOfType<MusicManager>().Play("BossTaunt");
            StartCoroutine(PausePlayer.PauseCharacterMovement());
        }
        if (FirstPhase)
        {
            if (golemReady)
            {
                GolemAnimator.SetBool("Taunt", false);
                BossUI.SetActive(true);
                Cannons.SetActive(true);
                Numbers.SetActive(true);
                if (!ReadyToThrow && FirstPhase)
                {
                    GolemAnimator.SetBool("P1Throw", false);
                    ThrowTimer += Time.deltaTime;
                    if (ThrowTimer >= ThrowMaxTimer)
                    {
                        ThrowTimer = 0;
                        ReadyToThrow = true;
                    }
                }
                if (ReadyToThrow && FirstPhase)
                {
                    FindObjectOfType<MusicManager>().Play("BossGroan");
                    CameraShaker.Instance.ShakeOnce(8f, 8f, .1f, 5f);
                    GolemAnimator.SetBool("P1Throw", true);
                    ReadyToThrow = false;
                }
            }
        }
        if (SecondPhase)
        {
            Respawns[0].SetActive(false);
            Respawns[1].SetActive(false);
            Respawns[2].SetActive(false);
            Respawns[3].SetActive(false);
            Respawns[4].SetActive(false);
            if (!ReadyToThrow && SecondPhase)
            {
                GolemAnimator.SetBool("P2Throw", false);
                ThrowTimer += Time.deltaTime;
                if (ThrowTimer >= ThrowMaxTimer)
                {
                    ThrowTimer = 0;
                    ReadyToThrow = true;
                }
            }
            if (ReadyToThrow && SecondPhase)
            {
                FindObjectOfType<MusicManager>().Play("BossGroan");
                CameraShaker.Instance.ShakeOnce(8f, 8f, .1f, 5f);
                GolemAnimator.SetBool("P2Throw", true);
                ReadyToThrow = false;
            }
        }

        Health = CS.Health;
        UpdateSliderBar();

        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform; // Constantly check if Player has changed Unit.

        #region LookAtPlayer
        if (GolemLookAtPlayer)
        {
            Vector3 HeadFwd;
            HeadFwd = new Vector3(PlayerPos.transform.position.x, 0, PlayerPos.transform.position.z);
            GolemHead.transform.LookAt(HeadFwd);
        }
        #endregion

        if (Health <= 0) // Check if Boss is dead
        {
            if (!playOnce)
            {
                StartCoroutine(FadeOut(.4f));
                FindObjectOfType<MusicManager>().Play("BossDying");
                playOnce = true;
            }
            Manager.enabled = false;
            Player1.GetComponent<PlayerAnimation>().anim.SetFloat("H", 0);
            Player1.GetComponent<PlayerAnimation>().anim.SetFloat("V", 0);
            Destroy(Player1.GetComponentInChildren<Footstep>());
            //Player1.GetComponent<PlayerAnimation>().enabled = false;
            Player1.GetComponent<PlayerController>().enabled = false;
            Player1.GetComponent<Attack>().enabled = false;
            Destroy(Player2.GetComponentInChildren<Footstep>());
            Player2.GetComponent<PlayerAnimation>().anim.SetFloat("H", 0);
            Player2.GetComponent<PlayerAnimation>().anim.SetFloat("V", 0);
            //Player2.GetComponent<PlayerAnimation>().enabled = false;
            Player2.GetComponent<PlayerController>().enabled = false;
            Player2.GetComponent<Attack>().enabled = false;
            SecondPhase = false;
            FirstPhase = false;
            DeathCam.SetActive(true);
            GolemLookAtPlayer = false;
            GolemAnimator.SetBool("Die", true);
        }
        if (Shield <= 0)
        {
            FirstPhase = false;
            Destroy(BossShield1);
            Destroy(BossShield2);
            TransitionAnimator.SetBool("BossFade", true);
        }

        #region Debug Use Only
        // Debug Use Only.
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    GetComponent<CurrentStats>().Health -= 10;
        //    print("Health :" + Health);
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Shield -= 10;
        //    print("Shield :" + Shield);
        //}
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    golemReady = true;
        //    ReadyToThrow = true;
        //    FirstPhase = true;
        //}
        #endregion

        if (SecondPhase)
        {
            Numbers.SetActive(false);
            Destroy(ShieldText1);
            Destroy(ShieldText2);
            hpGB1.SetActive(true);
            hpGB2.SetActive(true);
            Phase2GameObject.SetActive(true);
        }

        if (HitBoxPos[HitBoxChange] == !isActiveAndEnabled)
        {
            HitBoxChange = Random.Range(0, HitBoxPos.Length);
            HitBoxPos[HitBoxChange].SetActive(true);
        }
    }

    void Throw()
    {
        SpawnedRock = Instantiate(StaticRock, RockSpawn.position, RockSpawn.rotation, RockSpawn) as GameObject;
    }

    public void ReleaseRock()
    {
        Destroy(SpawnedRock);
        Instantiate(MovableRock, RockSpawn.position, RockSpawn.rotation, RockBundle.transform);
    }

    #region UpdateSliderBar
    public void UpdateSliderBar()
    {
        BossHP1.value = Health;
        BossHP2.value = Health;

        BossShield1.value = Shield;
        BossShield2.value = Shield;

        hpText1.text = "Boss Health : " + Health;
        hpText2.text = "Boss Health : " + Health;

        ShieldText1.text = "Boss Shield : " + Shield;
        ShieldText2.text = "Boss Shield : " + Shield;
    }
    #endregion

    IEnumerator FadeOut(float timer)
    {
        FindObjectOfType<MusicManager>().Volume("Battle", 0.1f);
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.1f); // 2
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.1f);
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.1f); // 4
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f);
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f); // 5
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f);
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f); // 6
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f);
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f); // 7
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f);
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f); // 8
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f);
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f); // 9
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Volume("Battle", 0.05f);
        yield return new WaitForSeconds(timer);
        FindObjectOfType<MusicManager>().Stop("Battle"); // 10
    }
}
