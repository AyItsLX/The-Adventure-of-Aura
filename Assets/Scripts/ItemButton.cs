using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    //Variables

    public GameObject BP; 

    public Item Item;

    public GameObject InfoPanel;

    public GameObject ShopPanel;

    public Image InfoPanelArtwork;

    public Text InfoPanelItemName;

    public Text InfoPanelShopItemCost;

    public Text InfoPanelDescription;

    public Text InfoPanelInventoryItemCost;

    public Text ItemCountText;

    public int ItemCount;

    void Start()
    {
        BP = GameObject.Find("BackPack");
        ShopPanel = BP.transform.Find("ShopPanel").gameObject; ShopPanel = BP.transform.Find("ShopPanel").gameObject;
        InfoPanel = this.transform.parent.Find("InfoPanel").gameObject;
        InfoPanelItemName = InfoPanel.transform.Find("Name").GetComponent<Text>();
        InfoPanelArtwork = InfoPanel.transform.Find("Artwork").GetComponent<Image>();
        InfoPanelDescription = InfoPanel.transform.Find("Description").GetComponent<Text>();
        if (ShopPanel.activeSelf == true)
        {
            InfoPanelShopItemCost = InfoPanel.transform.Find("PurchaseButton").Find("ItemCost").GetComponent<Text>();
        }
        else
        {
            InfoPanelInventoryItemCost = InfoPanel.transform.Find("SellButton").Find("ItemCost").GetComponent<Text>();
        }
    }

    void Update ()
    {
        this.transform.GetComponent<Image>().sprite = Item.Artwork;

        ItemCountText.text = ItemCount.ToString();

        if (ShopPanel.activeSelf == true)
        {
            ItemCountText.gameObject.SetActive(false);
        }
        else
        {
            ItemCountText.gameObject.SetActive(true);
            if (ItemCount <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void UpdateInfo() //When Button Is Clicked
    {

        if (ShopPanel.activeSelf == true)
        {
            BP.GetComponent<BPScript>().SelectedItemShop = Item;
            InfoPanelShopItemCost.text = Item.ItemCost.ToString() + " GOLD";
        }
        else
        {
            BP.GetComponent<BPScript>().SelectedItemInventory = Item;
            InfoPanelInventoryItemCost.text = Item.ItemCost.ToString() + " GOLD";
        }
        InfoPanelItemName.text = Item.name;
        InfoPanelArtwork.sprite = Item.Artwork;
        InfoPanelDescription.text = Item.Description;   
    }
}
