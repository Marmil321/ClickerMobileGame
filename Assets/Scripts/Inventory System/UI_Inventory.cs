using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField]private Transform itemSlotContainer;
    [SerializeField]private Transform itemSlotTemplate;

    private void Start()
    {
        RefreshInventoryItems();
    }
    private void Awake()
    {
        itemSlotContainer = GameObject.Find("itemSlotContainer").transform;
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");      
    }
    private void Update()
    {
        /*if (GameObject.Find("selection"))
        {
            GameObject selected = GameObject.Find("selection");
            selected.transform.parent.transform.parent.name = "SELECTED";
        }*/
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        
        inventory.OnItemListChanged += Inventory_OnListChanged;
    }
    private void Inventory_OnListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }
    public void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);   
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 140f;

        FindObjectOfType<InventoryManager>().SELECTED_ID = 0;

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRect = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRect.gameObject.SetActive(true);
            itemSlotRect.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
          
            Image image = itemSlotRect.Find("Icon").GetComponent<Image>();
            image.sprite = item.GetSprite();

            Text uiText = itemSlotRect.Find("amount").GetComponent<Text>();
            if(item.amount > 1)
            {
                uiText.text = item.amount.ToString();
            }
            else
            {
                uiText.text = "";
            }
            

            x++;
            if (x > 4) 
            {
                x = 0;
                y--;
            }
        }
    }

}
