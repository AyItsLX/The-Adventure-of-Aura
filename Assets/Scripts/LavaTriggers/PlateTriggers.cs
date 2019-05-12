using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTriggers : MonoBehaviour {

    public PlateManager Manager = null;

    public void OnTriggerStay(Collider other)
    {
        #region BlueTriggers
        if (gameObject.name == "BluePlate" || gameObject.name == "BluePlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                if (Manager.platforms[0].transform.localPosition.y <= -20)
                {
                    Manager.platforms[0].transform.localPosition += new Vector3(0, Time.deltaTime, 0);
                    Manager.platforms[0].GetComponent<AudioSource>().Play();
                }
                Manager.BluePlate = true;
            }
        }
        #endregion

        #region RedTriggers
        if (gameObject.name == "RedPlate" || gameObject.name == "RedPlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                if (Manager.platforms[1].transform.localPosition.y <= -20)
                {
                    Manager.platforms[1].transform.localPosition += new Vector3(0, Time.deltaTime, 0);
                    Manager.platforms[1].GetComponent<AudioSource>().Play();
                }
                Manager.RedPlate = true;
            }
        }
        #endregion

        #region GreenTriggers
        if (gameObject.name == "GreenPlate" || gameObject.name == "GreenPlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
                if (Manager.platforms[2].transform.localPosition.y <= -20)
                {
                    Manager.platforms[2].transform.localPosition += new Vector3(0, Time.deltaTime, 0);
                    Manager.platforms[2].GetComponent<AudioSource>().Play();
                }
                Manager.GreenPlate = true;
            }
        }
        #endregion

        #region YellowTriggers
        if (gameObject.name == "YellowPlate" || gameObject.name == "YellowPlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
                if (Manager.platforms[3].transform.localPosition.y <= -20)
                {
                    Manager.platforms[3].transform.localPosition += new Vector3(0, Time.deltaTime, 0);
                    Manager.platforms[3].GetComponent<AudioSource>().Play();
                }
                Manager.YellowPlate = true;
            }
        }
        #endregion

        #region PurpleTriggers
        if (gameObject.name == "PurplePlate" || gameObject.name == "PurplePlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.magenta);
                if (Manager.platforms[4].transform.localPosition.y <= -20)
                {
                    Manager.platforms[4].transform.localPosition += new Vector3(0, Time.deltaTime, 0);
                    Manager.platforms[4].GetComponent<AudioSource>().Play();
                }
                Manager.PurplePlate = true;
            }
        }
        #endregion
    }

    public void OnTriggerExit(Collider other)
    {
        #region BlueTriggers
        if (gameObject.name == "BluePlate" || gameObject.name == "BluePlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.grey);
                Manager.BluePlate = false;
            }
        }
        #endregion

        #region RedTriggers
        if (gameObject.name == "RedPlate" || gameObject.name == "RedPlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.grey);
                Manager.RedPlate = false;
            }
        }
        #endregion

        #region GreenTriggers
        if (gameObject.name == "GreenPlate" || gameObject.name == "GreenPlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.grey);
                Manager.GreenPlate = false;
            }
        }
        #endregion

        #region YellowTriggers
        if (gameObject.name == "YellowPlate" || gameObject.name == "YellowPlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.grey);
                Manager.YellowPlate = false;
            }
        }
        #endregion

        #region PurpleTriggers
        if (gameObject.name == "PurplePlate" || gameObject.name == "PurplePlateO")
        {
            if (other.CompareTag("Player") || other.CompareTag("AssistPlayer"))
            {
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.grey);
                Manager.PurplePlate = false;
            }
        }
        #endregion
    }
}
