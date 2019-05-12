using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name.Equals("BluePlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(gameObject.transform);
            }
        }

        if (gameObject.name.Equals("GreenPlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(gameObject.transform);
            }
        }

        if (gameObject.name.Equals("PurplePlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(gameObject.transform);
            }
        }

        if (gameObject.name.Equals("RedPlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(gameObject.transform);
            }
        }

        if (gameObject.name.Equals("YellowPlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(gameObject.transform);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.name.Equals("BluePlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(null);
            }
        }

        if (gameObject.name.Equals("GreenPlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(null);
            }
        }

        if (gameObject.name.Equals("PurplePlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(null);
            }
        }

        if (gameObject.name.Equals("RedPlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(null);
            }
        }

        if (gameObject.name.Equals("YellowPlatform"))
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "AssistPlayer")
            {
                collision.gameObject.transform.SetParent(null);
            }
        }
    }
}
