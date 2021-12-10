using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int wood;
    public int stone;
    public int iron;
    public int coal;

    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;

    private void Awake()
    {
        this.enabled = true;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }
    private void Update()
    {
        wood = PlayerPrefs.GetInt("WoodAmount");
        stone = PlayerPrefs.GetInt("StoneAmount");
        iron = PlayerPrefs.GetInt("IronAmount");
        coal = PlayerPrefs.GetInt("CoalAmount");
    }
    public void AddItem(Item.ItemType item, int addAmount)
    {
        inventory.AddItem(new Item { itemType = item, amount = addAmount });
    }
    public void RemoveItem(string material, int amount)
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
