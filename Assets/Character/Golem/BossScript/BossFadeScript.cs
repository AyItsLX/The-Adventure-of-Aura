using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFadeScript : MonoBehaviour {

    #region Var
    [Header("Script")]
    public Golem golem;
    [Header("LastFightPlatform")]
    public GameObject SpawnLastPlatform;
    [Header("PlayerPos")]
    public Transform Aurelia;
    public Transform Aurav;
    [Header("PlayerSpawn")]
    public Transform AureliaPos;
    public Transform AuravPos;

    public GameObject Phase2Chatseton;
    #endregion

    #region Awake Function
    private void Awake()
    {
        SpawnLastPlatform.SetActive(false);
    }
    #endregion

    public void BossFade()
    {
        Phase2Chatseton.SetActive(true);
        SpawnLastPlatform.SetActive(true);
        Aurelia.rotation = AureliaPos.rotation;
        Aurelia.position = new Vector3(AureliaPos.position.x, AureliaPos.position.y, AureliaPos.position.z);
        Aurav.rotation = AuravPos.rotation;
        Aurav.position = new Vector3(AuravPos.position.x, AuravPos.position.y, AuravPos.position.z);
        golem.SecondPhase = true;
    }
}
