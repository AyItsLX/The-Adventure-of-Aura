using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    private bool StartCredits = false;
    public StartMenu Menu;

    private void Awake()
    {
        StartCredits = true;
        transform.localPosition = new Vector3(0, -1850, 0);
    }

    void Update()
    {
        if (StartCredits)
        {
            transform.position = transform.position + new Vector3(0, Time.deltaTime * 60f, 0);
        }

        if (gameObject.name == "Credits")
        {
            if (transform.localPosition.y > 1800)
            {
                StartCredits = false;
                Menu.OnReturnPressed();
            }
        }

        else if (gameObject.name == "Credits2")
        {
            if (transform.localPosition.y > 2500)
            {
                StartCredits = false;
                if (gameObject.name == "Credits2")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }



    }
}
