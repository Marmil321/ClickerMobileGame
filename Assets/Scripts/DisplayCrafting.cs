using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCrafting : MonoBehaviour
{
    public int selectedCat = 1;
    public int selectedItem;
    public int i;
    public InventoryManager inv;

    public RectTransform[] pages;
    public ScrollRect scroll;

    public Transform[] grid;
    public Transform table;

    public GameObject[] icons;
    //0 - Placeholder
    //1 - Wood
    //2 - Copper
    //3 - Coal
    //4 - 
    //5 - 
    //6 -

    private Inventory inventory;
    private void Awake()
    {
        scroll = GetComponent<ScrollRect>();
        inv = FindObjectOfType<InventoryManager>();

        inventory = new Inventory();
    }

    public void SelectOne()
    {
        selectedCat = 1;
    }
    public void SelectTwo()
    {
        selectedCat = 2;
    }
    public void SelectThree()
    {
        selectedCat = 3;
    }
    public void SelectFour()
    {
        selectedCat = 4;
    }
    private void Update()
    {
        switch (selectedCat)
        {
            case 1:
                scroll.content = pages[0];
                pages[0].gameObject.SetActive(true);
                pages[1].gameObject.SetActive(false);
                break;
            case 2:
                scroll.content = pages[1];
                pages[0].gameObject.SetActive(false);
                pages[1].gameObject.SetActive(true);
                break;
        }
    }
    public void Craft()
    {

        switch (selectedItem)
        {
            case 0:
                print("ERROR");             
                break;
            case 1:
                if (inv.wood >= 5)
                {
                    inv.RemoveMaterial("WoodAmount", 5);
                    inv.Add("CoalAmount", 1);
                }           
                CraftCoal();
                break;
            case 2: 
                if(inv.stick >=3 && inv.copper >= 2)
                {
                    inv.AddItem(Item.ItemType.CopperAxe, 1);
                    inv.save.SaveInv();

                    inv.RemoveMaterial("StickAmount", 3);
                    inv.RemoveMaterial("CopperAmount", 2);

                    FindObjectOfType<FirstItem>().NewItem(1, "Copperaxe", "Copper Axe");
                }
                CraftCopperAxe();
                break;

            case 3:
                if (inv.wood >= 3)
                {
                    inv.Add("StickAmount", 1);
                    inv.RemoveMaterial("WoodAmount", 3);
                }
                CraftStick();
                break;
            case 4:
                if(inv.stick >= 2 && inv.copper >= 5)
                {
                    inv.AddItem(Item.ItemType.CopperPickaxe, 1);
                    inv.save.SaveInv();

                    inv.RemoveMaterial("StickAmount", 2);
                    inv.RemoveMaterial("CopperAmount", 5);

                    FindObjectOfType<FirstItem>().NewItem(0, "CopperPickaxe", "Copper Pickaxe");
                }          
                CraftCopperPickaxe();
                break;

        }
    }
    void Display(int icon)
    {
        GameObject obj1 = Instantiate(icons[icon], grid[0].transform.position, Quaternion.identity);
        obj1.transform.SetParent(table.transform, true);
        obj1.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

    }
    public void CraftCoal()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        if (inv.wood >= 3)
        {
            Display(1);

            selectedItem = 1;           
        }      
    }
    public void CraftCopperAxe()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        if (inv.stick >= 3 && inv.copper >= 3)
        {
            Display(3);

            selectedItem = 2;
        }
    }
    public void CraftStick()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        if (inv.wood >= 3)
        {
            Display(4);

            selectedItem = 3;
        }
    }
    public void CraftCopperPickaxe()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        if (inv.stick >= 2 && inv.copper >= 5)
        {

            Display(2);

            selectedItem = 4;
        }
    }
}
