using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIRenderHealthBar : MonoBehaviour {

    public GameObject Player;
    public GameObject HealthBarPos;
    public Slider AIHealthBarPrefab;
    public Slider AIHealthBar;
    public GameObject Canvas;
    
	void Start ()
    {
        Player = GameObject.Find("Player");
        Canvas = GameObject.Find("Canvas");
        AIHealthBar = Instantiate(AIHealthBarPrefab) as Slider;
        AIHealthBar.transform.SetParent(Canvas.transform, false);
        HealthBarPos = transform.Find("HealthBarPos").gameObject;
        AIHealthBar.gameObject.SetActive(false); 
    }
	
	void Update ()
    {
        AIHealthBar.transform.position = Camera.main.WorldToScreenPoint(HealthBarPos.transform.position);
        AIHealthBar.value = transform.GetComponent<CurrentStats>().HealthBarValue;
        ToggleHealthBar();
    }

    void ToggleHealthBar()
    {
        Vector3 PosInViewPort = Camera.main.WorldToViewportPoint(transform.position);
        
        if (PosInViewPort.x >= 0 && PosInViewPort.x <= 1 && PosInViewPort.y >= 0 && PosInViewPort.y <= 1 && PosInViewPort.z >= 0)
        {
            AIHealthBar.gameObject.SetActive(true);
            //rint("IsInView");
        }
        else
        {
            AIHealthBar.gameObject.SetActive(false);
            //print("NotInView");
        }
    }

    void OnDestroy()
    {
        //Destroy(AIHealthBar.gameObject);
    }
}
