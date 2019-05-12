using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
using EZCameraShake;

public class GameManager : MonoBehaviour {

    #region Var
    [Header("Character Switch")]
    public bool isCooldown;
    [Header("Aurelia is On")]
    public bool Aurelia = true;
    public bool AureliaIsFollowing = false;
    [Header("Aurav is On")]
    public bool Aurav = false;
    public bool AuravIsFollowing = false;
    [Header("Scripts")]
    public Attack attack;
    public CameraController camScript;
    public AI aiScript;
    public Golem golem;
    [Header("PlayerUnits")]
    public GameObject AureliaUnit;
    public GameObject AuravUnit;
    [Header("Animator")]
    public Animator FadeAnimator;
    [Header("Animations")]
    public RuntimeAnimatorController IdleOnly;
    public RuntimeAnimatorController UnitAnimations;
    [Header("UI")]
    public GameObject AureliaUI;
    public GameObject AuravUI;
    [Header("Others")]
    public GameObject Enemies;
    public bool CheckSpawner = false;
    public int GoldCount;
    public GameObject BP;
    public static bool isStarted;
    public static bool GamePause = false;
    public GameObject PauseMenuUI;
    public GameObject StartMenuUI;
    public GameObject player;
    private bool TransitionStart;
    public GameObject CamLight;
    public StartCinematic cinematic;
    public bool RunOnce;

    [SerializeField]
    private float TimeLapsed;

    public static bool MsgUITrigger;
    public static bool HelpActivated;
    private float MsgUITimer;
    public GameObject MsgUI;
    public GameObject Instructor;
    public static AudioSource gm_click;
    public static bool StopTab = true;
    public static bool StoryCont;
    bool runOnceOnly;
    public GameObject StoryText1;
    public GameObject Phase1Pop;
    public GameObject Phase1Chatsetoff;
    public GameObject Phase2Chatsetoff;
    #endregion

    #region Awake
    void Awake()
    {
        Phase2Chatsetoff.SetActive(false);
        Phase1Chatsetoff.SetActive(false);
        StoryText1.SetActive(false);
        runOnceOnly = false;
        StoryCont = false;
        StopTab = true;
        gm_click = GetComponent<AudioSource>();
        Instructor.SetActive(false);
        MsgUITrigger = false;
        MsgUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isStarted = false;
        CamLight.SetActive(true);
        StartMenuUI.SetActive(true);
        Switch();
        //AI.TestStaticInt = 5;
    }
    #endregion

