using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    [SerializeField]public GameObject[] obj;

    public UpgradeManger manager;
    //public Requirements req;

    public Vector2[] placement;
    public TMP_Text[] text;
    public GameObject[] test;

    Requirements req = new Requirements();

    private void Start()
    {
        //req = GetComponent<Requirements>();
        manager = FindObjectOfType<UpgradeManger>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(GetList());

        }
    }
    public void CheckReq()
    {
        StateManager state = FindObjectOfType<StateManager>();
        InventoryManager inv = FindObjectOfType<InventoryManager>();

        for(int i = 0; i < GetList().Count; i++)
        {
            print(i);
            test[i] = Instantiate(GetList()[i].material, placement[i], Quaternion.identity);
            //test[i].GetComponentInChildren<TMP_Text>().text = GetList()[i].cost.ToString();
            //test[i].transform.SetParent(this.transform);
        }

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
    public List<Requirements> GetList()
    {
        List<Requirements> list = new List<Requirements>();

        for (int i = 0; i < manager.reqs.Length; i++)
        {
            if (manager.reqs[i] > 0)
            {
                list.Add(new Requirements() { material = req.GetMaterial(i, obj), cost = manager.reqs[i] });
            }
            print(list[i].material);
        }

        return list;
    }

    public class Requirements
    {
        public GameObject material;
        public int cost;
        public GameObject GetMaterial(int i, GameObject[] obj)
        {
            switch (i)
            {
                default:
                case 0: return obj[0];
                case 1: return obj[1];
                case 2: return obj[2];
            }
        }
    }
}

