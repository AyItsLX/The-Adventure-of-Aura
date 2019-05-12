using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraController : MonoBehaviour {

    #region Var
    public GameObject player;
    public GameObject player1, player2;

    public GameObject headControl;
    public GameObject headControl1, headControl2;

    public Transform lookAt;
    public Transform camTransform;

    private const float Y_ANGLE_MIN = -5.0f;
    private const float Y_ANGLE_MAX = 30.0f;
    private float Sensitivity = 1;
    private float distance = 12f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public bool camForward;
    float angle;
    Vector3 IntialPos;
    #endregion

    void Start()
    {
        camTransform = transform;
    }

    void Update()
    {
        #region Sensitivity
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            Sensitivity += 0.1f;
            Sensitivity = Mathf.Clamp(Sensitivity, 1f, 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            Sensitivity -= 0.1f;
            Sensitivity = Mathf.Clamp(Sensitivity, 1f, 1.5f);
        }
        #endregion

        #region Zoom in / out
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance++;
            distance = Mathf.Clamp(distance, 7f, 12);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance--;
            distance = Mathf.Clamp(distance, 7f, 12);
        }
        #endregion

        currentX += Input.GetAxis("Mouse X") * Sensitivity;
        if (camForward == true)
        {
            currentY += -Input.GetAxis("Mouse Y") / 10;
        }
        else
            currentY += -Input.GetAxis("Mouse Y") * Sensitivity;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        if (currentY < 0)
        {
            camForward = true;
        }
        else
            camForward = false;

        #region LookForward
        Vector3 tempPlayerFwd;
        Vector3 camHeadFwd;

        IntialPos = player.transform.forward;
        tempPlayerFwd = new Vector3(player.transform.forward.x, 0, player.transform.forward.z);
        camHeadFwd = new Vector3(transform.forward.x, 0, transform.forward.z);
        angle = Vector3.Angle(tempPlayerFwd, camHeadFwd);
        if (angle < 90)
        {
            camHeadFwd = new Vector3(transform.forward.x, 0, transform.forward.z);
            headControl.transform.forward = Vector3.Lerp(headControl.transform.forward, camHeadFwd, Time.deltaTime * 5);
        }
        if (angle > 90)
        {
            headControl.transform.forward = Vector3.Lerp(headControl.transform.forward, IntialPos, Time.deltaTime * 2);
        }
        if (angle > 150)
        {
            headControl.transform.forward = Vector3.Lerp(headControl.transform.forward, -camHeadFwd, Time.deltaTime * 5);
        }
        #endregion
    }

    void LateUpdate()
    {
        if (camForward == false)
        {
            Vector3 dir = new Vector3(0, 1, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);
        }
        else if (camForward == true)
        {
            Vector3 dir = new Vector3(0, 1, -distance);
            dir -= new Vector3(0, 0, currentY);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position + new Vector3(0, -currentY, 0));
        }
    }
}