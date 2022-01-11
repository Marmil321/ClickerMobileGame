using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public bool usingAxe;
    public GameObject axeIcon;

    private void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }
    public void UseButton()
    {
        UseItem(inventoryManager.SELECTED_ID);
    }
    void UseItem(int ID)
    {
        switch (ID)
        {
            case 0:
                break;
            case 1:
                UseCopperAxe(); 
            break;
            case 2:
                UseCopperPickaxe();
                break;
        }
    }

    //Use items
    void UseCopperAxe()
    {
        int Newvalue = PlayerPrefs.GetInt("AutoWood") + 1;
        inventoryManager.RemoveItem(Item.ItemType.CopperAxe);
        inventoryManager.save.SaveInv();
        PlayerPrefs.SetInt("AutoWood", Newvalue);
    }
    void UseCopperPickaxe()
    {
        int Newvalue = PlayerPrefs.GetInt("AutoStone") + 1;
        inventoryManager.RemoveItem(Item.ItemType.CopperPickaxe);
        inventoryManager.save.SaveInv();
        PlayerPrefs.SetInt("AutoStone", Newvalue);
    }
}

