using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1ChatBox : MonoBehaviour {

    public GameObject Aurelia1;
    public GameObject Aurelia2;

    public GameObject Aurav1;
    public GameObject Aurav2;

    private void Start()
    {
        Aurelia1.SetActive(false);
        Aurelia2.SetActive(false);
        Aurav1.SetActive(false);
        Aurav2.SetActive(false);
        StartCoroutine(ChatTimer());
    }

    IEnumerator ChatTimer()
    {
        yield return new WaitForSeconds(2f);
        Aurelia1.SetActive(true);
        yield return new WaitForSeconds(4);
        Aurelia1.SetActive(false);
        yield return new WaitForSeconds(2f);
        Aurav1.SetActive(true);
        yield return new WaitForSeconds(4);
        Aurav1.SetActive(false);
        yield return new WaitForSeconds(2f);
        Aurelia2.SetActive(true);
        yield return new WaitForSeconds(4);
        Aurelia2.SetActive(false);
        yield return new WaitForSeconds(2f);
        Aurav2.SetActive(true);
        yield return new WaitForSeconds(4);
        Aurav2.SetActive(false);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
