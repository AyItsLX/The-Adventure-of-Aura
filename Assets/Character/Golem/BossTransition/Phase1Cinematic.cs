using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1Cinematic : MonoBehaviour {

    public GameObject Text;
    public GameObject Phase1Text;

    private void Awake()
    {
        Text.SetActive(false);
        Phase1Text.SetActive(false);
    }

    void Phase1Cine()
    {
        Golem.RunOnce = true;
        Text.SetActive(true);
        GetComponent<Animator>().SetBool("Phase1Trans", false);
    }

    void Phase1PopUpps()
    {
        Phase1Text.SetActive(true);
    }
}
