using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPScript : MonoBehaviour {

    public GameObject Player;
    public GameManager GM;
    public int GoldCount;
    public GameObject ItemButtonPrefab;
    public GameObject ShopPanel;
    public GameObject InventoryPanel;
    public Item SelectedItemShop;
    public Item SelectedItemInventory;
    public List<Item> ShopItems = new List<Item>();
    public List<Item> InventoryItems = new List<Item>();
    public Text GoldCountText;

    void Start()
    {
        foreach (Item Item in ShopItems)
        {
            GameObject ItemButton = Instantiate(ItemButtonPrefab) as GameObject;
            ItemButton.GetComponent<ItemButton>().Item = Item;
            ItemButton.transform.SetParent(ShopPanel.transform, false);
        }
    }

    void Update ()
    {
        GoldCount = GM.GoldCount;
        GoldCountText.text = "GOLD: " + GoldCount.ToString();
	}

    public void GetShop()
    {
        RefreshInventory();
        InventoryPanel.SetActive(false);
        ShopPanel.SetActive(true);
    }

    public void GetInventory()
    {
        RefreshInventory();
        ShopPanel.SetActive(false);
        InventoryPanel.SetActive(true);
    }

    public void Exit()
    {
        RefreshInventory();
        this.transform.gameObject.SetActive(false);
    }

    public void RefreshInventory()
    {
        foreach (Transform Button in InventoryPanel.transform)
        {
            if (Button.name != "InfoPanel")
            {
                Button.GetComponent<ItemButton>().ItemCount = 0;
            }
        }
        foreach (Item Item in InventoryItems)
        {
            bool CreateNewButton = true;

            foreach (Transform Button in InventoryPanel.transform)
            {
                if (Button.name == Item.name)
                {
                    CreateNewButton = false;
                    Button.GetComponent<ItemButton>().ItemCount += 1;
                }
            }


            if (CreateNewButton == true)
            {
                GameObject ItemButton = Instantiate(ItemButtonPrefab) as GameObject;
                ItemButton.name = Item.name;
                ItemButton.GetComponent<ItemButton>().Item = Item;
                ItemButton.GetComponent<ItemButton>().ItemCount = 1;
                ItemButton.transform.SetParent(InventoryPanel.transform, false);
            }
        }
    }

    public void BuyItem()
    {
        if (SelectedItemShop.ItemCost <= GoldCount)
        {
            print("Bought " + SelectedItemShop.name);
            GM.GoldCount -= SelectedItemShop.ItemCost;

            UpdatePlayerStats(true);

            InventoryItems.Add(SelectedItemShop);
            RefreshInventory();
        }
        else
        {
            print("Ur Too Poor");
        }
    }

    public void SellItem()
    {
        if (SelectedItemInventory == null)
        {
            return;
        }
        InventoryItems.Remove(SelectedItemInventory);
        RefreshInventory();

        UpdatePlayerStats(false);

        GM.GoldCount += SelectedItemInventory.ItemCost;

        foreach (Item I in InventoryItems)
        {
            if (I == SelectedItemInventory)
            {
                return;
            }
        }
        
        SelectedItemInventory = null;
    }

    void UpdatePlayerStats(bool Increment) //True if BuyItem(), False if SellItem()
    {
        CurrentStats CS = Player.GetComponent<CurrentStats>();
        if (Increment)
        {
            CS.Damage += SelectedItemShop.AddedDamage;
            CS.MaxHealth += SelectedItemShop.AddedHealth;
            CS.AttackSpeed -= SelectedItemShop.AddedAttackSpeed;
            CS.MovementSpeed += SelectedItemShop.AddedMovementSpeed;
            CS.LifeStealPercentage += SelectedItemShop.AddedLifeStealPercentage;
            CS.CoolDown -= SelectedItemShop.AddedCoolDown;
        }
        else
        {
            CS.Damage -= SelectedItemInventory.AddedDamage;
            CS.MaxHealth -= SelectedItemInventory.AddedHealth;
            CS.AttackSpeed += SelectedItemInventory.AddedAttackSpeed;
            CS.MovementSpeed -= SelectedItemInventory.AddedMovementSpeed;
            CS.LifeStealPercentage -= SelectedItemInventory.AddedLifeStealPercentage;
            CS.CoolDown += SelectedItemShop.AddedCoolDown;
        }
    }
}
