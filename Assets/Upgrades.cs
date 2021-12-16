using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    [SerializeField]public GameObject[] obj;
    public bool classTest;

    public UpgradeManger manager;

    private void Start()
    {
        manager = FindObjectOfType<UpgradeManger>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(Getlist());
        }
    }
    public void CheckReq()
    {
        StateManager state = FindObjectOfType<StateManager>();
        InventoryManager inv = FindObjectOfType<InventoryManager>();


        switch (state.activeState)
        {
            case "tree":
                if (PlayerPrefs.GetInt("WoodAmount") >= manager.reqs[0])
                {
                    inv.RemoveMaterial("WoodAmount", manager.reqs[0]);
                    Upgrade();
                }
                break;
            case "stone":
                if (PlayerPrefs.GetInt("StoneAmount") >= manager.reqs[1])
                {
                    inv.RemoveMaterial("StoneAmount", manager.reqs[1]);
                    Upgrade();
                }
                break;
            case "furnace":
                if (PlayerPrefs.GetInt("IronAmount") >= manager.reqs[2])
                {
                    inv.RemoveMaterial("IronAmount", manager.reqs[2]);
                    Upgrade();
                }
                break;
        }
    }
    public void Upgrade()
    {
        StateManager state = FindObjectOfType<StateManager>();
        UpgradeManger upgrade = FindObjectOfType<UpgradeManger>();

        switch (state.activeState)
        {
            case "tree":
                PlayerPrefs.SetInt("TreeLevel", upgrade.upgradeAmounts[0]++);
                break;
            case "stone":
                PlayerPrefs.SetInt("StoneLevel", upgrade.upgradeAmounts[1]++);
                break;
            case "furnace":
                PlayerPrefs.SetInt("FurnaceLevel", upgrade.upgradeAmounts[2]++);
                break;
        }
    }
    List<Requirements> Getlist()
    {
        List<Requirements> list = new List<Requirements>();
        Requirements req = new Requirements();

        for(int i = 0; i < manager.reqs.Length; i++)
        {
            if(manager.reqs[i] > 0)
            {
                //list.Add(new Requirements() { material = req.GetMaterial(i) ,cost = manager.reqs[i] });
            }
            //print(list[i].material);
        }

        print(req.testPrint());
        //list.Add(new Requirements() {material =  obj, cost = 100});
        
        return list;
    }
}
public class Requirements : MonoBehaviour
{
    public GameObject material;
    public int cost;

    Upgrades upgrade = new Upgrades();

    public GameObject GetMaterial(int i)
    {
        switch (i)
        {
            default:
            case 0: return upgrade.obj[0];
            case 1: return upgrade.obj[1];
            case 2: return upgrade.obj[2];
        }
    }
    public bool testPrint()
    {
        upgrade.classTest = false;
        return upgrade.classTest;
    }
}
