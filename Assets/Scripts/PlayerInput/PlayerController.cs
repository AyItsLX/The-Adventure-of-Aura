using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public Animator anim;
    public PlayerAnimation playerAnimation;
    public ParticleSystem[] Dustie;
    public float MovementSpeed; // default is 0;
    public float Rotation, timer, JumpTimer = 0.0f, Mana = 100, Stamina = 100;
    public float Health;

    public Rigidbody RB;
    public Text HealthBar;
    public bool isForward = true, isBackward = true, isRotating = false, Dust = false , readyToJump;
    public bool Grounded;
    public float jumpHeight = 7, jumpGravity = 5;

    private CurrentStats currentStats;
    public GameObject StaminaCostPrefab;
    #endregion

    #region AwakeFunction
    private void Awake()
    {
        Stamina = 100;
        Mana = 100;

        currentStats = GetComponent<CurrentStats>();
    }
    #endregion

    void Update()
    {
        Mana = Mathf.Clamp(Mana, 0, 100);
        Stamina = Mathf.Clamp(Stamina, 0, 100);
        Health = Mathf.Clamp(Health, 0, 100);
        if (Stamina >= 10)
        {  
            Jump();
        }

        Health = currentStats.Health;
        UpdateHealthUI();

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            Vector3 tempCameraForward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            transform.forward = Vector3.Lerp(transform.forward, tempCameraForward, Time.deltaTime * 5);
        }

        MovementSpeed = transform.GetComponent<CurrentStats>().MovementSpeed;
        KeyboardKeys();

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, 1.3f))
        {
            Grounded = true;
            anim.SetBool("Jump", false);
            //Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.red);
        }
        #region lala
        //else if (Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.TransformDirection(-Vector3.up), out hit, 1.1f))
        //{
        //    Grounded = true;
        //    anim.SetBool("Jump", false);
        //    Debug.DrawRay(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
        //}
        //else if (Physics.Raycast(new Vector3(transform.position.x + -0.5f, transform.position.y, transform.position.z), transform.TransformDirection(-Vector3.up), out hit, 1.1f))
        //{
        //    Grounded = true;
        //    anim.SetBool("Jump", false);
        //    Debug.DrawRay(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
        //}
        //else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), transform.TransformDirection(-Vector3.up), out hit, 1.1f))
        //{
        //    Grounded = true;
        //    anim.SetBool("Jump", false);
        //    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
        //}
        //else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + -0.5f), transform.TransformDirection(-Vector3.up), out hit, 1.1f))
        //{
        //    Grounded = true;
        //    anim.SetBool("Jump", false);
        //    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z + -0.5f), transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
        //}
        #endregion
        else
        {
            Grounded = false;
            anim.SetBool("Jump", true);
            //Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 1000, Color.blue);
        }
    }

    public void UpdateHealthUI()
    {
        HealthBar.text = "Health : " + Health;
    }

    #region KeyboardKeys
    public void KeyboardKeys()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && isForward && !isRotating) // Walk
        {
            transform.Translate(Vector3.forward * 4 * Time.deltaTime);
            isBackward = false;
        }
        else
        {
            isBackward = true;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && playerAnimation.Run) // Run
        {
            if (Grounded)
            {
                Dust = true;
            }
            if (!Grounded)
            {
                Dust = false;
            }
            StartCoroutine(DustPart());
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        }
        else
        {
            Dust = false;
            StartCoroutine(DustPart());
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && isBackward && !isRotating) // Backwards // (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.forward * 2 * Time.deltaTime);
            isForward = false;
        }
        else
        {
            isForward = true;
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * 4 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * 2 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * 4 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * 2 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                isRotating = true;
            }
        }
        else
        {
            isRotating = false;
            timer = 0;
        }
    }
    #endregion

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Stamina -= 10f;
            Instantiate(StaminaCostPrefab, gameObject.transform);
            RB.velocity = Vector3.up * jumpHeight;
        }

        //if (RB.velocity.y > 5)
        //{
            //RB.velocity += new Vector3(RB.velocity.x, 1, RB.velocity.z) * Physics.gravity.y * jumpGravity * Time.deltaTime;
            //RB.velocity = Vector3.up * jumpHeight;
        //}
    }

    #region DustParticle
    IEnumerator DustPart()
    {
        ParticleSystem.EmissionModule emission1 = Dustie[0].emission;
        ParticleSystem.EmissionModule emission2 = Dustie[1].emission;
        //print("The Constant Value Is : " + emission1.rateOverTime.constant);
        //print("The Constant Value Is : " + emission2.rateOverTime.constant);
        if (Dust)
        {
            emission1.rateOverTime = 5;
            emission2.rateOverTime = 5;
            yield return null;
        }
        else if (!Dust)
        {
            emission1.rateOverTime = 0;
            emission2.rateOverTime = 0;
            yield return null;
        }
    }
    #endregion
}