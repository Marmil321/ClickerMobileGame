using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public InventoryManager inventoryManager;

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
                UseAxe(); 
            break;
        }
    }

    //Use items
    void UseAxe()
    {
        print("USEAXE");
        //print(inventory.GetItemList().Count);
        inventoryManager.RemoveItem(Item.ItemType.StoneAxe);
    }
}

