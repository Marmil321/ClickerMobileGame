using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInventory : MonoBehaviour
{
    private Inventory inventory;
    public InventoryManager manager;

    [SerializeField] List<string> saveList = new List<string>();
    public int amount;
    private void Start()
    {
        manager = FindObjectOfType<InventoryManager>();
        inventory = FindObjectOfType<InventoryManager>().inventory;
        LoadInv();
    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveInv();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadInv();
        }

        PlayerPrefs.SetInt("saveItemCount", amount);
    }
    public void SaveInv()
    {
        saveList.Clear();
        amount = 0;

        for (int i = 0; i < PlayerPrefs.GetInt("saveItemCount"); i++)
        {
            PlayerPrefs.DeleteKey("itemString" + i);
        }    

        foreach(Item item in inventory.GetItemList())
        {
            amount++;          

            string itemString = item.itemType.ToString();
            PlayerPrefs.SetString("itemString" + amount, itemString);
            saveList.Add(PlayerPrefs.GetString("itemString" + amount));         
        }
    }
    public void LoadInv()
    {
        saveList.Clear();

        for (int i = 0; i < PlayerPrefs.GetInt("saveItemCount"); i++)
        {
            saveList.Add(PlayerPrefs.GetString("itemString" + (i + 1)));
           // print(PlayerPrefs.GetString("itemString" + (i + 1)));
        }

        //amount = 0;

        foreach (string item in saveList)
        {
            switch (item)
            {
                case "CopperAxe":       manager.AddItem(Item.ItemType.CopperAxe, 1);     break;
                case "CopperPickaxe":   manager.AddItem(Item.ItemType.CopperPickaxe, 1); break;
            }
            
        }
    }
}
