using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneLoot : MonoBehaviour
{
    int bronzeAmount;
    public InventoryManager inv;
    UpgradeManger upgrade;

    public int bronzeChance, ironChance, goldChance;

    private void Start()
    {
        inv = FindObjectOfType<InventoryManager>();
        upgrade = FindObjectOfType<UpgradeManger>();
    }
    private void Update()
    {
        bronzeAmount = PlayerPrefs.GetInt("BronzeOreAmount");
    }
    private void OnMouseDown()
    {
        int getBronzeOre = Random.Range(0, bronzeChance + 1);
        int getIronOre = Random.Range(0, ironChance + 1);
        int getGoldOre = Random.Range(0, goldChance + 1);
 
        if (getBronzeOre == bronzeChance)
        {
            inv.Add("BronzeOreAmount", 1);
            print("bronze");
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