    void Update()
    {
        TimeLapsed += Time.deltaTime;

        #region Message UI Triggers
        if (MsgUITrigger)
        {
            MsgUITimer += Time.deltaTime;
            if (MsgUITimer > 7f)
            {
                MsgUI.SetActive(true);
                MsgUITrigger = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.T) && HelpActivated && Instructor.activeInHierarchy == false)
        {
            gm_click.Play();
            Instructor.SetActive(true);
        }
        else if (StoryCont && !runOnceOnly)
        {
            runOnceOnly = true;
            StartCoroutine(WaitFor1Sec());
        }
        #endregion

        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        //}
        //if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Period))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}

        attack = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        player = GameObject.FindGameObjectWithTag("Player");

        #region Check if which twin is alive and parent guide to it.
        if (player == Aurelia)
        {
            Instructor.gameObject.transform.SetParent(player.transform);
            Instructor.transform.localPosition = new Vector3(0, 0, 0);
            Instructor.transform.localRotation = new Quaternion(0, 0, 0, 0);
            Phase1Pop.gameObject.transform.SetParent(player.transform);
            Phase1Pop.transform.localPosition = new Vector3(0, 0, 0);
            Phase1Pop.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        if (player == Aurav)
        {
            Instructor.gameObject.transform.SetParent(player.transform);
            Instructor.transform.localPosition = new Vector3(0, 0, 0);
            Instructor.transform.localRotation = new Quaternion(0, 0, 0, 0);
            Phase1Pop.gameObject.transform.SetParent(player.transform);
            Phase1Pop.transform.localPosition = new Vector3(0, 0, 0);
            Phase1Pop.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        #endregion

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.M))
        {
            MsgUITrigger = true;
            StartCinematic.PlayThis = false;
            cinematic.W1.SetActive(false);
            cinematic.W2.SetActive(false);
            cinematic.W3.SetActive(false);
            cinematic.W4.SetActive(false);
            cinematic.StartCutscene();
        }

        if (!isStarted && !RunOnce)
        {
            camScript.enabled = false;
            attack = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
            player.GetComponent<PlayerAnimation>().enabled = false;
            player.GetComponent<PlayerController>().enabled = false;
            attack.enabled = false;
        }
        else if (isStarted && !GamePause && !RunOnce)
        {
            CamLight.SetActive(false);
            camScript.enabled = true;
            player.GetComponent<PlayerAnimation>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            attack.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            RunOnce = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isStarted)
        {
            attack.enabled = false;
            camScript.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GamePause = true;
            if (GamePause)
            {
                PauseMenuUI.SetActive(true);
            }

            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0;
            }
        }
        if (CheckSpawner)
        {
            if (GameObject.Find("Spawner") == !isActiveAndEnabled)
            {
                //GameObject[] enemyLongList = GameObject.FindGameObjectsWithTag("Enemy");

                for (int i = 0; i <= 10; ++i)
                {
                    Enemies = GameObject.Find("EnemyLongPrefab(Clone)");
                    Destroy(Enemies);
                }
                if (Enemies == null)
                {
                    CheckSpawner = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) && Aurelia == true && Aurav == false && !isCooldown && isStarted && StopTab)
        {
            isCooldown = true;
            FadeAnimator.SetBool("Fade", true);
            StartCoroutine(FadeOut1());
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && Aurav == true && Aurelia == false && !isCooldown && isStarted && StopTab)
        {
            isCooldown = true;
            FadeAnimator.SetBool("Fade", true);
            StartCoroutine(FadeOut2());
        }

        #region Check who is active
        if (Aurelia)
        {
            if (Input.GetKeyDown(KeyCode.F) && !AuravIsFollowing && (!golem.FirstPhase && !golem.SecondPhase))
            {
                AuravIsFollowing = true;
            }
            else if (Input.GetKeyDown(KeyCode.F) && AuravIsFollowing && (!golem.FirstPhase && !golem.SecondPhase))
            {
                AuravIsFollowing = false;
            }
        }
        if (Aurav)
        {
            if (Input.GetKeyDown(KeyCode.F) && !AureliaIsFollowing && (!golem.FirstPhase && !golem.SecondPhase))
            {
                AureliaIsFollowing = true;
            }
            else if (Input.GetKeyDown(KeyCode.F) && AureliaIsFollowing && (!golem.FirstPhase && !golem.SecondPhase))
            {
                AureliaIsFollowing = false;
            }
        }

        if (AuravIsFollowing)
        {
            AuravUnit.GetComponent<NavMeshAgent>().enabled = true;
            AureliaUnit.GetComponent<NavMeshObstacle>().enabled = true;
            AuravUnit.GetComponent<PlayerAI>().enabled = true;
        }
        else if (!AuravIsFollowing)
        {
            AuravUnit.GetComponentInChildren<Animator>().SetBool("Run", false);
            AuravUnit.GetComponent<NavMeshAgent>().enabled = false;
            AureliaUnit.GetComponent<NavMeshObstacle>().enabled = false;
            AuravUnit.GetComponent<PlayerAI>().enabled = false;
        }

        if (AureliaIsFollowing)
        {
            AureliaUnit.GetComponent<NavMeshAgent>().enabled = true;
            AuravUnit.GetComponent<NavMeshObstacle>().enabled = true;
            AureliaUnit.GetComponent<PlayerAI>().enabled = true;
        }
        else if (!AureliaIsFollowing)
        {
            AureliaUnit.GetComponentInChildren<Animator>().SetBool("Run", false);
            AureliaUnit.GetComponent<NavMeshAgent>().enabled = false;
            AuravUnit.GetComponent<NavMeshObstacle>().enabled = false;
            AureliaUnit.GetComponent<PlayerAI>().enabled = false;
        }
        #endregion
    }

