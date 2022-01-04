using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int wood, stone, bronze, bronzeOre, iron, ironOre, coal, stick;

    public int SELECTED_ID;

    public Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;

    public SaveInventory save;

    private void Awake()
    {   
        this.enabled = true;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        save = FindObjectOfType<SaveInventory>();
    }
    private void Update()
    {
        wood = PlayerPrefs.GetInt("WoodAmount");
        stone = PlayerPrefs.GetInt("StoneAmount");
        bronze = PlayerPrefs.GetInt("BronzeAmount");
        bronzeOre = PlayerPrefs.GetInt("BronzeOreAmount");
        iron = PlayerPrefs.GetInt("IronAmount");
        ironOre = PlayerPrefs.GetInt("IronOreAmount");
        coal = PlayerPrefs.GetInt("CoalAmount");
        stick = PlayerPrefs.GetInt("StickAmount");
    }
    public void AddItem(Item.ItemType item, int addAmount)
    {
        inventory.AddItem(new Item { itemType = item, amount = addAmount });
    }
    public void RemoveItem(Item.ItemType item)
    {
        //inventory.RemoveItem(new Item { itemType = item});
        foreach (Item items in inventory.GetItemList())
        {
            if(items.itemType == item)
            {
                inventory.RemoveItem(items);
                break;
            }
        }
    }
    public void RemoveMaterial(string material, int amount)
    {
        int mat = PlayerPrefs.GetInt(material);
        PlayerPrefs.SetInt(material, mat - amount);
    }
    public void Add(string material, int amount)
    {
        int mat = PlayerPrefs.GetInt(material);
        PlayerPrefs.SetInt(material, mat + amount);
    }
}
