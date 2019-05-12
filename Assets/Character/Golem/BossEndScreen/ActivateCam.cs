using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCam : MonoBehaviour {

    public GameObject Startcam;
    public GameObject DeathCam;

    public GameObject CreditScenes;

    public GameObject DeathText;
    public GameObject PlayerUI;
    public GameObject BossUI;

    public GameObject Player1;
    public GameObject Player2;

    private void Awake()
    {
        Startcam.SetActive(false);
        CreditScenes.SetActive(false);
    }

    public void StartCamOn()
    {
        Player1.SetActive(false);
        Player2.SetActive(false);
        DeathText.SetActive(false);
        PlayerUI.SetActive(false);
        BossUI.SetActive(false);
        Startcam.SetActive(true);
        DeathCam.SetActive(false);
    }

    public void CreditsOn()
    {
        CreditScenes.SetActive(true);
    }
}
