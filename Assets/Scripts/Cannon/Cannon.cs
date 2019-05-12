using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject[] CannonBallPrefab;
    public GameObject BallLaunchParticle;
    public GameObject[] Numbers;

    public Animator CannonAnimator;

    public Transform LaunchPos;

    void FireCannon1()
    {
        Instantiate(CannonBallPrefab[0], LaunchPos.position, LaunchPos.rotation);
        Numbers[0].SetActive(false);
        Instantiate(BallLaunchParticle, LaunchPos.position, LaunchPos.rotation);
        CannonAnimator.SetBool("Fire", false);
    }

    void FireCannon2()
    {
        Instantiate(CannonBallPrefab[1], LaunchPos.position, LaunchPos.rotation);
        Numbers[1].SetActive(false);
        Instantiate(BallLaunchParticle, LaunchPos.position, LaunchPos.rotation);
        CannonAnimator.SetBool("Fire", false);
    }

    void FireCannon3()
    {
        Instantiate(CannonBallPrefab[2], LaunchPos.position, LaunchPos.rotation);
        Numbers[2].SetActive(false);
        Instantiate(BallLaunchParticle, LaunchPos.position, LaunchPos.rotation);
        CannonAnimator.SetBool("Fire", false);
    }

    void FireCannon4()
    {
        Instantiate(CannonBallPrefab[3], LaunchPos.position, LaunchPos.rotation);
        Numbers[3].SetActive(false);
        Instantiate(BallLaunchParticle, LaunchPos.position, LaunchPos.rotation);
        CannonAnimator.SetBool("Fire", false);
    }

    void CannonDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "FuseTrigger1")
        {
            if (other.CompareTag("FireProjectile"))
            {
                if (!CannonAnimator.GetBool("Fire"))
                {
                    CannonAnimator.SetBool("Fire", true);
                    gameObject.SetActive(false);
                }
            }
        }

        if (gameObject.name == "FuseTrigger2")
        {
            if (other.CompareTag("FireProjectile"))
            {
                if (!CannonAnimator.GetBool("Fire"))
                {
                    CannonAnimator.SetBool("Fire", true);
                    gameObject.SetActive(false);
                }
            }
        }

        if (gameObject.name == "FuseTrigger3")
        {
            if (other.CompareTag("FireProjectile"))
            {
                if (!CannonAnimator.GetBool("Fire"))
                {
                    CannonAnimator.SetBool("Fire", true);
                    gameObject.SetActive(false);
                }
            }
        }

        if (gameObject.name == "FuseTrigger4")
        {
            if (other.CompareTag("FireProjectile"))
            {
                if (!CannonAnimator.GetBool("Fire"))
                {
                    CannonAnimator.SetBool("Fire", true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
