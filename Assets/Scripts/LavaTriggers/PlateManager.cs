using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateManager : MonoBehaviour {

    [Header("Triggered")]
    public bool BluePlate;
    public bool RedPlate;
    public bool GreenPlate;
    public bool YellowPlate;
    public bool PurplePlate;
    [Header("Platforms")]
    public GameObject[] platforms;

    public void Update()
    {
        #region BlueTriggers
        if ((!BluePlate))
        {
            if (platforms[0].transform.localPosition.y >= -30)
            {
                platforms[0].transform.localPosition -= new Vector3(0, Time.deltaTime, 0);
                platforms[0].GetComponent<AudioSource>().Stop();
            }
        }
        #endregion

        #region RedTriggers
        if ((!RedPlate))
        {
            if (platforms[1].transform.localPosition.y >= -30)
            {
                platforms[1].transform.localPosition -= new Vector3(0, Time.deltaTime, 0);
                platforms[1].GetComponent<AudioSource>().Stop();
            }
        }
        #endregion

        #region GreenTriggers
        if ((!GreenPlate))
        {
            if (platforms[2].transform.localPosition.y >= -40)
            {
                platforms[2].transform.localPosition -= new Vector3(0, Time.deltaTime, 0);
            }
        }
        #endregion

        #region YellowTriggers
        if ((!YellowPlate))
        {
            if (platforms[3].transform.localPosition.y >= -30)
            {
                platforms[3].transform.localPosition -= new Vector3(0, Time.deltaTime , 0);
                platforms[3].GetComponent<AudioSource>().Stop();
            }
        }
        #endregion

        #region PurpleTriggers
        if ((!PurplePlate))
        {
            if (platforms[4].transform.localPosition.y >= -30)
            {
                platforms[4].transform.localPosition -= new Vector3(0, Time.deltaTime, 0);
                platforms[4].GetComponent<AudioSource>().Stop();
            }
        }
        #endregion
    }
}