    IEnumerator WaitFor1Sec()
    {
        yield return new WaitForSeconds(1f);
        StoryText1.SetActive(true);
    }

    #region FadeTransition
    public IEnumerator FadeOut1()
    {
        yield return new WaitForSeconds(1f);
        Aurav = true;
        Aurelia = false;

        if (AuravIsFollowing)
        {
            AuravIsFollowing = false;
        }

        AureliaUI.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

        Switch();
    }

    public IEnumerator FadeOut2()
    {
        yield return new WaitForSeconds(1f);
        Aurelia = true;
        Aurav = false;

        if (AureliaIsFollowing)
        {
            AureliaIsFollowing = false;
        }

        Switch();
    }
    #endregion

    #region Switch Character
    public void Switch()
    {
        if (Aurelia == true)
        {
            camScript.player = camScript.player1;
            camScript.headControl = camScript.headControl1;
            camScript.lookAt = camScript.player1.transform;

            AureliaUnit.tag = "Player";
            AureliaUnit.transform.Find("PlayerHitbox").gameObject.SetActive(true);

            AuravUI.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            AureliaUnit.GetComponentInChildren<Animator>().runtimeAnimatorController = UnitAnimations;
            AureliaUnit.GetComponent<PlayerAnimation>().enabled = true;
            AureliaUnit.GetComponent<PlayerController>().enabled = true;
            AureliaUnit.GetComponent<Attack>().enabled = true;
            AureliaUnit.GetComponent<CurrentStats>().enabled = true;
            AureliaUnit.GetComponent<PlayerDie>().enabled = true;
        }
        else
        {
            AureliaUnit.tag = "AssistPlayer";
            AureliaUnit.transform.Find("PlayerHitbox").gameObject.SetActive(false);

            AuravUI.transform.localScale = new Vector3(1, 1, 1);

            AureliaUnit.GetComponentInChildren<Animator>().runtimeAnimatorController = IdleOnly;
            AureliaUnit.GetComponent<PlayerAnimation>().enabled = false;
            AureliaUnit.GetComponent<PlayerController>().enabled = false;
            AureliaUnit.GetComponent<Attack>().enabled = false;
            AureliaUnit.GetComponent<CurrentStats>().enabled = false;
            AureliaUnit.GetComponent<PlayerDie>().enabled = false;
        }

        if (Aurav == true)
        {
            camScript.player = camScript.player2;
            camScript.headControl = camScript.headControl2;
            camScript.lookAt = camScript.player2.transform;

            AuravUnit.tag = "Player";
            AuravUnit.transform.Find("PlayerHitbox").gameObject.SetActive(true);

            AureliaUI.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            AuravUnit.GetComponentInChildren<Animator>().runtimeAnimatorController = UnitAnimations;
            AuravUnit.GetComponent<PlayerAnimation>().enabled = true;
            AuravUnit.GetComponent<PlayerController>().enabled = true;
            AuravUnit.GetComponent<Attack>().enabled = true;
            AuravUnit.GetComponent<CurrentStats>().enabled = true;
            AuravUnit.GetComponent<PlayerDie>().enabled = true;
        }
        else
        {
            AuravUnit.tag = "AssistPlayer";
            AuravUnit.transform.Find("PlayerHitbox").gameObject.SetActive(false);

            AureliaUI.transform.localScale = new Vector3(1, 1, 1);

            AuravUnit.GetComponentInChildren<Animator>().runtimeAnimatorController = IdleOnly;
            AuravUnit.GetComponent<PlayerAnimation>().enabled = false;
            AuravUnit.GetComponent<PlayerController>().enabled = false;
            AuravUnit.GetComponent<Attack>().enabled = false;
            AuravUnit.GetComponent<CurrentStats>().enabled = false;
            AuravUnit.GetComponent<PlayerDie>().enabled = false;
        }
    }
    #endregion
}
