using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    [SerializeField]public GameObject[] obj;

    public UpgradeManger manager;
    public StateManager state;
    public InventoryManager inv;

    public Transform[] placement;
    public TMP_Text[] text;

    Requirements req = new Requirements();
    RequirementList requirements;

    private void Start()
    {
        //req = GetComponent<Requirements>();
        manager = FindObjectOfType<UpgradeManger>();
        state = FindObjectOfType<StateManager>();
        inv = FindObjectOfType<InventoryManager>();
        requirements = FindObjectOfType<RequirementList>();
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            print(GetList());
        }*/
    }
    public void PopUp()
    {
        DeleteUI();

        GameObject popup = this.transform.Find("Popup").gameObject;
        if (popup.activeInHierarchy == true)
        {
            popup.SetActive(false);
        }
        else
        {
            popup.SetActive(true);
            CheckReq();
        }     
    }
    private void DeleteUI()
    {
        foreach (Transform child in this.transform.Find("parent"))
        {
            Destroy(child.gameObject);
        }
    }
    private void CheckReq()
    {
        //DeleteUI();

        for(int i = 0; i < GetList().Count; i++)
        {
            GameObject inst = Instantiate(GetList()[i].material, placement[i].position, Quaternion.identity);
            inst.GetComponentInChildren<TMP_Text>().text = GetList()[i].cost.ToString();
            inst.transform.SetParent(this.transform.Find("parent").transform);
        }      
    }
    public void UpgradeButton()
    {
        if (CanUpgrade())
        {
            RemoveMaterials();
            Upgrade();
            PopUp();
            DeleteUI();
        }
    }
    bool CanUpgrade()
    {
        if(inv.wood >= manager.reqs[0])
        {
            if (inv.stone >= manager.reqs[1])
            {
                if (inv.copper >= manager.reqs[2])
                {
                    if (inv.stick >= manager.reqs[3])
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
    private void RemoveMaterials()
    {
        inv.RemoveMaterial("WoodAmount", manager.reqs[0]);
        inv.RemoveMaterial("StoneAmount", manager.reqs[1]);
        inv.RemoveMaterial("CopperAmount", manager.reqs[2]);
        inv.RemoveMaterial("StickAmount", manager.reqs[3]);
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

        for (int i = 0; i < manager.reqs.Count; i++)
        {
            if (manager.reqs[i] > 0)
            {
                list.Add(new Requirements() { material = req.GetMaterial(i, obj), cost = manager.reqs[i] });
            }
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
                case 3: return obj[3];
            }
        }
    }
}

