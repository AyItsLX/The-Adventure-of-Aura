using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2ChatBoxPop : MonoBehaviour {

    public GameObject Aurelia3;
    public GameObject Aurelia4;

    public GameObject Aurav3;
    public GameObject Aurav4;

    private void Start()
    {
        Aurelia3.SetActive(false);
        Aurelia4.SetActive(false);
        Aurav3.SetActive(false);
        Aurav4.SetActive(false);
        StartCoroutine(ChatTimer());
    }

    IEnumerator ChatTimer()
    {
        yield return new WaitForSeconds(2f);
        Aurelia3.SetActive(true);
        yield return new WaitForSeconds(4);
        Aurelia3.SetActive(false);
        yield return new WaitForSeconds(2f);
        Aurav3.SetActive(true);
        yield return new WaitForSeconds(4);
        Aurav3.SetActive(false);
        yield return new WaitForSeconds(2f);
        Aurelia4.SetActive(true);
        yield return new WaitForSeconds(4);
        Aurelia4.SetActive(false);
        yield return new WaitForSeconds(2f);
        Aurav4.SetActive(true);
        yield return new WaitForSeconds(4);
        Aurav4.SetActive(false);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
