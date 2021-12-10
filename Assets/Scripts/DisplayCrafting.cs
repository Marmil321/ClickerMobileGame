using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject placeholder, wood;
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
                print("ERRoR");
                break;
            case 1:
                print("Craft Coal");
                if (inv.wood >= 5)
                {
                    //inv.RemoveItem("WoodAmount", 5);
                    inv.AddItem(Item.ItemType.Coal, 1);
                    //inv.Add("CoalAmount", 1);
                }           
                CraftCoal();
                break;
            case 2:
                print("Craft Axe");
                inv.AddItem(Item.ItemType.StoneAxe, 1);
                break;

        }
    }
    public void CraftCoal()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        selectedItem = 1;

        if (inv.wood > 0)
        {
            GameObject obj1 = Instantiate(wood, grid[1].transform.position, Quaternion.identity);
            obj1.transform.SetParent(table.transform);
            if(inv.wood > 1)
            {
                GameObject obj2 = Instantiate(wood, grid[3].transform.position, Quaternion.identity);
                obj2.transform.SetParent(table.transform);
                if(inv.wood > 2)
                {
                    GameObject obj3 = Instantiate(wood, grid[4].transform.position, Quaternion.identity);
                    obj3.transform.SetParent(table.transform);
                    if(inv.wood > 3)
                    {
                        GameObject obj4 = Instantiate(wood, grid[5].transform.position, Quaternion.identity);
                        obj4.transform.SetParent(table.transform);
                        if (inv.wood > 4)
                        {
                            GameObject obj5 = Instantiate(wood, grid[7].transform.position, Quaternion.identity);
                            obj5.transform.SetParent(table.transform);
                            GameObject obj6 = Instantiate(placeholder, grid[9].transform.position, Quaternion.identity);
                            obj6.transform.SetParent(table.transform);
                        }
                    }
                }
            }
        }      
    }
    public void CraftStoneAxe()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        selectedItem = 2;

        if (inv.wood > 0)
        {
            GameObject obj1 = Instantiate(placeholder, grid[0].transform.position, Quaternion.identity);
            obj1.transform.SetParent(table.transform);
            if (inv.wood > 1)
            {
                GameObject obj2 = Instantiate(placeholder, grid[3].transform.position, Quaternion.identity);
                obj2.transform.SetParent(table.transform);
                if (inv.wood > 2)
                {
                    GameObject obj3 = Instantiate(placeholder, grid[6].transform.position, Quaternion.identity);
                    obj3.transform.SetParent(table.transform);
                    if (inv.stone > 0)
                    {
                        GameObject obj4 = Instantiate(placeholder, grid[1].transform.position, Quaternion.identity);
                        obj4.transform.SetParent(table.transform);
                        if (inv.wood > 1)
                        {
                            GameObject obj5 = Instantiate(placeholder, grid[4].transform.position, Quaternion.identity);
                            obj5.transform.SetParent(table.transform);
                            GameObject obj6 = Instantiate(placeholder, grid[9].transform.position, Quaternion.identity);
                            obj6.transform.SetParent(table.transform);
                        }
                    }
                }
            }
        }
    }
}
