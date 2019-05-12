using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public PlayerController playerController;
    public Animator anim;
    private float H;
    private float V;
    public float JumpTimer = 1, idletimer;
    public bool isJumping = false, death = false, readyToJump;
    public bool Movable = true, Run = true, CD = false;

    void Update()
    {
        //if (playerController.Grounded && playerController.Stamina > 9)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        anim.SetBool("Jump", true);
        //    }
        //}
        if (death)
        {
            anim.SetBool("Die", true);
        }
        if (!death)
        {
            anim.SetBool("Die", false);
        }
        if (Movable)
        {
            if (H > 0.1 && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                CD = true;
                anim.SetFloat("H", H -= Time.deltaTime * 7);
            }
            else if (H < -0.1 && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                CD = true;
                anim.SetFloat("H", H += Time.deltaTime * 7);
            }
            else if (V > 0.1 && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                CD = true;
                anim.SetFloat("V", V -= Time.deltaTime * 7);
            }
            else if (V < -0.1 && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                CD = true;
                anim.SetFloat("V", V += Time.deltaTime * 7);
            }
            else
            {
                CD = false;
            }


            if (CD == false)
            {
                H = Input.GetAxis("Horizontal");
                V = Input.GetAxis("Vertical");

                anim.SetFloat("H", H);
                anim.SetFloat("V", V);
            }
        }

        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.LeftShift) || !Input.GetKey(KeyCode.LeftShift))) // if "W" & "S" is pressed returns back to idle.
        {
            idletimer += Time.deltaTime;
            if (idletimer > 1)
            {
                Movable = false;
                Run = false;
                if (anim.GetFloat("V") >= 0)
                {
                    anim.SetFloat("V", V -= Time.deltaTime);
                }
                else if (anim.GetFloat("V") <= 0)
                {
                    anim.SetFloat("V", V += Time.deltaTime);
                }
                if (anim.GetFloat("H") >= 0)
                {
                    anim.SetFloat("H", H -= Time.deltaTime);
                }
                else if (anim.GetFloat("H") <= 0)
                {
                    anim.SetFloat("H", H += Time.deltaTime);
                }
            }
        }
        else
        {
            Run = true;
            Movable = true;
            idletimer = 0;
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && Run)
        {
            anim.SetBool("Run", true);
        }
        else
            anim.SetBool("Run", false);
    }
}
