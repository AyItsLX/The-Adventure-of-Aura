using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public GameObject StartUI;
    public GameObject CreditsUI;
    public GameObject ReturnMenu;

    public GameObject StartMenus;
    public GameObject PlayerUI;

    public Animator StartAnimator;

    private void Awake()
    {
        PlayerUI.SetActive(false);
        StartUI.SetActive(true);
        StartMenus.SetActive(true);
        CreditsUI.SetActive(false);
        ReturnMenu.SetActive(false);
    }

    public void OnStartPressed()
    {
        StartUI.SetActive(false);
        StartCoroutine(FadeOut());
        StartAnimator.SetBool("Start", true);
        FindObjectOfType<MusicManager>().Play("Forest");
    }
    public void OnQuitPressed()
    {
        Application.Quit();
    }
    public void OnCreditsPressed()
    {
        StartMenus.SetActive(false);
        CreditsUI.SetActive(true);
        ReturnMenu.SetActive(true);
    }
    public void OnReturnPressed()
    {
        StartMenus.SetActive(true);
        CreditsUI.SetActive(false);
        ReturnMenu.SetActive(false);
    }

    public IEnumerator RockSlide()
    {
        FindObjectOfType<MusicManager>().Play("RockSlide");
        yield return new WaitForSeconds(5f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.05f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.05f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.05f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.05f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.05f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.05f);
        yield return new WaitForSeconds(.75f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.05f);
        yield return new WaitForSeconds(.75f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.05f);
        yield return new WaitForSeconds(.75f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.05f);
        yield return new WaitForSeconds(.75f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.01f);
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.01f);
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.01f);
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.01f);
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<MusicManager>().Volume("RockSlide", 0.01f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Stop("RockSlide");
    }

    IEnumerator FadeOut()
    {
        FindObjectOfType<MusicManager>().Volume("Opening", 0.020f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("Opening", 0.020f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("Opening", 0.020f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("Opening", 0.010f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("Opening", 0.010f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("Opening", 0.005f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Volume("Opening", 0.005f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MusicManager>().Stop("Opening");
    }
}
