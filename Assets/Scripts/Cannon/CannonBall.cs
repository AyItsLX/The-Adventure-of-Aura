using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CannonBall : MonoBehaviour {

    public float CannonDamage = 25f;
    public Transform HitboxRightB;
    public Transform HitboxRightT;
    public Transform HitboxLeftB;
    public Transform HitboxLeftT;
    private void Awake()
    {
        HitboxRightB = GameObject.Find("HB RightBottom").transform;
        HitboxRightT = GameObject.Find("HB RightTop").transform;
        HitboxLeftB = GameObject.Find("HB LeftBottom").transform;
        HitboxLeftT = GameObject.Find("HB LeftTop").transform;
    }

    private void Update()
    {
        if (gameObject.name == "CannonBall 1(Clone)")
        {
            CameraShaker.Instance.ShakeOnce(6f, 6f, .1f, .25f);
            Vector3 a = transform.position - HitboxRightB.position;
            a.Normalize();
            transform.position = transform.position - a * Time.deltaTime * 100f;
        }

        if (gameObject.name == "CannonBall 2(Clone)")
        {
            CameraShaker.Instance.ShakeOnce(6f, 6f, .1f, .25f);
            Vector3 a = transform.position - HitboxLeftB.position;
            a.Normalize();
            transform.position = transform.position - a * Time.deltaTime * 100f;
        }

        if (gameObject.name == "CannonBall 3(Clone)")
        {
            CameraShaker.Instance.ShakeOnce(6f, 6f, .1f, .25f);
            Vector3 a = transform.position - HitboxRightT.position;
            a.Normalize();
            transform.position = transform.position - a * Time.deltaTime * 100f;
        }

        if (gameObject.name == "CannonBall 4(Clone)")
        {
            CameraShaker.Instance.ShakeOnce(6f, 6f, .1f, .25f);
            Vector3 a = transform.position - HitboxLeftT.position;
            a.Normalize();
            transform.position = transform.position - a * Time.deltaTime * 100f;
        }
    }
}
