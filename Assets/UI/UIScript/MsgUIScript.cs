using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgUIScript : MonoBehaviour {

    public GameObject Instruct1;

    bool Struct1 = false;

    #region Awake
    void Awake()
    {
        Instruct1.SetActive(false);
    }
    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Struct1 == false)
            {
                Instruct1.SetActive(true);
                Struct1 = true;
            }
            gameObject.SetActive(false);
        }
    }
}
