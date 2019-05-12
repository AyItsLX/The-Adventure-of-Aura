using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1PopUp : MonoBehaviour {

    public GameObject InactiveThis;
    public GameObject ActivateThis;

    private void Awake()
    {
        ActivateThis.SetActive(false);
    }

    void Inactive()
    {
        ActivateThis.SetActive(true);
        InactiveThis.SetActive(false);
    }
}
