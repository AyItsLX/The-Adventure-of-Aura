using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearInfoPanelOnNull : MonoBehaviour {

    //Variables

    //public Text InfoPanelItemName;

    //public Image InfoPanelArtwork;

    //public Text InfoPanelDescription;

    public GameObject BP;

    public GameObject ShopPanel;

    public GameObject InventoryPanel;
    


	void Start ()
    {
        BP = GameObject.Find("BackPack");

        ShopPanel = BP.transform.Find("ShopPanel").gameObject;

        InventoryPanel = BP.transform.Find("InventoryPanel").gameObject;

        //InfoPanelItemName = this.transform.Find("Name").GetComponent<Text>();
        //InfoPanelArtwork = this.transform.Find("Artwork").GetComponent<Image>();
        //InfoPanelDescription = this.transform.Find("Description").GetComponent<Text>();
    }
	
	void Update ()
    {
		if (ShopPanel.activeSelf == true)
        {
            if (BP.GetComponent<BPScript>().SelectedItemShop == null)
            {
                foreach (Transform Child in this.transform)
                {
                    Child.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (Transform Child in this.transform)
                {
                    Child.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            if (BP.GetComponent<BPScript>().SelectedItemInventory == null)
            {
                foreach (Transform Child in this.transform)
                {
                    Child.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (Transform Child in this.transform)
                {
                    Child.gameObject.SetActive(true);
                }
            }
        }
	}
}
