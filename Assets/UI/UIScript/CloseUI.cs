using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour {

    AudioSource click;

    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;
    public GameObject Page6;
    public GameObject Page7;

    bool page2;
    bool page3;
    bool page4;
    bool page5;
    bool page6;
    bool page7;

    bool runOnce;

    #region Awake
    void Awake()
    {
        click = GetComponent<AudioSource>();
        GameManager.HelpActivated = false;
        page2 = false;
        page3 = false;
        page4 = false;
        page5 = false;
        page6 = false;
        page7 = false;
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
        Page5.SetActive(false);
        Page6.SetActive(false);
        Page7.SetActive(false);
    }
    #endregion

    private void Start()
    {
        click.Play();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            click.Play();
            Page1.SetActive(false);
            if (page2 == false)
            {
                Page2.SetActive(true);
                page2 = true;
            }
            else if (page3 == false && page2 == true)
            {
                Page2.SetActive(false);
                Page3.SetActive(true);
                page3 = true;
            }
            else if (page4 == false && page3== true)
            {
                Page3.SetActive(false);
                Page4.SetActive(true);
                page4 = true;
            }
            else if (page5 == false && page4 == true)
            {
                Page4.SetActive(false);
                Page5.SetActive(true);
                page5 = true;
            }
            else if (page6 == false && page5 == true)
            {
                Page5.SetActive(false);
                Page6.SetActive(true);
                page6 = true;
            }
            else if (page7 == false && page6 == true)
            {
                Page6.SetActive(false);
                Page7.SetActive(true);
                page7 = true;
            }
            else if (page7 == true && page6 == true)
            {
                GameManager.StoryCont = true;
                GameManager.gm_click.Play();
                GameManager.HelpActivated = true;
                page2 = false;
                page3 = false;
                page4 = false;
                page5 = false;
                page6 = false;
                page7 = false;
                Page1.SetActive(true);
                Page2.SetActive(false);
                Page3.SetActive(false);
                Page4.SetActive(false);
                Page5.SetActive(false);
                Page6.SetActive(false);
                Page7.SetActive(false);
                gameObject.SetActive(false);
            }
        }
	}
}
