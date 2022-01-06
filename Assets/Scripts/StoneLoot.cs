using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneLoot : MonoBehaviour
{
    int copperAmount;
    public InventoryManager inv;
    UpgradeManger upgrade;

    public int copperChance, ironChance, goldChance;

    private void Start()
    {
        inv = FindObjectOfType<InventoryManager>();
        upgrade = FindObjectOfType<UpgradeManger>();
    }
    private void Update()
    {
        copperAmount = PlayerPrefs.GetInt("CopperOreAmount");
    }
    private void OnMouseDown()
    {
        int getCopperOre = Random.Range(0, copperChance + 1);
        int getIronOre = Random.Range(0, ironChance + 1);
        int getGoldOre = Random.Range(0, goldChance + 1);
 
        if (getCopperOre == copperChance)
        {
            inv.Add("CopperOreAmount", 1);
            print("copper");
        }
        if(getIronOre == ironChance && upgrade.GetLevel() >= 2)
        {
            inv.Add("IronOreAmount", 1);
            print("iron");
        }
        if (getGoldOre == goldChance && upgrade.GetLevel() >= 3)
        {
            inv.Add("GoldOreAmount", 1);
            print("gold");
        }
    }
}
