using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour {

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    private void Awake()
    {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name.Equals("Trig1"))
        {
            if (other.CompareTag("Player"))
            {
                image1.SetActive(true);
            }
        }

        if (gameObject.name.Equals("Trig2"))
        {
            if (other.CompareTag("Player"))
            {
                image2.SetActive(true);
            }
        }

        if (gameObject.name.Equals("Trig3"))
        {
            if (other.CompareTag("Player"))
            {
                image3.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name.Equals("Trig1"))
        {
            if (other.CompareTag("Player"))
            {
                image1.SetActive(false);
            }
        }

        if (gameObject.name.Equals("Trig2"))
        {
            if (other.CompareTag("Player"))
            {
                image2.SetActive(false);
            }
        }

        if (gameObject.name.Equals("Trig3"))
        {
            if (other.CompareTag("Player"))
            {
                image3.SetActive(false);
            }
        }
    }

}
