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

    public GameObject[] icons;
    //0 - Placeholder
    //1 - Wood
    //2 - Coal 
    //3 - IronAxe
    //4 - Stick
    //5 - IronBar
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
                print("ERRoR");
                break;
            case 1:
                print("Craft Coal");
                if (inv.wood >= 5)
                {
                    inv.RemoveMaterial("WoodAmount", 5);
                    inv.Add("CoalAmount", 1);
                }           
                CraftCoal();
                break;
            case 2: 
                inv.AddItem(Item.ItemType.IronAxe, 1);
                break;

            case 3:
                inv.Add("StickAmount", 1);
                break;


        }
    }
    public void CraftCoal()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        if (inv.wood > 0)
        {
            GameObject obj1 = Instantiate(icons[1], grid[1].transform.position, Quaternion.identity);
            obj1.transform.SetParent(table.transform);
            if(inv.wood > 1)
            {
                GameObject obj2 = Instantiate(icons[1], grid[3].transform.position, Quaternion.identity);
                obj2.transform.SetParent(table.transform);
                if(inv.wood > 2)
                {
                    GameObject obj3 = Instantiate(icons[1], grid[4].transform.position, Quaternion.identity);
                    obj3.transform.SetParent(table.transform);
                    if(inv.wood > 3)
                    {
                        GameObject obj4 = Instantiate(icons[1], grid[5].transform.position, Quaternion.identity);
                        obj4.transform.SetParent(table.transform);
                        if (inv.wood > 4)
                        {
                            GameObject obj5 = Instantiate(icons[1], grid[7].transform.position, Quaternion.identity);
                            obj5.transform.SetParent(table.transform);
                            GameObject obj6 = Instantiate(icons[2], grid[9].transform.position, Quaternion.identity);
                            obj6.transform.SetParent(table.transform);
                            selectedItem = 1;
                        }
                    }
                }
            }
        }      
    }
    public void CraftIronAxe()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        if (inv.wood >= 1)
        {
            GameObject obj1 = Instantiate(icons[4], grid[0].transform.position, Quaternion.identity);
            obj1.transform.SetParent(table.transform);
            if (inv.wood >= 2)
            {
                GameObject obj2 = Instantiate(icons[4], grid[3].transform.position, Quaternion.identity);
                obj2.transform.SetParent(table.transform);
                if (inv.wood >= 3)
                {
                    GameObject obj3 = Instantiate(icons[4], grid[6].transform.position, Quaternion.identity);
                    obj3.transform.SetParent(table.transform);
                    if (inv.iron >= 1)
                    {
                        GameObject obj4 = Instantiate(icons[5], grid[1].transform.position, Quaternion.identity);
                        obj4.transform.SetParent(table.transform);
                        if (inv.iron >= 2)
                        {
                            GameObject obj5 = Instantiate(icons[5], grid[4].transform.position, Quaternion.identity);
                            obj5.transform.SetParent(table.transform);
                            GameObject obj6 = Instantiate(icons[3], grid[9].transform.position, Quaternion.identity);
                            obj6.transform.SetParent(table.transform);
                            selectedItem = 2;
                        }
                    }
                }
            }
        }
    }
    public void CraftStick()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        if (inv.wood > 0)
        {
            GameObject obj1 = Instantiate(icons[1], grid[1].transform.position, Quaternion.identity);
            obj1.transform.SetParent(table.transform);
            if (inv.wood > 1)
            {
                GameObject obj2 = Instantiate(icons[1], grid[4].transform.position, Quaternion.identity);
                obj2.transform.SetParent(table.transform);
                if (inv.wood > 2)
                {
                    GameObject obj3 = Instantiate(icons[1], grid[7].transform.position, Quaternion.identity);
                    obj3.transform.SetParent(table.transform);
                    GameObject obj4 = Instantiate(icons[4], grid[9].transform.position, Quaternion.identity);
                    obj4.transform.SetParent(table.transform);
                    selectedItem = 3;
                }
            }
        }
    }
    public void CraftPlanks()
    {
        foreach (Transform child in table)
        {
            Destroy(child.gameObject);
        }

        if (inv.wood > 0)
        {
            GameObject obj1 = Instantiate(icons[1], grid[3].transform.position, Quaternion.identity);
            obj1.transform.SetParent(table.transform);
            if (inv.wood > 1)
            {
                GameObject obj2 = Instantiate(icons[1], grid[4].transform.position, Quaternion.identity);
                obj2.transform.SetParent(table.transform);
                if (inv.wood > 2)
                {
                    GameObject obj3 = Instantiate(icons[1], grid[5].transform.position, Quaternion.identity);
                    obj3.transform.SetParent(table.transform);
                    GameObject obj4 = Instantiate(icons[0], grid[9].transform.position, Quaternion.identity);
                    obj4.transform.SetParent(table.transform);
                    selectedItem = 3;
                }
            }
        }
    }
}
